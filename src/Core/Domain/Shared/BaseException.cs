namespace Smashup.Domain.Shared
{
  public abstract class BaseException
  {
    public string message { get; set; }

    protected BaseException(string message)
    {
      this.message = message;
    }

  }
}