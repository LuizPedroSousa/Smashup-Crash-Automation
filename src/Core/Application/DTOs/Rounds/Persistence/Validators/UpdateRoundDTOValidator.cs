using Smashup.Application.Contracts.Persistence;
using FluentValidation;

namespace Smashup.Application.DTOs.Rounds.Persistence.Validators
{
  public class UpdateRoundDTOValidator : AbstractValidator<RoundDTO>
  {

    public UpdateRoundDTOValidator(GameRepository gameRepository)
    {
      Include(new RoundDTOValidator(gameRepository));
      RuleFor(round => round.id).NotEmpty().NotNull().WithMessage("{PropertyName} must be defined").MustAsync(
        async (id, token) =>
        {
          var roundExists = await gameRepository.Exists(id);
          return !roundExists;
        }
      );
    }
  }
}