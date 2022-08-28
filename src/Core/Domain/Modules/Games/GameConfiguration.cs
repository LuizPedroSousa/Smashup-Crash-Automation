using Smashup.Domain.Modules.Games.ValueObjects.GameConfiguration;

namespace Smashup.Domain.Modules.Games
{
  public class GameConfiguration
  {
    public Limit limit { get; set; }
    public BetIn betIn { get; set; }
    public int initialAmount { get; set; }
  }
}