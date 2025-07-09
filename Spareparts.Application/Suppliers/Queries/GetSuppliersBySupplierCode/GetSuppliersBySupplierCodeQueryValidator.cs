using FluentValidation;

namespace Spareparts.Application.Suppliers.Queries.GetSuppliersBySupplierCode; 
public class GetSuppliersBySupplierCodeQueryValidator : AbstractValidator<GetSuppliersBySupplierCodeQuery>{
    public GetSuppliersBySupplierCodeQueryValidator() {
        RuleFor(x => x.SupplierCode)
            .NotEmpty().WithMessage("SupplierCode is required.")
            .NotNull().WithMessage("SupplierCode cannot be null.");
        //Fix/Complete this later 

    }
}
