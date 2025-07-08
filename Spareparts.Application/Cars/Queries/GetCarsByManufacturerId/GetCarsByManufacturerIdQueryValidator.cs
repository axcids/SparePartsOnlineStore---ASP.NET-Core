using FluentValidation;

namespace Spareparts.Application.Cars.Queries.GetCarsByManufacturerId; 
public class GetCarsByManufacturerIdQueryValidator : AbstractValidator<GetCarsByManufacturerIdQuery> {
    public GetCarsByManufacturerIdQueryValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .Must(id => id != Guid.Empty).WithMessage("{PropertyName} must be a valid GUID.");
    }
}
