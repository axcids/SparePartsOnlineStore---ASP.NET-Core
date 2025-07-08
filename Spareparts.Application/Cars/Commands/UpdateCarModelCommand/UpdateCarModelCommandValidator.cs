using FluentValidation;
using Spareparts.Application.Cars.Commands.UpdateCarNameCommand;

namespace Spareparts.Application.Cars.Commands; 
public class UpdateCarModelCommandValidator : AbstractValidator<UpdateCarModelCommand> {
    public UpdateCarModelCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.");
        RuleFor(x => x.Model)
            .NotEmpty().WithMessage("Model is required.")
            .MaximumLength(100).WithMessage("Model must not exceed 100 characters.");
    }
}
