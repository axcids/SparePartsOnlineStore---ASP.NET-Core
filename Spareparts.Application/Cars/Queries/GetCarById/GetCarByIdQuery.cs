using MediatR;
using Spareparts.Application.Cars.Dtos;

namespace Spareparts.Application.Cars.Queries.GetCarById; 
public class GetCarByIdQuery (Guid carId) : IRequest<CarsDtos>{
    public Guid Id { get; set; } = carId;
}
