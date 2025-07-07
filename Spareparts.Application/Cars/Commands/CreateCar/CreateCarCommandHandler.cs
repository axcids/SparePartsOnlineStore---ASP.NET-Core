using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using static Spareparts.Domain.Entities.Enums.CarEnums;

namespace Spareparts.Application.Cars.Commands.CreateCar;
public class CreateCarCommandHandler(ICarRepository carRepository, ILogger<CreateCarCommandHandler> logger) : IRequestHandler<CreateCarCommand, Guid> {
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken) {
        
        BodyStyleEnum bodyStyleEnum = Enum.Parse<BodyStyleEnum>(request.BodyStyle);
        TransmissionTypeEnum transmissionTypeEnum = Enum.Parse<TransmissionTypeEnum>(request.TransmissionType);
        FuelTypeEnum fuelTypeEnum = Enum.Parse<FuelTypeEnum>(request.FuelType);

        var car = new Car {
            ManufacturerId = request.ManufacturerId,
            Model = request.Model,
            ModelYear = request.ModelYear,
            TrimLevel = request.TrimLevel,
            BodyStyle = bodyStyleEnum,
            TransmissionType = transmissionTypeEnum,
            FuelType = fuelTypeEnum,
        };
        var id = await carRepository.AddNewCar(car);
        return id;
    }
}
