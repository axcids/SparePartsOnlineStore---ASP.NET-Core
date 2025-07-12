using FluentValidation;

namespace Spareparts.Application.Products.Commands.UpdateProduct; 
public class UpdateProductCommandValidator : AbstractValidator<UpdateProductByIdCommand>{

    public UpdateProductCommandValidator() { 
        
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product ID is required.")
            .NotNull().WithMessage("Product ID cannot be null.");
        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category ID is required.")
            .NotNull().WithMessage("Category ID cannot be null.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .NotNull().WithMessage("Product name cannot be null.")
            .MinimumLength(3).WithMessage("Product name must be at least 3 characters long.")
            .MaximumLength(100).WithMessage("Product name must not exceed 100 characters.");
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Product description is required.")
            .NotNull().WithMessage("Product description cannot be null.")
            .MinimumLength(10).WithMessage("Product description must be at least 10 characters long.")
            .MaximumLength(500).WithMessage("Product description must not exceed 500 characters.");
        RuleFor(x => x.UPC)
            .NotEmpty().WithMessage("Product UPC is required.")
            .NotNull().WithMessage("Product UPC cannot be null.");
            //.Matches(@"^\d{12,13}$").WithMessage("Product UPC must be a 12 or 13 digit number."); fix this later
        RuleFor(x => x.Price)
            .NotEmpty().WithMessage("Product price is required.")
            .NotNull().WithMessage("Product price cannot be null.")
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");
        RuleFor(x => x.WeightInKg)
            .NotEmpty().WithMessage("Product weight is required.")
            .NotNull().WithMessage("Product weight cannot be null.")
            .GreaterThan(0).WithMessage("Product weight must be greater than zero.");
        RuleFor(x => x.Dimensions)
            .NotEmpty().WithMessage("Product dimensions are required.")
            .NotNull().WithMessage("Product dimensions cannot be null.")
            .MinimumLength(5).WithMessage("Product dimensions must be at least 5 characters long.")
            .MaximumLength(50).WithMessage("Product dimensions must not exceed 50 characters.");
        RuleFor(x => x.Material)
            .NotEmpty().WithMessage("Product material is required.")
            .NotNull().WithMessage("Product material cannot be null.")
            .MinimumLength(3).WithMessage("Product material must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("Product material must not exceed 50 characters.");
        RuleFor(x => x.HasWarranty)
            .NotNull().WithMessage("Warranty status cannot be null.");
        RuleFor(x => x.WarrantyPeriodInMonths)
            .NotNull().WithMessage("Warranty period cannot be null.")
            .GreaterThanOrEqualTo(0).WithMessage("Warranty period must be zero or greater.")
            .When(x => x.HasWarranty, ApplyConditionTo.CurrentValidator); // Only validate if HasWarranty is true
        RuleFor(x => x.UpdatedAt)
            .NotNull().WithMessage("UpdatedAt cannot be null.");


    }
}
