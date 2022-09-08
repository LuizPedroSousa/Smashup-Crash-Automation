using Smashup.Domain.Shared;

namespace Smashup.Application.Exceptions.Rounds.Scraping
{
  public class WaitingUtilRoundChangeException : BaseException
  {
    public WaitingUtilRoundChangeException() : base("🔹 Aguardando até o round alterar")
    {
    }
  }
}