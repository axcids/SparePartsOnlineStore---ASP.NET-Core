using MediatR;

namespace Spareparts.Application.CarsProducts.Commands.CreateCarProducts; 
public class CreateCarProductCommand : IRequest<Guid> {
    public Guid Id { get; set; }
    public Guid CarId { get; set; }

    public Guid ProductId { get; set; }
    
}
