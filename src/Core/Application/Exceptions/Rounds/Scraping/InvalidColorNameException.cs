using Smashup.Domain.Shared;

namespace Smashup.Application.Exceptions.Rounds.Scraping
{
  public class InvalidColorNameException : BaseException
  {
    public InvalidColorNameException() : base($"Houve um erro ao buscar nome da cor")
    {
    }
  }
}