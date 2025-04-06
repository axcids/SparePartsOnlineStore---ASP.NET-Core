using System.Threading.Tasks;

namespace Spareparts.Domain.Entities;
public class Manufacturer {

    // Unique identifier for the manufacturer
    public Guid Id { get; set; }

    // Official name of the manufacturer (e.g., "Toyota", "Bosch", etc.)
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Logo { get; set; }

    // Timestamps for auditing
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }

    // Accessible Properties
    public virtual List<Car> Cars { get; set; }
}
