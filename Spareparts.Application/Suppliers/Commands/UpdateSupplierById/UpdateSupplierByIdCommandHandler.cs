using MediatR;
using Microsoft.Extensions.Logging;
using Spareparts.Application.Suppliers.Dtos;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;

namespace Spareparts.Application.Suppliers.Commands.UpdateSupplierById;
public class UpdateSupplierByIdCommandHandler(ISupplierRepository supplierRepository, ILogger<UpdateSupplierByIdCommandHandler> logger) : IRequestHandler<UpdateSupplierByIdCommand, SuppliersDtos> {
    public async Task<SuppliersDtos> Handle(UpdateSupplierByIdCommand request, CancellationToken cancellationToken) {
        Supplier UpdatedSupplier = new Supplier {
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
            UpdatedAt = DateTime.Now,
        };        
        var isUpdated = await supplierRepository.UpdateSupplierById(request.Id, UpdatedSupplier);
        await supplierRepository.SaveChanges();
        if (isUpdated) {
            var supplierDto = SuppliersDtos.FromEntity(UpdatedSupplier);
            return supplierDto;
        }
        else {
            logger.LogError("The Supplier is not updated");
            return null;
        }
    }
}
