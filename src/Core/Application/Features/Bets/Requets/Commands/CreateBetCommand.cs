using MediatR;
using Smashup.Application.DTOs.Bets;

namespace Application.Features.Bets.Requets.Commands
{
  public class CreateBetCommand : IRequest<string>
  {
    CreateBetDTO betDTO { get; set; }
  }
}