using System.Text.Json.Serialization;
using MediatR;

namespace Spareparts.Application.Products.Commands.UpdateProduct; 
public class UpdateProductByIdCommand(Guid Id): IRequest<bool> {
    [JsonIgnore]
    public Guid Id { get; set; } = Id;  
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string UPC { get; set; }
    public decimal Price { get; set; }
    public float WeightInKg { get; set; }
    public string Dimensions { get; set; }
    public string Material { get; set; }
    public Boolean HasWarranty { get; set; }
    public int? WarrantyPeriodInMonths { get; set; }
    public DateTime? UpdatedAt { get; set; }


}
