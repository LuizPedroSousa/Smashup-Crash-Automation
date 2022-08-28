using FluentValidation;

namespace Smashup.Application.DTOs.Users.Validators
{
  public class UpdateUserDTOValidator : AbstractValidator<UpdateUserDTO>
  {
    public UpdateUserDTOValidator()
    {
      Include(new UserDTOValidator());
      RuleFor(user => user.id).NotEmpty().NotNull().WithMessage("{PropertyName} must be defined");
    }
  }
}
