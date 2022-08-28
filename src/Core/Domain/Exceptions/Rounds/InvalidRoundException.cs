using Smashup.Domain.Shared;

namespace Smashup.Domain.Exceptions.Rounds
{
  public class InvalidRoundException : BaseException
  {
    public InvalidRoundException(string reason) : base($"Rodada inválida - {reason}")
    {
    }

  }
}