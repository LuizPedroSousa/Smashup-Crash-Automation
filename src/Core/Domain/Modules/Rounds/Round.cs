using System.Runtime.Serialization;
using Smashup.Domain.Shared;
using Smashup.Domain.Modules.Colors;
using Smashup.Domain.DTOs.Rounds;
using Smashup.Domain.Exceptions.Rounds;

namespace Smashup.Domain.Modules.Rounds
{
  public class Round : BaseEntity
  {
    public string seed { get; set; }
    public Color color { get; set; }

    public Round(string seed, Color color)
    {
      this.color = color;
      this.seed = seed;
    }

    public Round()
    {
    }

    public static Either<InvalidRoundException, Round> Create(CreateRoundDTO dto)
    {
      if (!Round.IsValid(dto.rounds, dto.color.name))
      {
        return new InvalidRoundException("Quebra de cores");
      }

      var color = new Color(dto.color.name, dto.color.meta);

      return new Round(dto.seed, color);
    }

    public static bool IsValid(List<Round> rounds, string colorName)
    {
      if (colorName != "green" && colorName != "black")
      {
        return false;
      }

      var result = true;

      if (rounds.Count > 0)
      {
        foreach (var round in rounds)
        {
          if (round.color.name != colorName)
          {
            result = false;
            break;
          }
        }
      }

      return result;
    }
  }
}