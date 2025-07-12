using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Products.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Products.Queries.GetAllProducts;
public class GetAllProductsQueryHandler(IProductRepository productRepository, ILogger<GetAllProductsQueryHandler> logger) : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>> {
    public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken) {
        var allProducts = await productRepository.GetAllProducts();
        var productDtos = allProducts.Select(ProductDto.FromEntity).ToList();
        return productDtos;
    }
}
