using FluentValidation;

namespace Smashup.Application.DTOs.Users.Validators
{
  public class CreateUserDTOValidator : AbstractValidator<CreateUserDTO>
  {
    public CreateUserDTOValidator()
    {
      Include(new UserDTOValidator());
    }
  }
}