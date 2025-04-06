using MediatR;
using Spareparts.Application.CarsProducts.Dtos;

namespace Spareparts.Application.CarsProducts.Queries.GetAllCarsProducts;
public class GetAllCarsProductsQuery : IRequest<IEnumerable<CarProductDtos>> {

}
