using Smashup.Domain.Shared;

namespace Smashup.Domain.Modules.Users.Exceptions
{
  public class InvalidUserException : BaseException
  {
    public InvalidUserException() : base("Invalid User")
    {
    }
  }
}