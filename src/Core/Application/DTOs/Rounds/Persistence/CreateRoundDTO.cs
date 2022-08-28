using Smashup.Application.DTOs.Colors;
using Smashup.Application.DTOs.Games;

namespace Smashup.Application.DTOs.Rounds.Persistence
{
  public class CreateRoundDTO : IRoundDTO
  {

    public string seed { get; set; }
    public ColorDTO colorDTO { get; set; }
    public GameDTO gameDTO { get; set; }
    public string game_id { get; set; }
  }
}