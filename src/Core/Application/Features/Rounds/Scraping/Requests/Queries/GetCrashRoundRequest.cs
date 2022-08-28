using MediatR;
using OneOf;
using Smashup.Application.Exceptions.Rounds.Scraping;
using Smashup.Domain.Exceptions.Rounds;
using Smashup.Domain.Modules.Crashs;
using Smashup.Domain.Modules.Rounds;
using Smashup.Domain.Shared;

namespace Smashup.Application.Features.Rounds.Scraping.Requests.Queries
{

  public class GetCrashRoundResponse :
    Either<OneOf<WaitingUtilRoundChangeException, InvalidColorNumberException, InvalidColorNameException, InvalidRoundException>, Round>

  {

    public GetCrashRoundResponse(OneOf<WaitingUtilRoundChangeException, InvalidColorNumberException, InvalidColorNameException, InvalidRoundException> left) : base(left)
    {
    }

    public GetCrashRoundResponse(Round right) : base(right)
    {
    }

  }
  public class GetCrashRoundRequest : IRequest<GetCrashRoundResponse>
  {
    public Crash crash { get; set; }
  }
}