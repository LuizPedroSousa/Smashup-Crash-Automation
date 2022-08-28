using FluentValidation;

namespace Smashup.Application.DTOs.Users.Validators;

public class AuthenticateUserDTOValidator : AbstractValidator<AuthenticateUserDTO>
{
  public AuthenticateUserDTOValidator()
  {
    Include(new UserDTOValidator());
  }
}
