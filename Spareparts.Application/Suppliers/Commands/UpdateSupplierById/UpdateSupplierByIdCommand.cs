using MediatR;
using Spareparts.Application.Suppliers.Dtos;
using System.Text.Json.Serialization;

namespace Spareparts.Application.Suppliers.Commands.UpdateSupplierById; 
public class UpdateSupplierByIdCommand : IRequest<SuppliersDtos> {
    [JsonIgnore]
    public Guid Id { get; set; }
    public Guid UserId { get; set; } // To be implemented later
    public string Name { get; set; }
    public string SupplierCode { get; set; } // To be auto generated later
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
    [JsonIgnore]
    public DateTime? UpdatedAt { get; set; }
}
