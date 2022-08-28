using FluentValidation;
using Smashup.Application.Contracts.Persistence;

namespace Smashup.Application.DTOs.Rounds.Persistence.Validators;

public class CreateRoundDTOValidator : AbstractValidator<CreateRoundDTO>
{
  public CreateRoundDTOValidator(GameRepository gameRepository)
  {
    Include(new RoundDTOValidator(gameRepository));
  }
}
