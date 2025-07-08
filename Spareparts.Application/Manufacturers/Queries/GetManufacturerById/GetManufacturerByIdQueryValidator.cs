using FluentValidation;

namespace Spareparts.Application.Manufacturers.Queries.GetManufacturerById; 
public class GetManufacturerByIdQueryValidator : AbstractValidator<GetManufacturerByIdQuery> {
    public GetManufacturerByIdQueryValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
    }
}
