
using MediatR;

namespace Spareparts.Application.Cars.Commands.DeleteCar; 
public class DeleteCarsByManufacturerIdCommand (Guid Id) : IRequest<bool>{
    public Guid Id { get; set; }
}
