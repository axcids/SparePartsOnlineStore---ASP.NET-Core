using FluentValidation;
using FluentValidation.Validators;

namespace Spareparts.Application.Products.Commands.DeleteProductById; 
public class DeleteProductByIdCommandValidator : AbstractValidator<DeleteProductByIdCommand>{
    public DeleteProductByIdCommandValidator() {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Product ID must not be empty.")
            .NotNull().WithMessage("Product ID must not be null.");
    }
}
