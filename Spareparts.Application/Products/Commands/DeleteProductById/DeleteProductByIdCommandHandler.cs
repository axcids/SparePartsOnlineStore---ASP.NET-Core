using MediatR;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Products.Commands.DeleteProductById;
public class DeleteProductByIdCommandHandler(IProductRepository productRepository, ILogger<DeleteProductByIdCommandHandler> logger) : IRequestHandler<DeleteProductByIdCommand, bool> {
    public async Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken) {
        var isDeleted = await productRepository.DeleteProductById(request.Id);
        if (isDeleted) {
            return true; //Change this later to be a result based 
        }
        else {
            return false; //Change this later to be a result based 
        }
    }
}
