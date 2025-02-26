using MediatR;

namespace Spareparts.Application.Cars.Commands.CreateCar; 
public class CreateCarCommand : IRequest<Guid> {
    public Guid ManufacturerId { get; set; }
    public string Model { get; set; }         // e.g., Corolla, Civic
    public int ModelYear { get; set; }        // e.g., 2020, 2021
    public string? TrimLevel { get; set; }     // e.g., SE, EX, Premium
    public string? BodyStyle { get; set; }     // e.g., Sedan, Hatchback, SUV
    public string? TransmissionType { get; set; } // e.g., Manual, Automatic, CVT
    public string? FuelType { get; set; }      // e.g., Gasoline, Diesel, Electric, 

}
