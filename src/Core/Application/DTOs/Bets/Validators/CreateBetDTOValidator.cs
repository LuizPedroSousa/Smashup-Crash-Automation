using FluentValidation;

namespace Smashup.Application.DTOs.Bets.Validators
{
  public class CreateBetDTOValidator : AbstractValidator<CreateBetDTO>
  {
    public CreateBetDTOValidator()
    {
      RuleFor(bet => bet.amount).NotNull().GreaterThan(1)
            .WithMessage("{PropertyName} - must be greater than or equal to {ComparisonValue}");

      RuleFor(bet => bet.roundId).NotEmpty()
            .NotNull()
            .NotEmpty()
            .WithMessage("{PropertyName} - is required");
    }
  }
}