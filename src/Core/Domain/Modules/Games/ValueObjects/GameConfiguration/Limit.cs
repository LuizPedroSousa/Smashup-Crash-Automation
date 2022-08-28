using Smashup.Domain.Shared;

namespace Smashup.Domain.Modules.Games.ValueObjects.GameConfiguration
{
  public class Limit : BaseValueObject
  {
    public int? lose { get; set; }
    public int? win { get; set; }
  }
}