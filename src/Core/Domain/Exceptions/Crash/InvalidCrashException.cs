using Smashup.Domain.Shared;

namespace Smashup.Domain.Modules.Games.Exceptions
{
  public class InvalidGameException : BaseException
  {
    public InvalidGameException() : base("Invalid game exception")
    {
    }
  }
}