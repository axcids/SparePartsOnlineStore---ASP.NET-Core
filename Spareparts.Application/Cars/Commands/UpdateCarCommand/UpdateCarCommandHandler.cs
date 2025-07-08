using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Cars.Dtos;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using static Spareparts.Domain.Entities.Enums.CarEnums;

namespace Spareparts.Application.Cars.Commands.UpdateCarCommand;
public class UpdateCarCommandHandler(ICarRepository carRepository, ILogger<UpdateCarCommandHandler> logger) : IRequestHandler<UpdateCarCommand, CarsDtos> {
    public async Task<CarsDtos> Handle(UpdateCarCommand request, CancellationToken cancellationToken) {

        BodyStyleEnum bodyStyleEnum = Enum.Parse<BodyStyleEnum>(request.BodyStyle);
        TransmissionTypeEnum transmissionTypeEnum = Enum.Parse<TransmissionTypeEnum>(request.TransmissionType);
        FuelTypeEnum fuelTypeEnum = Enum.Parse<FuelTypeEnum>(request.FuelType);

        var car = await carRepository.GetCarById(request.Id);

        if (car != null && car.Id == request.Id) {
            Car newCar = new Car {
                Id = request.Id,
                ManufacturerId = request.ManufacturerId,
                Model = request.Model,
                ModelYear = request.ModelYear,
                TrimLevel = request.TrimLevel,
                BodyStyle = bodyStyleEnum,
                TransmissionType = transmissionTypeEnum,
                FuelType = fuelTypeEnum
            };
            await carRepository.UpdateCarById(request.Id, newCar);
            var carDto = CarsDtos.FromEntity(car);
            return carDto;
        }else {
            logger.LogError("Car not found");
            return null;
        }
    }
}
