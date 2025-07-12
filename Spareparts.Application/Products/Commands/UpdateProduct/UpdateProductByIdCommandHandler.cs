using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Products.Commands.UpdateProduct;
public class UpdateProductByIdCommandHandler(IProductRepository productRepository, ILogger<UpdateProductByIdCommandHandler> logger) : IRequestHandler<UpdateProductByIdCommand, bool> {
    public async Task<bool> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken) {

        var isExist = await productRepository.GetProductById(request.Id);
        if ((isExist == null)) {
            return false;
        }
        var updatedProduct = new Product {
            Id = request.Id, // Ensure the product ID is set for update
            CategoryId = request.CategoryId,
            Name = request.Name,
            Description = request.Description,
            UPC = request.UPC,
            Price = request.Price,
            WeightInKg = request.WeightInKg,
            Dimensions = request.Dimensions,
            Material = request.Material,
            HasWarranty = request.HasWarranty,
            WarrantyPeriodInMonths = request.WarrantyPeriodInMonths,
            UpdatedAt = DateTime.UtcNow,
        };
        var isUpdate = await productRepository.UpdateProduct(updatedProduct);
        return isUpdate;
    }
}
