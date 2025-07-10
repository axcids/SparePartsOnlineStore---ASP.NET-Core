using Spareparts.Domain.Entities;

namespace Spareparts.Application.ProductsDetails.Dtos; 
public class ProductsDetailsDtos {

    public Guid Id { get; set; }
    public Guid CategoryId { get; set; } // Done
    //public Guid SupplierId { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string UPC { get; set; }
    public decimal Price { get; set; }
    public float WeightInKg { get; set; }
    public string Dimensions { get; set; }
    public string Material { get; set; }
    public Boolean HasWarranty { get; set; }
    public int? WarrantyPeriodInMonths { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }


    public static ProductsDetailsDtos? FromEntity(Product productDetails) {
        if (productDetails == null) return null;
        return new ProductsDetailsDtos() {
            Id = productDetails.Id,
            CategoryId = productDetails.CategoryId,
            Name = productDetails.Name,
            Description = productDetails.Description,
            UPC = productDetails.UPC,
            Price = productDetails.Price,
            WeightInKg = productDetails.WeightInKg,
            Dimensions = productDetails.Dimensions,
            Material = productDetails.Material,
            HasWarranty = productDetails.HasWarranty,
            WarrantyPeriodInMonths = productDetails.WarrantyPeriodInMonths,
            CreatedAt = productDetails.CreatedAt,
            UpdatedAt = productDetails.UpdatedAt

        };
    }
}
