using MediatR;

namespace Smashup.Application.Features.Users.Requests.Commands;

public class DeleteByIdUserCommand : IRequest<Unit>
{
  public string id { get; set; }
}
