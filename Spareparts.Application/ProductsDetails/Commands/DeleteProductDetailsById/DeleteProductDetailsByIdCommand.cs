using MediatR;

namespace Spareparts.Application.ProductsDetails.Commands.DeleteProductDetailsById; 
public class DeleteProductDetailsByIdCommand (Guid id) : IRequest<bool>{
    public Guid Id { get; } = id;
}
