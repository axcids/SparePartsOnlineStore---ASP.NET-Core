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
    internal class CreateNewProductDetailsCommandHandler(IProductRepository productDetails, ILogger<CreateNewProductDetailsCommandHandler> logger) : IRequestHandler<CreateNewProductDetailsCommand, Guid> {
        public async Task<Guid> Handle(CreateNewProductDetailsCommand request, CancellationToken cancellationToken) {
          
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
                } ,
                SupplierProdouct = new List<SupplierProduct>() { 
                    new SupplierProduct() {
                        SupplierId = request.SupplierId,
                    } 
                }
            };
            var id = await productDetails.AddNewProductDetails(entity);
            return id;
        }
    }
}
