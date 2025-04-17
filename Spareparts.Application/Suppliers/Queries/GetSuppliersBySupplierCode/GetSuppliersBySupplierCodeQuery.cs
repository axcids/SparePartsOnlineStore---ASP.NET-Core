using MediatR;
using Spareparts.Application.Suppliers.Dtos;

namespace Spareparts.Application.Suppliers.Queries.GetSuppliersBySupplierCode; 
public class GetSuppliersBySupplierCodeQuery (string supplierCode) : IRequest<IEnumerable<SuppliersDtos>> {
    
    public Guid Id { get; set; }
    public Guid UserId { get; set; } 
    public string Name { get; set; }
    public string SupplierCode { get; set; } = supplierCode;
    public string SupplierType { get; set; } 
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string? Website { get; set; }
    public bool IsActive { get; set; } = true;
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string City { get; set; }
    public string StateOrProvince { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }

}
