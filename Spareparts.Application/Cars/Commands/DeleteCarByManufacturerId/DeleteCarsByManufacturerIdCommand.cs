
using MediatR;

namespace Spareparts.Application.Cars.Commands.DeleteCarByManufacturerId;
public class DeleteCarsByManufacturerIdCommand(Guid Id) : IRequest<bool> {
    public Guid Id { get; set; }
}
