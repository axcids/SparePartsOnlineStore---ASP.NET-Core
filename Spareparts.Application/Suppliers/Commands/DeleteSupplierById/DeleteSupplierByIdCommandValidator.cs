using FluentValidation;

namespace Spareparts.Application.Suppliers.Commands.DeleteSupplierById; 
public class DeleteSupplierByIdCommandValidator : AbstractValidator<DeleteSupplierByIdCommand>{
    public DeleteSupplierByIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID cannot be null.")
            .NotEqual(Guid.Empty).WithMessage("ID cannot be empty.");
    }
}
