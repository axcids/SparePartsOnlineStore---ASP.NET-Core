namespace Spareparts.Domain.Entities;

public class ProductDetails {

    // Unique identifier for the product
    public Guid Id { get; set; }
    // Basic product info
    public string Name { get; set; }
    public string Description { get; set; }
    // Universal Product Code 
    public string UPC { get; set; }
    // GUID for the product category (e.g., Gear, EnginePart, BrakeSystem)
    public Guid CategoryId { get; set; }
    // GUID fpr the product supplier 
    //public Guid SupplierId { get; set; }
    // Monetary cost of the product
    public decimal Price { get; set; }

    // Physical attributes - you can expand with more details (Length, Height, Depth, etc.)
    public float WeightInKg { get; set; }
    public string Dimensions { get; set; }
    // Material composition (e.g., Steel, Aluminum)
    public string Material { get; set; }
    // Warranty information in months or years
    public Boolean HasWarranty { get; set; }
    public int? WarrantyPeriodInMonths { get; set; }
      
    // Timestamps for tracking product creation or last update
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    // Relations
    public virtual Category Category { get; set; }
    public virtual ICollection<CarProduct> CarsProducts { get; set; }
    public virtual ICollection<SupplierProduct> SupplierProdouct { get; set; }
}


