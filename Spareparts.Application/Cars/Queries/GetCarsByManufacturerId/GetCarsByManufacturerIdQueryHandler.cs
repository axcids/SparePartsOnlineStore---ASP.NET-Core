using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Cars.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Queries.GetCarsByManufacturerId;
public class GetCarsByManufacturerIdQueryHandler(ICarRepository carRepository, ILogger<GetCarsByManufacturerIdQueryHandler> logger) : IRequestHandler<GetCarsByManufacturerIdQuery, IEnumerable<CarsDtos>> {
    public async Task<IEnumerable<CarsDtos>> Handle(GetCarsByManufacturerIdQuery request, CancellationToken cancellationToken) {
        var allCars = await carRepository.GetCarsByManufacturerId(request.Id);
        var allCarsDtos = allCars.Select(CarsDtos.FromEntity).ToList();
        return allCarsDtos;
    }
}
