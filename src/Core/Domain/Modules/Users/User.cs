using Smashup.Domain.Shared;
using Smashup.Domain.Modules.Users.Exceptions;
using Smashup.Domain.Modules.Users.DTOs;
using Smashup.Domain.Modules.Bets;

namespace Smashup.Domain.Modules.Users
{
  public class User : BaseEntity
  {
    public string username { get; set; }
    public string password { get; set; }
    public List<Bet> bets = new List<Bet>();

    private User(string username, string password)
    {
      this.username = username;
      this.password = password;
    }



    public static Either<InvalidUserException, User> Create(CreateUserDTO dto)
    {
      if (!User.IsValid(dto))
      {
        return new InvalidUserException();
      }

      return new User(dto.username, dto.password);

    }

    private static bool IsValid(CreateUserDTO dto)
    {

      if (dto.username is not string || dto.password is not string)
      {
        return false;
      }

      return true;
    }
  }
}