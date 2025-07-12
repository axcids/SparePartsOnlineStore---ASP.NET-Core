using FluentValidation;

namespace Spareparts.Application.Products.Commands.CreateNewProduct;
public class CreateNewProductCommandValidator : AbstractValidator<CreateNewProductCommand> {
    public CreateNewProductCommandValidator() {
        RuleFor(command => command.CarId)
            .NotEmpty().WithMessage("Car ID is required.")
            .NotNull().WithMessage("Car ID cannot be null.")
            .NotEqual(Guid.Empty).WithMessage("Car ID cannot be empty.");
        RuleFor(command => command.SupplierId)
            .NotEmpty().WithMessage("Supplier ID is required.")
            .NotNull().WithMessage("Supplier ID cannot be null.")
            .NotEqual(Guid.Empty).WithMessage("Supplier ID cannot be empty.");
        RuleFor(command => command.CategoryId)
            .NotEmpty().WithMessage("Category ID is required.")
            .NotNull().WithMessage("Category ID cannot be null.")
            .NotEqual(Guid.Empty).WithMessage("Category ID cannot be empty.");
        RuleFor(command => command.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .NotNull().WithMessage("Product name cannot be null.")
            .MinimumLength(2).WithMessage("Product name must be at least 2 characters long.")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");
        RuleFor(command => command.Description)
            .NotEmpty().WithMessage("Product description is required.")
            .NotNull().WithMessage("Product description cannot be null.")
            .MinimumLength(10).WithMessage("Product description must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Product description cannot exceed 500 characters.");
        RuleFor(command => command.UPC)
            .NotEmpty().WithMessage("UPC is required.")
            .NotNull().WithMessage("UPC cannot be null.");
            //.Matches(@"^\d{12,13}$").WithMessage("UPC must be 12 or 13 digits long."); Nedd to fix or compelet this later 
        RuleFor(command => command.Price)
            .NotEmpty().WithMessage("Price is required.")
            .NotNull().WithMessage("Price cannot be null.")
            .GreaterThan(0).WithMessage("Price must be greater than zero.");
        RuleFor(command => command.WeightInKg)
            .NotEmpty().WithMessage("Weight is required.")
            .NotNull().WithMessage("Weight cannot be null.")
            .GreaterThan(0).WithMessage("Weight must be greater than zero.");
        RuleFor(command => command.Dimensions)
            .NotEmpty().WithMessage("Dimensions are required.")
            .NotNull().WithMessage("Dimensions cannot be null."); // Complete this or fix later 
                                                                  //.Matches(@"^\d+x\d+x\d+$").WithMessage("Dimensions must be in the format 'length x width x height'.");
        RuleFor(command => command.Material)
        .NotEmpty().WithMessage("Material is required.")
        .NotNull().WithMessage("Material cannot be null.")
        .MinimumLength(2).WithMessage("Material must be at least 2 characters long.")
        .MaximumLength(200).WithMessage("Material cannot exceed 500 characters.");
        RuleFor(command => command.HasWarranty)
            .NotNull().WithMessage("Warranty status cannot be null.");
        RuleFor(command => command.WarrantyPeriodInMonths)
            .GreaterThanOrEqualTo(0).WithMessage("Warranty period must be zero or greater.")
            .When(command => command.HasWarranty); // Only validate if HasWarranty is true

    }
}
