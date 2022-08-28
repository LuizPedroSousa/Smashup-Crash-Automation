using Smashup.Domain.Shared;

namespace Smashup.Domain.Exceptions.Bets
{
  public class CantBetInThisRoundException : BaseException
  {
    public CantBetInThisRoundException(string reason) : base($"Não foi apostar neste round - {reason}")
    {
    }
  }
}