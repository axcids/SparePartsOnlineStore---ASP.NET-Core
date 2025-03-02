using MediatR;
using Spareparts.Application.Cars.Dtos;

namespace Spareparts.Application.Cars.Queries.GetAllCars; 
public class GetAllCarsQuery : IRequest<IEnumerable<CarsDtos>> {

}
