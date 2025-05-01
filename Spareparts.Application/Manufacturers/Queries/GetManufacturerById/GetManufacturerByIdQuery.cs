
using MediatR;
using Spareparts.Application.Manufacturers.Dtos;
using System.Text.Json.Serialization;

namespace Spareparts.Application.Manufacturers.Queries.GetManufacturerById; 
public class GetManufacturerByIdQuery (Guid id) : IRequest<ManufacturersDtos>{

    [JsonIgnore]
    public Guid Id => id;

}
