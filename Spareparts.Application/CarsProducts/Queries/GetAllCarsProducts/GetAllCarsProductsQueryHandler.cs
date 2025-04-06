using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.CarsProducts.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.CarsProducts.Queries.GetAllCarsProducts;
public class GetAllCarsProductsQueryHandler(ICarProductRepository carProductRepository, ILogger<GetAllCarsProductsQueryHandler> logger) : IRequestHandler<GetAllCarsProductsQuery, IEnumerable<CarProductDtos>> {
    public async Task<IEnumerable<CarProductDtos>> Handle(GetAllCarsProductsQuery request, CancellationToken cancellationToken) {
        var CarsProducts = await carProductRepository.GetAllCarsProducts();
        var CarsProductsDtos = CarsProducts.Select(CarProductDtos.FromEntity).ToList();
        return CarsProductsDtos;
    }
}
