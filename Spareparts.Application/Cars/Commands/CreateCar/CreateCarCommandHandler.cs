using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Commands.CreateCar;
public class CreateCarCommandHandler(ICarRepository carRepository, ILogger<CreateCarCommandHandler> logger) : IRequestHandler<CreateCarCommand, Guid> {
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken) {
        var car = new Car {
            ManufacturerId = request.ManufacturerId,
            Model = request.Model,
            ModelYear = request.ModelYear,
            TrimLevel = request.TrimLevel,
            BodyStyle = request.BodyStyle,
            TransmissionType = request.TransmissionType,
            FuelType = request.FuelType,
            UpdatedAt = null,
        };
        var id = await carRepository.AddNewCar(car);
        return id;
    }
}
