using FluentValidation;

using Smashup.Application.Contracts.Persistence;

namespace Smashup.Application.DTOs.Rounds.Persistence.Validators
{
  public class RoundDTOValidator : AbstractValidator<IRoundDTO>
  {
    public RoundDTOValidator(GameRepository gameRepository)
    {
      RuleFor(round => round.colorDTO).NotNull()
            .WithMessage("{PropertyName} - must be defined");
      RuleFor(round => round.game_id).NotNull()
            .WithMessage("{PropertyName} - must be defined").MustAsync(
        async (id, token) =>
        {
          var roundExists = await gameRepository.Exists(id);
          return !roundExists;
        }
      );
    }
  }
}