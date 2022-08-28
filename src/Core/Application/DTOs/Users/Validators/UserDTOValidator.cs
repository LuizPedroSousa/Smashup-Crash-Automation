using FluentValidation;

namespace Smashup.Application.DTOs.Users.Validators
{
  public class UserDTOValidator : AbstractValidator<IUserDTO>
  {
    public UserDTOValidator()
    {
      RuleFor(user => user.username)
        .NotEmpty()
        .WithMessage("{PropertyName} - precisa ser preenchido")
        .MinimumLength(6)
        .WithMessage("{PropertyName} - precisa ter no minimo {MinLength} digitos");
      RuleFor(user => user.password).NotNull()
        .NotEmpty()
        .WithMessage("{PropertyName} - precisa ser preenchido")
        .MinimumLength(6)
        .WithMessage("{PropertyName} - precisa ter no minimo {MinLength} digitos");
    }
  }
}