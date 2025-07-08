using MediatR;

namespace Spareparts.Application.Cars.Commands.DeleteCarById;
public class DeleteCarCommand(Guid Id) : IRequest<bool> {
    public Guid Id { get; set; }
}