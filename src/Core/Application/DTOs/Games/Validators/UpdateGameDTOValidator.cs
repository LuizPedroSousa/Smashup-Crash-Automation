using FluentValidation;

namespace Smashup.Application.DTOs.Games.Validators
{
  public class UpdateGameDTOValidator : AbstractValidator<UpdateGameDTO>
  {
    public UpdateGameDTOValidator() => RuleFor(game => game.name).NotEmpty()
          .NotNull()
          .WithMessage("{PropertyName} - is required")
          .MinimumLength(3)
          .WithMessage("{PropertyName} - minimum length is {ComparisonValue}");
  }
}