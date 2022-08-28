namespace Smashup.Application.DTOs.Users;

public class AuthenticateUserDTO : IUserDTO
{
  public string username { get; set; }
  public string password { get; set; }

}
