using FluentValidation;
using FluentValidation.AspNetCore;

namespace Spareparts.Application.Cars.Commands.CreateCar; 
public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>{



    public CreateCarCommandValidator() {
        RuleFor(x => x.ManufacturerId)
            .NotEmpty().WithMessage("ManufacturerId is required.")
            .Must(BeAValidGuid).WithMessage("ManufacturerId must be a valid GUID.");

    }

    private bool BeAValidGuid(Guid guid) {
        throw new NotImplementedException();
    }

    private bool BeAValidGuid(string guid) {
        return Guid.TryParse(guid, out _);
    }
}
