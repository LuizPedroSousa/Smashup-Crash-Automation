using MediatR;
using Smashup.Application.DTOs.Users;

namespace Smashup.Application.Features.Users.Requests.Commands;

public class AuthenticateUserCommand : IRequest<Unit>
{
  public AuthenticateUserDTO userDTO { get; set; }

}