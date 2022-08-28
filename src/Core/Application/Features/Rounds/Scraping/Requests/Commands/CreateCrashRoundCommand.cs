using MediatR;
using Smashup.Domain.Shared;
using Smashup.Domain.Exceptions.Rounds;

namespace Smashup.Application.Features.Rounds.Scraping.Requests.Queries;

public class CreateCrashRoundCommand : IRequest<Either<InvalidRoundException, string>>
{


}
