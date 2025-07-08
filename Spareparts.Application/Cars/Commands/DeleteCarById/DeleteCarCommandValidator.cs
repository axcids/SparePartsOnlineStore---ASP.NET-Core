using FluentValidation;

namespace Spareparts.Application.Cars.Commands.DeleteCarById; 
public class DeleteCarByManufacturerIdCommandValidator : AbstractValidator<DeleteCarCommand>{
    public DeleteCarByManufacturerIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");
    }
}
