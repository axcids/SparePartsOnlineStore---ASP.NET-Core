using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.ProductsDetails.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.ProductsDetails.Queries.GetAllProductsDetails;
public class GetAllProductsDetailsQueryHandler(IProductDetailsRepository productDetails, ILogger<GetAllProductsDetailsQueryHandler> logger) : IRequestHandler<GetAllProductsDetailsQuery, IEnumerable<ProductsDetailsDtos>> {
    public async Task<IEnumerable<ProductsDetailsDtos>> Handle(GetAllProductsDetailsQuery request, CancellationToken cancellationToken) {
        var productsDetails = await productDetails.GetAllProducts();
        var productsDetailsDtos = productsDetails.Select(ProductsDetailsDtos.FromEntity).ToList();
        return productsDetailsDtos;
    }
}
