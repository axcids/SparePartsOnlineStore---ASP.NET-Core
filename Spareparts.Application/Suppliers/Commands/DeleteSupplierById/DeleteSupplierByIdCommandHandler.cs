using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Suppliers.Commands.DeleteSupplierById;
public class DeleteSupplierByIdCommandHandler(ISupplierRepository supplierRepository, ILogger<DeleteSupplierByIdCommandHandler> logger) : IRequestHandler<DeleteSupplierByIdCommand, bool> {
    public async Task<bool> Handle(DeleteSupplierByIdCommand request, CancellationToken cancellationToken) {
        var isDeleted = await supplierRepository.DeleteSupplierById(request.Id);
        if (isDeleted) {
            logger.LogInformation($"Supplier with ID {request.Id} deleted successfully.");
            return true;
        }
        else {
            logger.LogWarning($"Failed to delete supplier with ID {request.Id}.");
            return false;
        }
    }
}
