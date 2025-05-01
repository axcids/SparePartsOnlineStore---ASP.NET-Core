using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Manufacturers.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Manufacturers.Queries.GetManufacturerById;
public class GetManufacturerByIdQueryHandler(IManufacturerRepository manufacturerRepository, ILogger<GetManufacturerByIdQueryHandler> logger) : IRequestHandler<GetManufacturerByIdQuery, ManufacturersDtos> {
    public async Task<ManufacturersDtos> Handle(GetManufacturerByIdQuery request, CancellationToken cancellationToken) {
        var manufacturer = await manufacturerRepository.GetManufacturerById(request.Id);
        if (manufacturer == null) {
            logger.LogWarning("Manufacturer with id {Id} not found", request.Id);
            return null;
        }
        else {
            logger.LogInformation("Manufacturer with id {Id} found is being fetched", request.Id);
            var manufacturerDto = ManufacturersDtos.FromEntity(manufacturer);
            return manufacturerDto;
        }
    }
}
