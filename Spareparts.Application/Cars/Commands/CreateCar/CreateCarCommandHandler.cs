using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using static Spareparts.SharedKernal.Enums.CarEnums;

namespace Spareparts.Application.Cars.Commands.CreateCar;
public class CreateCarCommandHandler(IManufacturerRepository manufacturerRepository, ICarRepository carRepository, ILogger<CreateCarCommandHandler> logger) : IRequestHandler<CreateCarCommand, Guid> {
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken) {
        // Convert Enum values to lower case 
        string newBodyStyle = request.BodyStyle.ToLower();
        string newTransmissionType = request.TransmissionType.ToLower();
        string newFuelType = request.FuelType.ToLower();
        // Convert Enum values from string to enum type 
        BodyStyleEnum bodyStyleEnum = Enum.Parse<BodyStyleEnum>(newBodyStyle);
        TransmissionTypeEnum transmissionTypeEnum = Enum.Parse<TransmissionTypeEnum>(newTransmissionType);
        FuelTypeEnum fuelTypeEnum = Enum.Parse<FuelTypeEnum>(newFuelType);
        //Check if the manufacturer exist or not 
        var manufacturerExist = await manufacturerRepository.GetManufacturerById(request.ManufacturerId);
        if (manufacturerExist == default) {
            throw new Exception("Manufacturer ID does not exist.");
        }
        // Create a new instance of Car entity 
        var car = new Car {
            ManufacturerId = request.ManufacturerId,
            Model = request.Model,
            ModelYear = request.ModelYear,
            TrimLevel = request.TrimLevel,
            BodyStyle = bodyStyleEnum,
            TransmissionType = transmissionTypeEnum,
            FuelType = fuelTypeEnum,
        };
        // Insert the new car in the database 
        var id = await carRepository.AddNewCar(car);
        return id;
    }
}
