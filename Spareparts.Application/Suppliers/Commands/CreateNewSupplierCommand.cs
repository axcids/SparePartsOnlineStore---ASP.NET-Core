using MediatR;

namespace Spareparts.Application.Suppliers.Commands; 
public class CreateNewSupplierCommand : IRequest<Guid>{
    public Guid UserId { get; set; } // To be implemented later 
    public string Name { get; set; }
    public string SupplierCode { get; set; } // To be auto generated later 
    public string SupplierType { get; set; } // To be Enum list later 
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
