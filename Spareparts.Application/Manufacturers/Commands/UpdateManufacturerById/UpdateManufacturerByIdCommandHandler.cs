using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Manufacturers.Dtos;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Manufacturers.Commands.UpdateManufacturerById;
public class UpdateManufacturerByIdCommandHandler (IManufacturerRepository manufacturerRepository, ILogger<UpdateManufacturerByIdCommandHandler> logger) : IRequestHandler<UpdateManufacturerByIdCommand, ManufacturersDtos> {
    public async Task<ManufacturersDtos> Handle(UpdateManufacturerByIdCommand request, CancellationToken cancellationToken) {
        Manufacturer newManufacturer = new Manufacturer {
            Name = request.Name,
            Description = request.Description,
            Logo = request.Logo,
            UpdatedAt = DateTime.Now,
        };
        var isUpdated = await manufacturerRepository.UpdateManufacturerById(request.Id, newManufacturer);
        if (isUpdated != null) {
            var manufacturerDto = ManufacturersDtos.FromEntity(isUpdated);
            return manufacturerDto;
        }
        else {
            logger.LogError("The Manufacturer is not updated");
            return null;
        }
    }
}
