using AutoMapper;
using MediatR;
using Smashup.Application.Contracts.Persistence;
using Smashup.Application.Contracts.Providers;
using Smashup.Application.Features.Rounds.Scraping.Requests.Commands;
using Smashup.Application.Models.Headless;
using Smashup.Domain.Modules.Bets;


namespace Smashup.Application.Features.Rounds.Scraping.Handlers.Commands
{

  public class BetCrashRoundCommandHandler : IRequestHandler<BetCrashRoundCommand, BetCrashRoundCommandResponse>
  {
    private readonly HeadlessProvider _headlessProvider;
    private readonly BetRepository _betRepository;
    private readonly IMapper _mapper;

    public BetCrashRoundCommandHandler(HeadlessProvider headlessProvider, BetRepository betRepository, IMapper mapper)
    {
      this._headlessProvider = headlessProvider;
      this._betRepository = betRepository;
      this._mapper = mapper;
    }

    public async Task<BetCrashRoundCommandResponse> Handle(BetCrashRoundCommand request, CancellationToken cancellationToken)
    {
      var betDomainDTO = this._mapper.Map<Smashup.Domain.DTOs.Bets.CreateBetDTO>(request.betDTO);
      var betDomainOrError = Bet.Create(betDomainDTO);

      if (betDomainOrError.IsLeft())
      {
        return new BetCrashRoundCommandResponse(betDomainOrError.left);
      }

      await this._headlessProvider.FillInput(new FillInput
      {
        target = "form.bet-control input.el-input__inner[placeholder=\"Quantia\"]",
        isIframe = true,
        maxSelectorTimeout = 2000,
        content = request.betDTO.amount.ToString()
      });

      await this._headlessProvider.FillInput(new FillInput
      {
        target = "form.bet-control input.el-input__inner[placeholder=\"Saque\"]",
        isIframe = true,
        maxSelectorTimeout = 2000,
        content = "2",
      });

      await this._headlessProvider.Click(new Click
      {
        target = "div.game-controls div.bet-button > button",
        isIframe = true,
        maxSelectorTimeout = 2000,
        checker = new ActionCheck
        {
          text = "aposta"
        }
      });

      var betCreated = await this._betRepository.Add(betDomainOrError.right);

      return new BetCrashRoundCommandResponse(betCreated);
    }
  }
}