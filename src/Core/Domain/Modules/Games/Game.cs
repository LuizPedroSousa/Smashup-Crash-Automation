using Smashup.Domain.Shared;
using Smashup.Domain.Modules.Rounds;

namespace Smashup.Domain.Modules.Games
{
  public class Game : BaseEntity
  {
    public string name { get; set; }
    public List<Round> rounds { get; set; }

    public Game(string name, List<Round> rounds)
    {
      this.name = name;

      this.rounds = rounds;
    }
  }
}