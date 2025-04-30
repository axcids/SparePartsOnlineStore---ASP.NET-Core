using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Manufacturers.Commands.CreateNewManufacturerCommand;
public class CreateNewManufacturerCommandHandler(IManufacturerRepository manufacturerRepository, ILogger<CreateNewManufacturerCommandHandler> logger) : IRequestHandler<CreateNewManufacturerCommand, Guid> {
    public async Task<Guid> Handle(CreateNewManufacturerCommand request, CancellationToken cancellationToken) {
        var entity = new Manufacturer {
            Name = request.Name,
            Description = request.Description,
            Logo = request.Logo,
        };
        var id = await manufacturerRepository.AddNewManufacturer(entity);
        return id;
    }
}
