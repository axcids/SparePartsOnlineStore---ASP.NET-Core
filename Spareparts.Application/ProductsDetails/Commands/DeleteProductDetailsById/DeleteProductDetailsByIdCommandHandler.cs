using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.ProductsDetails.Commands.DeleteProductDetailsById;
public class DeleteProductDetailsByIdCommandHandler(IProductRepository productDetailsRepository, ILogger<DeleteProductDetailsByIdCommandHandler> logger) : IRequestHandler<DeleteProductDetailsByIdCommand, bool> {
    public async Task<bool> Handle(DeleteProductDetailsByIdCommand request, CancellationToken cancellationToken) {
        var isDeleted = await productDetailsRepository.DeleteProductDetailsById(request.Id);
        if (isDeleted) {
            logger.LogInformation($"Product details with ID {request.Id} deleted successfully.");
            return true;
        }
        else {
            logger.LogWarning($"Failed to delete product details with ID {request.Id}.");
            return false;
        }
    }
}
