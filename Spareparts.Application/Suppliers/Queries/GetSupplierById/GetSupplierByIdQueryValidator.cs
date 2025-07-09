using FluentValidation;

namespace Spareparts.Application.Suppliers.Queries.GetSupplierById; 
public class GetSupplierByIdQueryValidator : AbstractValidator<GetSupplierByIdQuery>{
    public GetSupplierByIdQueryValidator() { 
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID is required.")
            .NotNull().WithMessage("ID cannot be null.")
            .NotEqual(Guid.Empty).WithMessage("ID cannot be empty.");
    }
}
