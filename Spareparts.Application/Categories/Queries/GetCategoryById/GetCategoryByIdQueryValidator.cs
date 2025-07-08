using FluentValidation;

namespace Spareparts.Application.Categories.Queries.GetCategoryById; 
public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery> {

    public GetCategoryByIdQueryValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
    }
}
