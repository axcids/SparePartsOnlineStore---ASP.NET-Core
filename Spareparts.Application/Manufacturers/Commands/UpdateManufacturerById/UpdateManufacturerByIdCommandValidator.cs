using FluentValidation;

namespace Spareparts.Application.Manufacturers.Commands.UpdateManufacturerById; 
public class UpdateManufacturerByIdCommandValidator : AbstractValidator<UpdateManufacturerByIdCommand> {
    public UpdateManufacturerByIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
    }
}
