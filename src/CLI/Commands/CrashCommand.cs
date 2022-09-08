using AutoMapper;
using McMaster.Extensions.CommandLineUtils;
using MediatR;
using Newtonsoft.Json;
using Smashup.Application.Contracts.Providers;
using Smashup.Application.DTOs.Bets;
using Smashup.Application.DTOs.Users;
using Smashup.Application.DTOs.Users.Validators;
using Smashup.Application.Exceptions.Rounds.Scraping;
using Smashup.Application.Features.Bets.Requets.Commands;
using Smashup.Application.Features.Crashs.Requests;
using Smashup.Application.Features.Rounds.Persistence.Requests.Commands;
using Smashup.Application.Features.Rounds.Scraping.Requests.Commands;
using Smashup.Application.Features.Rounds.Scraping.Requests.Queries;
using Smashup.Application.Features.Users.Requests.Commands;
using Smashup.Domain.Exceptions.Rounds;
using Smashup.Domain.Modules.Bets;
using Smashup.Domain.Modules.Crashs;
using Smashup.Domain.Modules.Games;
using Smashup.Domain.Modules.Games.ValueObjects.GameConfiguration;
using Smashup.Domain.Modules.Rounds;
using Smashup.Domain.Modules.Users;
using Smashup.Domain.Shared;

namespace Smashup.CLI.Commands;

[Command(name: "crash", Description = "Automatização de apostas do crash")]
public class CrashCommand : BaseCommand
{
  private readonly IMediator _mediator;
  private readonly IConsole _console;
  private readonly IMapper _mapper;
  private readonly HeadlessProvider _headlessProvider;

  public CrashCommand(IMediator mediator, IConsole console, IMapper mapper, HeadlessProvider headlessProvider)
  {
    this._mediator = mediator;
    this._console = console;
    this._mapper = mapper;
    this._headlessProvider = headlessProvider;
  }


  private async Task<AuthenticateUserDTO> GetCredentials()
  {
    this._console.ForegroundColor = ConsoleColor.Blue;

    this._console.WriteLine("🔸 Porfavor digite suas credenciais da smashup");

    this._console.ForegroundColor = ConsoleColor.Gray;

    var username = Prompt.GetString("username:");
    var password = Prompt.GetPassword("password:");

    var dto = new AuthenticateUserDTO
    {
      username = username,
      password = password
    };

    var validator = new AuthenticateUserDTOValidator();

    var validate = await validator.ValidateAsync(dto);

    if (!validate.IsValid)
    {
      var errors = JsonConvert.SerializeObject(validate.Errors.Select(error => error.ErrorMessage), Formatting.Indented);
      this._console.ForegroundColor = ConsoleColor.Red;
      this._console.Error.WriteLine($"🚨 Credenciais inválidas - {errors}");
      return await GetCredentials();
    }

    return dto;
  }

  private void CancelEventHandler(object sender, ConsoleCancelEventArgs args)
  {
    this._console.ForegroundColor = ConsoleColor.Cyan;
    this._console.WriteLine("\nBye bye");
    args.Cancel = true;
    Environment.Exit(0);
  }

  protected override async Task<int> OnExecute(CommandLineApplication app)
  {
    Console.CancelKeyPress += new ConsoleCancelEventHandler(CancelEventHandler);
    this._console.ForegroundColor = ConsoleColor.Gray;
    var hasLimits = Prompt.GetYesNo("️️🔹 Você gostária de setar algum limite?", false);

    var gameConfiguration = new GameConfiguration();

    if (hasLimits)
    {
      var hasBetIn = Prompt.GetYesNo("🔹 Você gostária de setar algum horário de inicio e fim?", false);
      if (hasBetIn)
      {
        var startIn = Prompt.GetString("🔹 Qual o horário para inicio de aposta?");
        var stopIn = Prompt.GetString("🔹 Qual o horário para termino de aposta?");


        BetIn betIn =

        gameConfiguration.betIn =
        new BetIn
        {
          start = DateTime.Parse(startIn),
          stop = DateTime.Parse(stopIn)
        };
      }

      gameConfiguration.limit = new Limit
      {
        lose = Prompt.GetInt("🔹 Qual limite para perder em uma aposta?"),
        win = Prompt.GetInt("🔹 Qual limite para ganhar em uma aposta?")
      };
    }

    gameConfiguration.initialAmount = Prompt.GetInt("🔹 Qual o valor inicial da aposta?", 1);

    var userDto = await GetCredentials();

    var crash = new Crash(gameConfiguration);

    await this._headlessProvider.open(async () =>
        {
          await this._mediator.Send(new AuthenticateUserCommand
          {
            userDTO = userDto
          });
          await StartCrash(crash);

          await this.Loop(crash);
        });

    return await base.OnExecute(app);
  }


