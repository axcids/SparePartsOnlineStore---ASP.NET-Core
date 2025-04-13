using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Spareparts.Domain.Entities; 

public class Supplier {

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
    public DateTime? UpdatedAt{ get; set; }

    // Relations
    public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }




}
