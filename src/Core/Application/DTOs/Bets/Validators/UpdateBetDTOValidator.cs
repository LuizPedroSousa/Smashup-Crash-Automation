using FluentValidation;

namespace Smashup.Application.DTOs.Bets.Validators
{
  public class UpdateBetDTOValidator : AbstractValidator<UpdateBetDTO>
  {
    public UpdateBetDTOValidator()
    {
      RuleFor(bet => bet.amount).NotNull().GreaterThan(1)
            .WithMessage("{PropertyName} - must be greater than or equal to {ComparisonValue}");

      RuleFor(bet => bet.status).NotEmpty()
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} - is required");
    }
  }
}