using Smashup.Application.DTOs.Games;

namespace Smashup.Application.DTOs.Colors
{
  public class CreateColorDTO

  {
    public string name { get; set; }
    public GameDTO gameDTO { get; set; }
    public string gameId { get; set; }
  }
}