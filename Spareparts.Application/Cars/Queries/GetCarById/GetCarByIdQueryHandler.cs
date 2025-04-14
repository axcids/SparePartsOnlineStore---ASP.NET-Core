using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Cars.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Queries.GetCarById;
internal class GetCarByIdQueryHandler(ICarRepository carRepository, ILogger<GetCarByIdQueryHandler> logger) : IRequestHandler<GetCarByIdQuery, CarsDtos> {
    public async Task<CarsDtos> Handle(GetCarByIdQuery request, CancellationToken cancellationToken) {
        var car = await carRepository.GetCarById(request.Id);
        var carDto = CarsDtos.FromEntity(car);
        return carDto;
    }
}
