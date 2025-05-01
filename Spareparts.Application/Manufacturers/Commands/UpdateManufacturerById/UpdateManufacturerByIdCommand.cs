using MediatR;
using Spareparts.Application.Manufacturers.Dtos;
using System.Text.Json.Serialization;

namespace Spareparts.Application.Manufacturers.Commands.UpdateManufacturerById; 
public class UpdateManufacturerByIdCommand : IRequest<ManufacturersDtos>{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Logo { get; set; }
    public DateTime UpdatedAt { get; set; }
}
