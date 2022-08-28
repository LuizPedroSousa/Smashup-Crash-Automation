using Smashup.Application.DTOs.Shared;

namespace Smashup.Application.DTOs.Users
{
  public class UserDTO : BaseDTO, IUserDTO
  {
    public string username { get; set; }
    public string password { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime updatedAt { get; set; }
    public DateTime deletedAt { get; set; }
  }
}