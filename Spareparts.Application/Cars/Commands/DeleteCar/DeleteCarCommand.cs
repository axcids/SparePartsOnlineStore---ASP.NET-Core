using MediatR;

namespace Spareparts.Application.Cars.Commands.DeleteCar;
public class DeleteCarCommand(Guid Id) : IRequest<bool> {
    public Guid Id { get; set; }
}