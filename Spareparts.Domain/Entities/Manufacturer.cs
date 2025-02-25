using System.Threading.Tasks;

namespace Spareparts.Domain.Entities;
public class Manufacturer {

    // Unique identifier for the manufacturer
    public Guid Id { get; set; }

    // Official name of the manufacturer (e.g., "Toyota", "Bosch", etc.)
    public string Name { get; set; }

    // Timestamps for auditing
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    // Accessible Properties
    public virtual List<ProductDetails> ProductsDetails { get; set; }
    public virtual List<Car> Cars { get; set; }
}
