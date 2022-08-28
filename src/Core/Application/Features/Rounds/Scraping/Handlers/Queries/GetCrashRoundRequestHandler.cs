using MediatR;
using AutoMapper;
using Smashup.Application.Features.Rounds.Scraping.Requests.Queries;
using Smashup.Application.Contracts.Providers;
using Smashup.Application.Models.Headless;
using Smashup.Domain.DTOs.Rounds;
using Smashup.Application.Extensions;
using Smashup.Domain.Modules.Rounds;
using Smashup.Domain.DTOs.Colors;
using Smashup.Application.Exceptions.Rounds.Scraping;
using OneOf;
using Smashup.Application.Contracts.Persistence;

namespace Smashup.Application.Features.Rounds.Scraping.Handlers.Queries
{

  public class GetCrashRoundRequestHandler : IRequestHandler<GetCrashRoundRequest, GetCrashRoundResponse>
  {
    private readonly HeadlessProvider _headlessProvider;
    private readonly RoundRepository _roundRepository;
    private readonly IMapper _mapper;


    public GetCrashRoundRequestHandler(HeadlessProvider headlessProvider, RoundRepository roundRepository, IMapper mapper)
    {
      this._headlessProvider = headlessProvider;
      this._roundRepository = roundRepository;
      this._mapper = mapper;
    }

    public async Task<GetCrashRoundResponse> Handle(GetCrashRoundRequest request, CancellationToken cancellationToken)
    {
      string? currentRoundId = await this._headlessProvider.FindText(new FindText
      {
        target = "div.info-bg div.seamless-title span:nth-of-type(2)",
        isIframe = true,
        maxSelectorTimeout = 40000,
        timeout = 2000,
      });

      if (string.IsNullOrEmpty(currentRoundId) || (request.crash.GetLastRoundIdentifier() is not null && currentRoundId.RemoveWhiteSpaces() == request.crash.GetLastRoundIdentifier()))
      {
        return new GetCrashRoundResponse(new WaitingUtilRoundChangeException());
      }

      var colorSelector = "div.mini-bg > div div.crash-panel div.crash-main div.roulette-recent-crash div.entries.main div.entry:first-of-type div.crash-box";

      string? colorNumber = await this._headlessProvider.FindText(new FindText
      {
        target = $"{colorSelector} > div.point",
        isIframe = true,
        maxSelectorTimeout = 40000,
        timeout = 2000,
      });

      if (string.IsNullOrEmpty(colorNumber))
      {
        return new GetCrashRoundResponse(new InvalidColorNumberException());
      }

      string? colorClass = await this._headlessProvider.FindAttribute(new FindAttribute
      {
        target = $"{colorSelector} > div.point",
        maxSelectorTimeout = 16000,
        attributeName = "class",
        isIframe = true,
      });


      if (string.IsNullOrEmpty(colorClass))
      {
        return new GetCrashRoundResponse(new InvalidColorNameException());
      }

      var (colorName, _) = colorClass.Split();

      if (string.IsNullOrEmpty(colorName))
      {
        colorName = "black";
      }

      var roundDomainOrError = Round.Create(new CreateRoundDTO
      {
        color = new CreateColorDTO
        {
          name = colorName,
          meta = Convert.ToInt32(colorNumber.OnlyNumbers())
        },
        seed = currentRoundId.RemoveWhiteSpaces(),
        rounds = request.crash.rounds
      });

      if (roundDomainOrError.IsLeft())
      {
        return new GetCrashRoundResponse(roundDomainOrError.left);
      }

      await this._roundRepository.Add(roundDomainOrError.right);

      return new GetCrashRoundResponse(roundDomainOrError.right);
    }
  }
}