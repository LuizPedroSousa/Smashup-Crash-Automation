using System.ComponentModel.DataAnnotations;
using Smashup.Domain.Shared;
using FluentValidation;

namespace Smashup.Application.Exceptions
{
  public class ValidationException : BaseException
  {

    public ValidationException(ValidationResult validationResult) : base($"Validation error - {validationResult.ErrorMessage}")
    {


    }
  }
}