using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Suppliers.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Suppliers.Queries.GetSuppliersBySupplierCode;
public class GetSuppliersBySupplierCodeQueryHandler(ISupplierRepository supplierRepository, ILogger<GetSuppliersBySupplierCodeQueryHandler> logger) : IRequestHandler<GetSuppliersBySupplierCodeQuery, IEnumerable<SuppliersDtos>> {
    public async Task<IEnumerable<SuppliersDtos>> Handle(GetSuppliersBySupplierCodeQuery request, CancellationToken cancellationToken) {
        var entities = await supplierRepository.GetSuppliersBySupplierCode(request.SupplierCode);
        var entitiesDtos = entities.Select(SuppliersDtos.FromEntity).ToList();
        return entitiesDtos;
    }
}
