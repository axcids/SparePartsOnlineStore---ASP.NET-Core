using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Manufacturers.Commands.DeleteManufacturerById;
public class DeleteManufacturerByIdCommandHandler(IManufacturerRepository manufacturerRepository, ILogger<DeleteManufacturerByIdCommandHandler> logger) : IRequestHandler<DeleteManufacturerByIdCommand, bool> {
    public async Task<bool> Handle(DeleteManufacturerByIdCommand request, CancellationToken cancellationToken) {
        var isDeleted = await manufacturerRepository.DeleteManufacturerById(request.Id);
        if (isDeleted) {
            logger.LogInformation($"Manufacturer with ID {request.Id} deleted successfully.");
            return true;
        }
        else {
            logger.LogWarning($"Failed to delete Manufacturer with ID {request.Id}.");
            return false;
        }
    }
}
