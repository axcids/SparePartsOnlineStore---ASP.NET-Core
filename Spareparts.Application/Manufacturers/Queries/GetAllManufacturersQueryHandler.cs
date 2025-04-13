
using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Manufacturers.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Manufacturers.Queries;
public class GetAllManufacturersQueryHandler(IManufacturerRepository manufacturerRepository, ILogger<GetAllManufacturersQueryHandler> logger) : IRequestHandler<GetAllManufacturersQuery, IEnumerable<ManufacturersDtos>> {
    public async Task<IEnumerable<ManufacturersDtos>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken) {
        var manufacturers = await manufacturerRepository.GetAllManufacturer();
        var manufacturersDtos = manufacturers.Select(ManufacturersDtos.FromEntity).ToList();
        return manufacturersDtos;
    }
}
