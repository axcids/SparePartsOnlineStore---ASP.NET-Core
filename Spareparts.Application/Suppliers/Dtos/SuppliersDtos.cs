
using Spareparts.Domain.Entities;

namespace Spareparts.Application.Suppliers.Dtos; 
public class SuppliersDtos {

    public Guid Id { get; set; }
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

    // Auditing fields
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    public static SuppliersDtos? FromEntity(Supplier supplier) {
        if (supplier == null) return null;
        return new SuppliersDtos() {
            Id = supplier.Id,
            UserId = supplier.UserId,
            Name = supplier.Name,
            SupplierCode = supplier.SupplierCode,
            SupplierType = supplier.SupplierType,
            ContactEmail = supplier.ContactEmail,
            ContactPhone = supplier.ContactPhone,
            Website = supplier.Website,
            IsActive = supplier.IsActive,
            AddressLine1 = supplier.AddressLine1,
            AddressLine2 = supplier.AddressLine2,
            City = supplier.City,
            StateOrProvince = supplier.StateOrProvince,
            PostalCode = supplier.PostalCode,
            Country = supplier.Country,
            CreatedAt = supplier.CreatedAt,
            UpdatedAt = supplier.UpdatedAt,
        };
    }

}
