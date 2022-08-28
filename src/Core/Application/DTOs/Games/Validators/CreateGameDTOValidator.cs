using System.Data;
using FluentValidation;

namespace Smashup.Application.DTOs.Games.Validators
{
  public class CreateGameDTOValidator : AbstractValidator<CreateGameDTO>
  {
    public CreateGameDTOValidator() => RuleFor(game => game.name).NotEmpty()
          .NotNull()
          .WithMessage("{PropertyName} - is required")
          .MinimumLength(3)
          .WithMessage("{PropertyName} - minimum length is {ComparisonValue}");
  }
}