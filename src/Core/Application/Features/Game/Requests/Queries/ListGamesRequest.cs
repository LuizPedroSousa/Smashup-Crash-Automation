using MediatR;
using Smashup.Application.DTOs.Games;

namespace Smashup.Application.Features.Games.Requests.Queries;

public class ListGamesRequest : IRequest<IReadOnlyList<GameDTO>>
{

}
