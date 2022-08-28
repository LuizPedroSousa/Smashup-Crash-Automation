using Smashup.Domain.Shared;

namespace Smashup.Application.Exceptions.Rounds.Scraping
{
  public class InvalidColorNumberException : BaseException
  {
    public InvalidColorNumberException() : base("Houve um erro ao buscar número de cor")
    {
    }
  }
}