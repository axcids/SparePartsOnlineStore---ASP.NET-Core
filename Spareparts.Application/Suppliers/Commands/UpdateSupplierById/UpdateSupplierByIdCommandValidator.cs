using FluentValidation;

namespace Spareparts.Application.Suppliers.Commands.UpdateSupplierById; 
public class UpdateSupplierByIdCommandValidator : AbstractValidator<UpdateSupplierByIdCommand>{
    public UpdateSupplierByIdCommandValidator() {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters.")
            .MaximumLength(100).WithMessage("Name must not exceed 100 characters.")
            .Must(name => !string.IsNullOrWhiteSpace(name)).WithMessage("Name cannot be whitespace.");
        RuleFor(x => x.SupplierType)
            .NotEmpty().WithMessage("SupplierType is required.")
            .MaximumLength(50);
        RuleFor(x => x.ContactEmail)
            .NotEmpty().WithMessage("Contact Email is required.")
            .EmailAddress().WithMessage("Contact Email must be a valid email address.");
        RuleFor(x => x.ContactPhone)
            .NotEmpty().WithMessage("Contact Phone is required.")
            .Matches(@"^\+?\d{7,15}$").WithMessage("Contact Phone must be a valid phone number.");

        //RuleFor(x => x.Website)
        //    .Cascade(CascadeMode.Stop)
        //    .Must(string.IsNullOrWhiteSpace)
        //        .When(x => string.IsNullOrWhiteSpace(x.Website))
        //    .Otherwise(() => RuleFor(x => x.Website)  
        //        .Must(uri => {  
        //            if (string.IsNullOrWhiteSpace(uri)) return true;  
        //            return Uri.TryCreate(uri, UriKind.Absolute, out var tmp)  
        //                   && (tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps);  
        //        }).WithMessage("Website must be a valid URL (http or https)."));  
        //    .Must(uri => {
        //        if (string.IsNullOrWhiteSpace(uri)) return true;
        //        return Uri.TryCreate(uri, UriKind.Absolute, out var tmp)
        //               && (tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps);
        //    }).WithMessage("Website must be a valid URL (http or https

        RuleFor(x => x.AddressLine1)
            .NotEmpty().WithMessage("Address Line 1 is required.")
            .MaximumLength(200);
        RuleFor(x => x.AddressLine2)
            .MaximumLength(200)
            .When(x => !string.IsNullOrEmpty(x.AddressLine2));
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(100);
        RuleFor(x => x.StateOrProvince)
            .NotEmpty().WithMessage("State or Province is required.")
            .MaximumLength(100);
        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal Code is required.")
            .MaximumLength(20);
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(100);

        // IsActive: Always true or false (bool, so always valid unless you want custom rules)

        // UpdatedAt: Optional, if provided, must not be in the future
        //RuleFor(x => x.UpdatedAt)
        //    .LessThanOrEqualTo(DateTime.UtcNow)
        //    .When(x => x.UpdatedAt.HasValue)
        //    .WithMessage("UpdatedAt cannot be in the future.");
    }

}