  private async Task StartCrash(Crash crash, bool isInCrash = false)
  {
    this._console.ForegroundColor = ConsoleColor.Gray;
    if (!isInCrash)
    {
      await this._mediator.Send(new GoToCrashCommand());
    }
    var hasError = await this._mediator.Send(new GetCrashFailureRequest());

    if (hasError)
    {
      crash.Reset("Houve uma falha na partida");
      await StartCrash(crash, false);
      return;
    }
  }

  private async Task Loop(Crash crash)
  {
    await StartCrash(crash, true);
    if (crash.IsEndGame())
    {
      Console.WriteLine("JOGO ENCERRADO");
      return;
    }

    var roundOrError = await this._mediator.Send(new GetCrashRoundRequest
    {
      crash = crash
    }
    );

    if (roundOrError.IsLeft())
    {

      var response = (BaseException)roundOrError.left.Value;

      TypeSwitch.Do(response,
        TypeSwitch.Case<InvalidRoundException>(() =>
        {
          _console.ForegroundColor = ConsoleColor.Red;
          crash.Reset("Rodada inválida");
        }),
        TypeSwitch.Case<WaitingUtilRoundChangeException>(() =>
        {

          _console.ForegroundColor = ConsoleColor.Blue;
        }),
       TypeSwitch.Default(() =>
        {
          this._console.ForegroundColor = ConsoleColor.Red;
        })
      );


      this._console.WriteLine(response?.message);
      await Loop(crash);
      return;
    }

    crash.AddRound(roundOrError.right);

    this._console.ForegroundColor = ConsoleColor.Gray;
    this._console.WriteLine($"📑 Round criado - {JsonConvert.SerializeObject(roundOrError.right, Formatting.Indented)}");
    this._console.WriteLine($"🍏 Contagem de verdes - {crash.patternCount}");

    if (crash.CanBetInCurrentRound())
    {
      var betOrError = await this._mediator.Send(new BetCrashRoundCommand
      {
        betDTO = new BetCrashRoundDTO
        {
          amount = crash.gameConfiguration.initialAmount,
          round = roundOrError.right,
          bets = crash.bets,
          status = Domain.Modules.Bets.BetStatus.pending
        }
      });

      if (betOrError.IsRight())
      {
        this._console.WriteLine($"📑 Aposta realizada - {JsonConvert.SerializeObject(betOrError.right, Formatting.Indented)}");
        await UpdateBet(crash, betOrError.right);
      }
    }

    await Loop(crash);
    return;
  }

  private async Task UpdateBet(Crash crash, Bet bet)
  {
    var roundOrError = await this._mediator.Send(new GetCrashRoundRequest
    {
      crash = crash
    }
    );

    if (roundOrError.IsLeft())
    {
      var response = (BaseException)roundOrError.left.Value;

      this._console.WriteLine(response?.message);
      await UpdateBet(crash, bet);
      return;
    }

    var updatedBet = await this._mediator.Send(new UpdateBetCommand
    {
      betDTO = new UpdateBetDTO
      {
        amount = bet.amount,
        status = bet.round.color.name == roundOrError.right.color.name ? BetStatus.winned : BetStatus.losed,
        id = bet.id
      }
    });

    crash.AddBet(updatedBet);
    this._console.ForegroundColor = ConsoleColor.Green;
    this._console.WriteLine($"📑 Status de aposta atualizado - {JsonConvert.SerializeObject(updatedBet, Formatting.Indented)}");
  }
}

