using FluentValidation;

namespace Spareparts.Application.Manufacturers.Commands.CreateNewManufacturer; 
public class CreateNewManufacturerCommandValidator : AbstractValidator<CreateNewManufacturerCommand> {
    public CreateNewManufacturerCommandValidator() {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters long.")
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.");
        RuleFor(x => x.Logo)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters long.")
            .MaximumLength(200).WithMessage("{PropertyName} must not exceed 200 characters.");
    }
}
