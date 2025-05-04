using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Commands.CreateCar; 
public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>{

    public CreateCarCommandValidator() {


        RuleFor(x => x.ManufacturerId)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.");

        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 100 characters.")
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long.");
        RuleFor(x => x.ModelYear)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null.")
            .InclusiveBetween(2000, DateTime.Now.Year).WithMessage($"{{PropertyName}} must be between 2000 and {DateTime.Now.Year}.");
        RuleFor(x => x.TrimLevel)
            .MaximumLength(255).WithMessage("{PropertyName} must not exceed 255 characters.")
            .MinimumLength(2).WithMessage("{PropertyName} must be at least 2 characters long.");
        RuleFor(x => x.BodyStyle)
            .NotEmpty().WithMessage("BodyStyle is required.")
            .NotNull().WithMessage("BodyStyle cannot be null")
            .Must(x => Enum.IsDefined(typeof(BodyStyleEnum), x)).WithMessage("{PropertyName} '{PropertyValue}' is not a valid enum value.");
        RuleFor(x => x.TransmissionType)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} cannot be null")
            .Must(x => Enum.IsDefined(typeof(TransmissionTypeEnum), x)).WithMessage("{PropertyName} '{PropertyValue}' is not a valid enum value.");
        RuleFor(x => x.FuelType)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull().WithMessage("{PropertyName} be null")
            .Must(x => Enum.IsDefined(typeof(FuelTypeEnum), x)).WithMessage("{PropertyName} '{PropertyValue}' is not a valid enum value.");
    }
}
