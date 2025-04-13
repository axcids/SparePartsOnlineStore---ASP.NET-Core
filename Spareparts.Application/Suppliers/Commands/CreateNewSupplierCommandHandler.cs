using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Suppliers.Commands;
public class CreateNewSupplierCommandHandler(ISupplierRepository supplierRepository, ILogger<CreateNewSupplierCommandHandler> logger) : IRequestHandler<CreateNewSupplierCommand, Guid> {
    public async Task<Guid> Handle(CreateNewSupplierCommand request, CancellationToken cancellationToken) {
        var entity = new Supplier {
            UserId = request.UserId,
            Name = request.Name,
            SupplierCode = request.SupplierCode,
            SupplierType = request.SupplierType,
            ContactEmail = request.ContactEmail,
            ContactPhone = request.ContactPhone,
            Website = request.Website,
            IsActive = request.IsActive,
            AddressLine1 = request.AddressLine1,
            AddressLine2 = request.AddressLine2,
            City = request.City,
            StateOrProvince = request.StateOrProvince,
            PostalCode = request.PostalCode,
            Country = request.Country,
        };
        var id = await supplierRepository.AddNewSupplier(entity);
        return id;
    }
}
