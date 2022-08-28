using Smashup.Domain.Shared;

namespace Smashup.Domain.Modules.Colors
{
  public class Color : BaseEntity
  {
    public string name { get; set; }
    public int meta { get; set; }

    public Color(string name, int meta)
    {
      this.name = name;
      this.meta = meta;
    }

  }
}