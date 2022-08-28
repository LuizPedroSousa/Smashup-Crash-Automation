namespace Smashup.Domain.Shared
{
  public abstract class BaseEntity
  {
    public string id { get; set; }
    public DateTime createdAt { get; set; }
    public DateTime? updatedAt { get; set; }
    public DateTime? deletedAt { get; set; }
  }
}