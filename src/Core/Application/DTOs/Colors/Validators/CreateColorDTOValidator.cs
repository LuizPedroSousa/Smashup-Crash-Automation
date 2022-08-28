using System.Drawing;
using FluentValidation;

namespace Smashup.Application.DTOs.Colors.Validators;

public class CreateColorDTOValidator : AbstractValidator<CreateColorDTO>
{
  public CreateColorDTOValidator()
  {
    RuleFor(color => color.name).NotEmpty()
          .NotNull()
          .NotEmpty()
          .WithMessage("{PropertyName} - is required")
          .MinimumLength(3)
          .WithMessage("{PropertyName} - minimum length is {ComparisonValue}")
          .MaximumLength(10)
          .WithMessage("{PropertyName} - maximum length is {ComparisonValue}");

    RuleFor(color => color.gameId).NotEmpty()
          .NotNull()
          .NotEmpty()
          .WithMessage("{PropertyName} - is required");

  }
}
