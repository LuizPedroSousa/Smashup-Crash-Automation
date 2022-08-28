using MediatR;
using Smashup.Application.Contracts.Providers;
using Smashup.Application.Features.Crashs.Requests;
using Smashup.Application.Models.Headless;

namespace Smashup.Application.Features.Crashs.Handlers.Queries
{
  public class GetCrashFailureRequestHandler : IRequestHandler<GetCrashFailureRequest, bool>
  {
    private readonly HeadlessProvider _headlessProvider;
    public GetCrashFailureRequestHandler(HeadlessProvider headlessProvider)
    {
      this._headlessProvider = headlessProvider;
    }

    public async Task<bool> Handle(GetCrashFailureRequest request, CancellationToken cancellationToken)
    {
      var error = await this._headlessProvider.FindText(new FindText
      {
        target = "#app > div.error-section > span",
        isIframe = true,
        maxSelectorTimeout = 2000,
      });

      if (!string.IsNullOrEmpty(error))
      {
        return true;
      }

      return false;
    }
  }
}