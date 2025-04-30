using MediatR;

namespace Spareparts.Application.Manufacturers.Commands.DeleteManufacturerByIdCommand; 
public class DeleteManufacturerByIdCommand (Guid id) : IRequest<bool>{
    public Guid Id { get; set; }
}
