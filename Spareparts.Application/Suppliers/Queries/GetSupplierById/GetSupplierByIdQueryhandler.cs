using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Suppliers.Dtos;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Suppliers.Queries.GetSupplierById;
public class GetSupplierByIdQueryhandler(ISupplierRepository supplierRepository, ILogger<GetSupplierByIdQueryhandler> logger) : IRequestHandler<GetSupplierByIdQuery, SuppliersDtos> {
    public async Task<SuppliersDtos> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken) {
        var entity = await supplierRepository.GetSupplierById(request.Id);
        var entityDto = SuppliersDtos.FromEntity(entity);
        return entityDto;
    }
}
