using MediatR;
using Spareparts.Application.Cars.Dtos;
using Spareparts.Domain.Entities;
using System.Text.Json.Serialization;

namespace Spareparts.Application.Cars.Commands.UpdateCarCommand; 
public class UpdateCarCommand : IRequest<CarsDtos>{
    [JsonIgnore]
    public Guid Id { get; set; }
    public Guid ManufacturerId { get; set; }
    public string Model { get; set; } 
    public int ModelYear { get; set; }
    public string? TrimLevel { get; set; }    
    public BodyStyleEnum BodyStyle { get; set; }
    public TransmissionTypeEnum TransmissionType { get; set; } 
    public FuelTypeEnum FuelType { get; set; } 

}
