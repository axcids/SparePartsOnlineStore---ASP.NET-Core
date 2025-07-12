using MediatR;

namespace Spareparts.Application.Products.Commands.DeleteProductById; 
public class DeleteProductByIdCommand (Guid id)  : IRequest<bool> {
    public Guid Id{ get; set; } = id;
}
