using MediatR;

namespace Spareparts.Application.CarsProducts.Commands.CreateCarProducts; 
public class CreateCarProductCommand : IRequest<Guid> {
    public Guid CarId { get; set; }

    public Guid ProductId { get; set; }
    public CreateCarProductCommand(Guid carId, Guid productId) {

        CarId = carId;
        ProductId = productId;
    }    
}
