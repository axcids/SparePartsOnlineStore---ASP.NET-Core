using MediatR;

namespace Spareparts.Application.Manufacturers.Commands.DeleteManufacturerById; 
public class DeleteManufacturerByIdCommand (Guid id) : IRequest<bool>{
    public Guid Id { get; } = id;
}
