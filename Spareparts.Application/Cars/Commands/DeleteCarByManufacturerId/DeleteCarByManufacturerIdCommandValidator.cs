using FluentValidation;

namespace Spareparts.Application.Cars.Commands.DeleteCarByManufacturerId; 
public class DeleteCarByManufacturerIdCommandValidator : AbstractValidator<DeleteCarsByManufacturerIdCommand> {
    public DeleteCarByManufacturerIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");
    }
}
