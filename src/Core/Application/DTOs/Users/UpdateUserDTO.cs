using Smashup.Application.DTOs.Shared;
namespace Smashup.Application.DTOs.Users
{
  public class UpdateUserDTO : BaseDTO, IUserDTO
  {
    public string username { get; set; }
    public string password { get; set; }
  }
}