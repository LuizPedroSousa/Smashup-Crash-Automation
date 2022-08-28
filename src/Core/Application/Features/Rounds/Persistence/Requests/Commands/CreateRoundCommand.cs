using MediatR;
using Smashup.Application.DTOs.Rounds.Persistence;
using Smashup.Domain.Shared;
using Smashup.Domain.Exceptions.Rounds;
using Smashup.Application.DTOs.Rounds;
using Smashup.Domain.Modules.Rounds;

namespace Smashup.Application.Features.Rounds.Persistence.Requests.Commands
{
  public class CreateRoundCommand : IRequest<Either<InvalidRoundException, string>>
  {
    public CreateRoundDTO roundDTO { get; set; }
  }
}