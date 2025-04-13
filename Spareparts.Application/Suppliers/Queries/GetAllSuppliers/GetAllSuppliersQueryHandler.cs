using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Suppliers.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Suppliers.Queries.GetAllSuppliers;
public class GetAllSuppliersQueryHandler(ISupplierRepository supplierRepository, ILogger<GetAllSuppliersQueryHandler> logger) : IRequestHandler<GetAllSuppliersQuery, IEnumerable<SuppliersDtos>> {
    public async Task<IEnumerable<SuppliersDtos>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken) {
        var entities = await supplierRepository.GetAllSuppliers();
        var entitiesDtos = entities.Select(SuppliersDtos.FromEntity).ToList();
        return entitiesDtos;
    }
}
