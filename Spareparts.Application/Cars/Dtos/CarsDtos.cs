using Spareparts.Domain.Entities;
using static Spareparts.Domain.Entities.Enums.CarEnums;


namespace Spareparts.Application.Cars.Dtos; 
public class CarsDtos {

    // Unique identifier for the car
    public Guid Id { get; set; }
    public Guid ManufacturerId { get; set; }
    public string Model { get; set; }         // e.g., Corolla, Civic
    public int ModelYear { get; set; }        // e.g., 2020, 2021
    public string? TrimLevel { get; set; }     // e.g., SE, EX, Premium
    public BodyStyleEnum BodyStyle { get; set; }     // e.g., Sedan, Hatchback, SUV
    public TransmissionTypeEnum TransmissionType { get; set; } // e.g., Manual, Automatic, CVT
    public FuelTypeEnum FuelType { get; set; }      // e.g., Gasoline, Diesel, Electric, 

    public static CarsDtos? FromEntity(Car? car) {
        if (car == null) return null;
        return new CarsDtos() {
            Id = car.Id,
            ManufacturerId = car.ManufacturerId,
            Model = car.Model,
            ModelYear = car.ModelYear,
            TrimLevel = car.TrimLevel,
            BodyStyle = car.BodyStyle,
            TransmissionType = car.TransmissionType,
            FuelType = car.FuelType,
        };
    }


}
