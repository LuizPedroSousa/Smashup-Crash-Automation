using MediatR;
using OneOf;
using Smashup.Application.DTOs.Bets;
using Smashup.Domain.Exceptions.Bets;
using Smashup.Domain.Modules.Bets;
using Smashup.Domain.Shared;

namespace Smashup.Application.Features.Rounds.Scraping.Requests.Commands
{

  public class BetCrashRoundCommandResponse : Either<OneOf<CantBetInThisRoundException, InvalidBetException>, Bet>
  {
    public BetCrashRoundCommandResponse(OneOf<CantBetInThisRoundException, InvalidBetException> left) : base(left)
    {
    }

    public BetCrashRoundCommandResponse(Bet right) : base(right)
    {
    }
  }

  public class BetCrashRoundCommand : IRequest<BetCrashRoundCommandResponse>
  {
    public BetCrashRoundDTO betDTO { get; set; }
  }
}