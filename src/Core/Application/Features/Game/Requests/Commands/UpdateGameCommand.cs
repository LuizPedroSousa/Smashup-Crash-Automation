using MediatR;
using Smashup.Application.DTOs.Games;

namespace Smashup.Application.Features.Games.Requests.Commands;

public class UpdateGameCommand : IRequest<Unit>
{
  public UpdateGameDTO gameDTO { get; set; }
}
