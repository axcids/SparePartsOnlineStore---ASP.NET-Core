using MediatR;

namespace Spareparts.Application.Products.Commands.CreateNewProduct; 
public class CreateNewProductCommand : IRequest<Guid> {
    public Guid CarId { get; set; }
    public Guid SupplierId { get; set; }
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
}
