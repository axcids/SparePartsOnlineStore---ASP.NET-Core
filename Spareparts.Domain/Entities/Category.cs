using System.Threading.Tasks;

namespace Spareparts.Domain.Entities;
public class Category {

    // Unique identifier for the category
    public Guid Id { get; set; }

    // Name of the category (e.g., "Gears", "Brakes", "Electrical")
    public string Name { get; set; }

    // Optional description for more details (e.g., usage, notes)
    public string? Description { get; set; }

    // Timestamps for auditing
    public DateTime CreatedAt{ get; set; } = DateTime.Now;
    public DateTime? UpdatedAt{ get; set; }

    // Accessible Properties
    public virtual List<ProductDetails> ProductsDetails { get; set; }
}
