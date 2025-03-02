using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Cars.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Queries.GetAllCars;
public class GetAllCarsQueryHandler(ICarRepository carRepository, ILogger<GetAllCarsQuery> logger) : IRequestHandler<GetAllCarsQuery, IEnumerable<CarsDtos>> {
    public async Task<IEnumerable<CarsDtos>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken) {
        var cars = await carRepository.GetAllcars();
        var carsDtos = cars.Select(CarsDtos.FromEntity).ToList();
        return carsDtos;
    }
}
