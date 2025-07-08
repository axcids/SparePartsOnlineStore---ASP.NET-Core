using FluentValidation;

namespace Spareparts.Application.Categories.Commands.CreateNewCategory; 
public class CreateNewCategoryCommandValidator : AbstractValidator<CreateNewCategoryCommand> {

    public CreateNewCategoryCommandValidator() { 
        
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
