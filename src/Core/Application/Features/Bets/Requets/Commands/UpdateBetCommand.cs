using MediatR;
using Smashup.Application.DTOs.Bets;
using Smashup.Domain.Modules.Bets;

namespace Smashup.Application.Features.Bets.Requets.Commands
{
  public class UpdateBetCommand : IRequest<Bet>
  {
    public UpdateBetDTO betDTO { get; set; }

  }
}