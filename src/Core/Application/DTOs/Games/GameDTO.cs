using Smashup.Application.DTOs.Shared;

namespace Smashup.Application.DTOs.Games
{
  public class GameDTO : BaseDTO
  {
    public string name { get; set; }
    public DateTime updatedAt { get; set; }
    public DateTime createdAt { get; set; }
  }
}