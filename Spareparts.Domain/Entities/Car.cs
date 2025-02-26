namespace Spareparts.Domain.Entities;
public class Car {
    // Unique identifier for the car
    public Guid Id { get; set; }

    // General car information
    public Guid ManufacturerId { get; set; }
    public virtual Manufacturer Manufacturers { get; set; }
    public string Model { get; set; }         // e.g., Corolla, Civic
    public int ModelYear { get; set; }        // e.g., 2020, 2021

    // Optional details
    public string? TrimLevel { get; set; }     // e.g., SE, EX, Premium
    public string? BodyStyle { get; set; }     // e.g., Sedan, Hatchback, SUV
    public string? TransmissionType { get; set; } // e.g., Manual, Automatic, CVT
    public string? FuelType { get; set; }      // e.g., Gasoline, Diesel, Electric, Hybrid

    // Timestamps for creation and updates
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime UpdatedDate { get; set; } = DateTime.Now;

}
