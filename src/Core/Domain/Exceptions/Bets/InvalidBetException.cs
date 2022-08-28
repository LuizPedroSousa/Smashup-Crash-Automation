using Smashup.Domain.Shared;

namespace Smashup.Domain.Exceptions.Bets
{
  public class InvalidBetException : BaseException
  {
    public InvalidBetException(string reason) : base($"Erro ao apostar - {reason}")
    {
    }
  }
}