using FluentValidation;

namespace Spareparts.Application.Suppliers.Commands.CreateNewSupplier;
public class CreateNewSupplierCommandValidator : AbstractValidator<CreateNewSupplierCommand> {
    public CreateNewSupplierCommandValidator() {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("User ID is required.")
            .NotNull().WithMessage("User ID cannot be null.")
            .NotEqual(Guid.Empty).WithMessage("User ID cannot be empty.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Supplier name is required.")
            .NotNull().WithMessage("Supplier name cannot be null.")
            .MinimumLength(3).WithMessage("Supplier name must be at least 3 characters long.")
            .MaximumLength(200).WithMessage("Supplier name must not exceed 200 characters.");
        RuleFor(x => x.SupplierCode)
            .NotEmpty().WithMessage("Supplier code is required.")
            .NotNull().WithMessage("Supplier code cannot be null.")
            .MinimumLength(3).WithMessage("Supplier code must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Supplier code must not exceed 50 characters.");
        RuleFor(x => x.SupplierType)
            .NotEmpty().WithMessage("Supplier type is required.")
            .NotNull().WithMessage("Supplier type cannot be null.")
            .MinimumLength(3).WithMessage("Supplier type must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Supplier type must not exceed 50 characters.");
        RuleFor(x => x.ContactEmail)
            .NotEmpty().WithMessage("Contact email is required.")
            .NotNull().WithMessage("Contact email cannot be null.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.ContactPhone)
            .NotEmpty().WithMessage("Contact phone is required.")
            .MinimumLength(10).WithMessage("Contact phone must be at least 10 characters long.")
            .MaximumLength(15).WithMessage("Contact phone must not exceed 15 characters.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid phone number format.");
        RuleFor(x => x.Website)
            .MinimumLength(5).WithMessage("Website must be at least 5 characters long.")
            .MaximumLength(200).WithMessage("Website must not exceed 200 characters.")
            .When(x => !string.IsNullOrEmpty(x.Website)); // Optional field, validate only if provided
        RuleFor(x => x.IsActive)
            .NotNull().WithMessage("IsActive status is required.")
            .Must(x => x == true || x == false).WithMessage("IsActive must be a boolean value (true or false).");
        RuleFor(x => x.AddressLine1)
            .NotEmpty().WithMessage("Address line 1 is required.")
            .NotNull().WithMessage("Address line 1 cannot be null.")
            .MinimumLength(5).WithMessage("Address line 1 must be at least 5 characters long.")
            .MaximumLength(200).WithMessage("Address line 1 must not exceed 200 characters.");
        RuleFor(x => x.AddressLine2)
            .MaximumLength(200).WithMessage("Address line 2 must not exceed 200 characters.")
            .When(x => !string.IsNullOrEmpty(x.AddressLine2)); // Optional field, validate only if provided
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .NotNull().WithMessage("City cannot be null.")
            .MinimumLength(3).WithMessage("City must be at least 3 characters long")
            .MaximumLength(100).WithMessage("City must not exceed 100 characters.");
        RuleFor(x => x.StateOrProvince)
            .NotEmpty().WithMessage("State or Province is required.")
            .NotNull().WithMessage("StateOrProvince cannot be null.")
            .MinimumLength(3).WithMessage("StateOrProvince must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("State or Province must not exceed 100 characters.");
        RuleFor(x => x.PostalCode)
            .NotEmpty().WithMessage("Postal code is required.")
            .NotNull().WithMessage("PostalCode cannot be null.")
            //.MinimumLength(5).WithMessage("PostalCode must be at least 5 characters long.")
            //.MaximumLength(5)
            .Matches(@"^\d{5}(-\d{4})?$").WithMessage("Invalid postal code format.");
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MinimumLength(3).WithMessage("Country must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Country must not exceed 100 characters.");

    }
}
