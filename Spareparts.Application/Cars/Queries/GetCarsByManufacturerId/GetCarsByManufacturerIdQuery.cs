using MediatR;
using Spareparts.Application.Cars.Dtos;

namespace Spareparts.Application.Cars.Queries.GetCarsByManufacturerId; 
public class GetCarsByManufacturerIdQuery (Guid manufacturerId) : IRequest<IEnumerable<CarsDtos>>{
    public Guid Id { get; set; } = manufacturerId;
}
