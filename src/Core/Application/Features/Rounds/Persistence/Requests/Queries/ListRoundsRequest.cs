using MediatR;
using Smashup.Application.DTOs.Rounds;

namespace Smashup.Application.Features.Rounds.Persistence.Requests.Queries;

public class ListRoundsRequest : IRequest<IReadOnlyList<RoundDTO>>
{

}
