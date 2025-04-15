using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Cars.Dtos;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Commands.UpdateCarCommand;
public class UpdateCarCommandHandler(ICarRepository carRepository, ILogger<UpdateCarCommandHandler> logger) : IRequestHandler<UpdateCarCommand, CarsDtos> {
    public async Task<CarsDtos> Handle(UpdateCarCommand request, CancellationToken cancellationToken) {
        var car = await carRepository.GetCarById(request.Id);

        if (car != null && car.Id == request.Id) {
            Car newCar = new Car {
                Id = request.Id,
                ManufacturerId = request.ManufacturerId,
                Model = request.Model,
                ModelYear = request.ModelYear,
                TrimLevel = request.TrimLevel,
                BodyStyle = request.BodyStyle,
                TransmissionType = request.TransmissionType,
                FuelType = request.FuelType,
            };
            await carRepository.UpdateCarById(request.Id, newCar);
            await carRepository.SaveChanges();
            var carDto = CarsDtos.FromEntity(newCar);
            return carDto;
        }else {
            logger.LogError("Car not found");
            return null;
        }
    }
}
