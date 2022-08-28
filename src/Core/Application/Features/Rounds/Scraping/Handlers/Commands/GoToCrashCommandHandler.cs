using MediatR;
using Smashup.Application.Contracts.Providers;
using Smashup.Application.Features.Rounds.Scraping.Requests.Commands;
using Smashup.Application.Models.Headless;

namespace Smashup.Application.Features.Rounds.Scraping.Handlers.Commands
{
  public class GoToCrashCommandHandler : IRequestHandler<GoToCrashCommand, Unit>
  {
    private readonly HeadlessProvider _headlessProvider;

    public GoToCrashCommandHandler(HeadlessProvider headlessProvider)
    {
      this._headlessProvider = headlessProvider;
    }

    public async Task<Unit> Handle(GoToCrashCommand request, CancellationToken cancellationToken)
    {
      await this._headlessProvider.Click(new Click
      {
        target = "body > header > div.had-container > nav > div > ul > li.crash > a > span",
        timeout = 2000,
      });

      return Unit.Value;
    }
  }
}