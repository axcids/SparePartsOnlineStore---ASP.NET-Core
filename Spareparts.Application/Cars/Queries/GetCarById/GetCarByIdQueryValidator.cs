using FluentValidation;

namespace Spareparts.Application.Cars.Queries.GetCarById; 
public class GetCarByIdQueryValidator : AbstractValidator<GetCarByIdQuery> {
    public GetCarByIdQueryValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
    }
}
