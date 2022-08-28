using Smashup.Application.DTOs.Shared;
using Smashup.Application.DTOs.Games;

namespace Smashup.Application.DTOs.Colors
{
  public class ColorDTO : BaseDTO
  {
    public string name { get; set; }
    public GameDTO gameDTO { get; set; }
    public string gameId { get; set; }

    public DateTime createdAt { get; set; }
  }
}