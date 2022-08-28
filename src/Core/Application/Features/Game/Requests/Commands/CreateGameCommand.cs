using MediatR;
using Smashup.Application.DTOs.Games;

namespace Smashup.Application.Features.Games.Requests.Commands;

public class CreateGameCommand : IRequest<string>
{
  public CreateGameDTO gameDTO { get; set; }
}
