using FluentValidation;

namespace Spareparts.Application.Categories.Commands.UpdateCategoryById; 
public class UpdateCategoryByIdCommandValidator : AbstractValidator<UpdateCategoryByIdCommand> {
    public UpdateCategoryByIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.")
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .MaximumLength(500).WithMessage("{PropertyName} must not exceed 500 characters.")
            .MinimumLength(5).WithMessage("{PropertyName} must be at least 5 characters long.");

    }
}
