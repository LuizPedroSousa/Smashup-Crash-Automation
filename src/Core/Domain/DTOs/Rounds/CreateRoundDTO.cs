using Smashup.Domain.DTOs.Colors;
using Smashup.Domain.Modules.Rounds;

namespace Smashup.Domain.DTOs.Rounds
{
  public class CreateRoundDTO
  {
    public CreateColorDTO color { get; set; }
    public string seed { get; set; }
    public List<Round> rounds { get; set; }
  }
}