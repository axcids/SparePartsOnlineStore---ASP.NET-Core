using MediatR;

namespace Spareparts.Application.Manufacturers.Commands; 
public class CreateNewManufacturerCommand : IRequest<Guid>{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Logo { get; set; }

}
