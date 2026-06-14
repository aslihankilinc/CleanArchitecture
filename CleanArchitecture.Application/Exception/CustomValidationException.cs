using System;


using FluentValidation.Results;
namespace CleanArchitecture.Application.Exception
{
    public class CustomValidationException:System.Exception
    {
        public List<string> ValidationErrors { get; set; } = [];
        public System.ComponentModel.DataAnnotations.ValidationResult ValidationResult { get; }

        public CustomValidationException(ValidationResult validationResult)
        {
            foreach (var validationError in validationResult.Errors)
            {
                ValidationErrors.Add(validationError.ErrorMessage);

            }
            
        }

      
    }
}
