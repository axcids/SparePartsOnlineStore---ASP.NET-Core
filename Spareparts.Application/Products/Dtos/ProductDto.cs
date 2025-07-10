using Spareparts.Application.Products.Dtos;
using Spareparts.Domain.Entities;

namespace Spareparts.Application.Products.Dtos; 
public class ProductDto {
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


    public static ProductDto? FromEntity(Product product) {
        if (product == null) return null;
        return new ProductDto() {
            Id = product.Id,
            CategoryId = product.CategoryId,
            Name = product.Name,
            Description = product.Description,
            UPC = product.UPC,
            Price = product.Price,
            WeightInKg = product.WeightInKg,
            Dimensions = product.Dimensions,
            Material = product.Material,
            HasWarranty = product.HasWarranty,
            WarrantyPeriodInMonths = product.WarrantyPeriodInMonths,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt

        };
    }
}
