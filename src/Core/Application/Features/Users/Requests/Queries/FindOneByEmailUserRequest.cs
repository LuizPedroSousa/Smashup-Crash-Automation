using MediatR;
using Smashup.Application.DTOs.Users;

namespace Smashup.Application.Features.Users.Requests.Queries
{
  public class FindOneByUsernameUserRequest : IRequest<UserDTO>
  {
    public string email { get; set; }
  }
}