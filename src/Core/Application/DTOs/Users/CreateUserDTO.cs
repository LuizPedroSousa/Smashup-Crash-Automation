namespace Smashup.Application.DTOs.Users
{
  public class CreateUserDTO : IUserDTO
  {
    public string username { get; set; }
    public string password { get; set; }
  }
}