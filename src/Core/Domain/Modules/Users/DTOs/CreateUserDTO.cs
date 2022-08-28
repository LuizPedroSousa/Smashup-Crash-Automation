using System.ComponentModel.DataAnnotations;

namespace Smashup.Domain.Modules.Users.DTOs
{
  public class CreateUserDTO
  {
    [Required]
    public string username { get; set; }
    [Required]
    public string password { get; set; }

    public CreateUserDTO(string username, string password)
    {
      this.username = username;
      this.password = password;
    }
  }
}