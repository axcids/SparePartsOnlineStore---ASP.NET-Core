using MediatR;
using Spareparts.Application.Cars.Dtos;
using System.Text.Json.Serialization;

namespace Spareparts.Application.Cars.Commands.UpdateCarCommand; 
public class UpdateCarCommand : IRequest<CarsDtos>{
    [JsonIgnore]
    public Guid Id { get; set; }
    public Guid ManufacturerId { get; set; }
    public string Model { get; set; } 
    public int ModelYear { get; set; }
    public string? TrimLevel { get; set; }    
    public string? BodyStyle { get; set; }
    public string? TransmissionType { get; set; } 
    public string? FuelType { get; set; } 

}
