using MediatR;
using Smashup.Application.Features.Users.Requests.Commands;
using Smashup.Application.Contracts.Providers;
using Smashup.Application.Models.Headless;

namespace Smashup.Application.Features.Users.Handlers.Commands
{
  public class AuthenticateUserCommandHandler : IRequestHandler<AuthenticateUserCommand, Unit>
  {
    private readonly HeadlessProvider _headlessProvider;

    public AuthenticateUserCommandHandler(HeadlessProvider headlessProvider)
    {
      this._headlessProvider = headlessProvider;
    }

    public async Task<Unit> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {

      await this._headlessProvider.GoTo(new GoTo
      {
        url = "https://www.smashup.com",
        navigationTimeout = 2000
      }
      );

      await this._headlessProvider.Click(new Click
      {
        target = "div#_player_login_area > div.hidden-xs.is-desktop > a.login-tab",
        checker = new ActionCheck
        {
          text = "Registre-se"
        },
        timeout = 2000
      });

      await this._headlessProvider.FillInput(new FillInput
      {
        target = "form#_og_id_1 > div:nth-child(2) > input[name=\"login\"][placeholder=\"Nome de usuário\"]",
        timeout = 2500,
        content = request.userDTO.username,
      });

      await this._headlessProvider.FillInput(new FillInput
      {
        target = "form#_og_id_1 > div:nth-child(3) > input[name=\"password\"][placeholder=\"Senha\"]",
        timeout = 2500,
        content = request.userDTO.password,
      });


      await this._headlessProvider.Click(new Click
      {
        target = "form#_og_id_1 > input.loginBtn",
        timeout = 2000
      });

      await this._headlessProvider.FindElement(new FindElement
      {
        target = "div.user__name",
        maxSelectorTimeout = 6000
      });


      return Unit.Value;
    }
  }
}