using Smashup.Application.DTOs.Shared;
using Smashup.Application.DTOs.Colors;

namespace Smashup.Application.DTOs.Rounds.Persistence
{
  public class UpdateRoundDTO : BaseDTO, IRoundDTO
  {

    public string seed { get; set; }
    public ColorDTO colorDTO { get; set; }
    public string game_id { get; set; }
    public DateTime createdAt { get; set; }

  }
}