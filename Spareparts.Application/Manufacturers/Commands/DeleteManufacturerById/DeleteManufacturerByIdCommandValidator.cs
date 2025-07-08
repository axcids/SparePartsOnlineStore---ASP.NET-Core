using FluentValidation;

namespace Spareparts.Application.Manufacturers.Commands.DeleteManufacturerById; 
public class DeleteManufacturerByIdCommandValidator : AbstractValidator<DeleteManufacturerByIdCommand> {
    public DeleteManufacturerByIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
    }
}
