using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Products.Commands.CreateNewProduct;
public class CreateNewProductCommandHandler(IProductRepository productRepository, ILogger<CreateNewProductCommandHandler> logger) : IRequestHandler<CreateNewProductCommand, Guid> {
    public async Task<Guid> Handle(CreateNewProductCommand request, CancellationToken cancellationToken) {
        
        var entity = new Product {
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

            CarsProducts = new List<CarProduct>() {
                    new CarProduct() {
                        CarId=request.CarId,
                    }
                },
            SupplierProdouct = new List<SupplierProduct>() {
                    new SupplierProduct() {
                        SupplierId = request.SupplierId,
                    }
                }
        };
        var id = await productRepository.AddNewProduct(entity);
        return id;
    }
}
