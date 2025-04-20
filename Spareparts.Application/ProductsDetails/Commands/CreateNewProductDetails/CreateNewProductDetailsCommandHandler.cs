using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.ProductsDetails.Commands.CreateNewProductDetails {
    internal class CreateNewProductDetailsCommandHandler(IProductDetailsRepository productDetails, ICarProductRepository carsProduct, ISupplierProductRepository supplierProduct, ILogger<CreateNewProductDetailsCommandHandler> logger) : IRequestHandler<CreateNewProductDetailsCommand, Guid> {
        public async Task<Guid> Handle(CreateNewProductDetailsCommand request, CancellationToken cancellationToken) {
            var entity = new ProductDetails {
                CategoryId = request.CategoryId,
                //SupplierId = request.SupplierId,
                Name = request.Name,
                Description = request.Description,
                UPC = request.UPC,
                Price = request.Price,
                WeightInKg = request.WeightInKg,
                Dimensions = request.Dimensions,
                Material = request.Material,
                HasWarranty = request.HasWarranty,
                WarrantyPeriodInMonths = request.WarrantyPeriodInMonths,
            };
            var id = await productDetails.AddNewProductDetails(entity);
            var CarProductEntity = new CarProduct {
                CarId = request.CarId,
                ProductId = id,
            };
            var CarProductId = await carsProduct.AddNewCarProduct(CarProductEntity);
            var suppliersProductEntity = new SupplierProduct {
                SupplierId = request.SupplierId,
                ProductId = id
            };
            // Repository 
            var SupplierProductId = await supplierProduct.AddNewSupplierProduct(suppliersProductEntity);
            return id;
        }
    }
}
