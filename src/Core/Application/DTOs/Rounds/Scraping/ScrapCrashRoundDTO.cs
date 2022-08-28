namespace Smashup.Application.DTOs.Rounds.Scraping;

public class ScrapCrashRoundDTO
{
  public string lastRoundIdentifier { get; set; }
  public List<RoundDTO> roundDTOs { get; set; }
}
