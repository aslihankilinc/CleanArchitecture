using FluentValidation;

namespace CleanArchitecture.Application.Features.Office.Command.CreateOffice
{
    public class CreateOfficeCommandValidator:AbstractValidator<CreateOfficeCommand>
    {
        public CreateOfficeCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Office name is required.");
        }
    }
}
