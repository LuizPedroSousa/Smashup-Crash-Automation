using Smashup.Application.Models.Headless;
namespace Smashup.Application.Contracts.Providers;

public interface HeadlessProvider
{
  Task open(Func<Task> Handle);
  Task GoTo(GoTo data);
  Task<bool> Click(Click data);
  Task<bool> FillInput(FillInput data);
  Task<bool> FindElement(FindElement data);
  Task<string?> FindText(FindText data);
  Task<string?> FindAttribute(FindAttribute data);

  Task Reload();

}
