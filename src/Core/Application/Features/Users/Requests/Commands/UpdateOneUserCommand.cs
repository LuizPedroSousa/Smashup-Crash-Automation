using MediatR;
using Smashup.Application.DTOs.Users;

namespace Smashup.Application.Features.Users.Requests.Commands;

public class UpdateOneUserCommand : IRequest<Unit>
{

  public UpdateUserDTO updateUserDto { get; set; }
}
