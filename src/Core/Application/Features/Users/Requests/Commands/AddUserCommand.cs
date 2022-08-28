using MediatR;
using Smashup.Application.DTOs.Users;

namespace Smashup.Application.Features.Users.Requests.Commands
{
  public class AddUserCommand : IRequest<string>
  {
    public CreateUserDTO userDTO { get; set; }
  }
}