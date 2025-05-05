using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Cars.Commands.CreateCar;
public class CreateCarCommandHandler(IManufacturerRepository manufacturerRepository, ICarRepository carRepository, ILogger<CreateCarCommandHandler> logger) : IRequestHandler<CreateCarCommand, Guid> {
    public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken) {
        
        BodyStyleEnum bodyStyle = Enum.Parse<BodyStyleEnum>(request.BodyStyle);
        TransmissionTypeEnum transmissionType = Enum.Parse<TransmissionTypeEnum>(request.TransmissionType);
        FuelTypeEnum fuelType = Enum.Parse<FuelTypeEnum>(request.FuelType);

        var manufacturerExist = await manufacturerRepository.GetManufacturerById(request.ManufacturerId);
        if(manufacturerExist is null) {
            throw new ArgumentException("Manufacturer ID is not Valid");
        }

        var car = new Car {
            ManufacturerId = request.ManufacturerId,
            Model = request.Model,
            ModelYear = request.ModelYear,
            TrimLevel = request.TrimLevel,
            BodyStyle = bodyStyle,
            TransmissionType = transmissionType,
            FuelType = fuelType,
        };
        var id = await carRepository.AddNewCar(car);
        return id;
    }
}
