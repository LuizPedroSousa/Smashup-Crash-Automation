using Smashup.Application.DTOs.Colors;

namespace Smashup.Application.DTOs.Rounds;

public interface IRoundDTO
{
  public string seed { get; set; }
  public ColorDTO colorDTO { get; set; }
  public string game_id { get; set; }
}
