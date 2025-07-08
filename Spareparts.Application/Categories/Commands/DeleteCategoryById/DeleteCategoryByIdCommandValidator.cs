using FluentValidation;

namespace Spareparts.Application.Categories.Commands.DeleteCategoryById;
public class DeleteCategoryByIdCommandValidator : AbstractValidator<DeleteCategoryByIdCommand> {
    public DeleteCategoryByIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
    }
}
