using Spareparts.Domain.Entities;

namespace Spareparts.Domain.Repositories; 
public interface IManufacturerRepository {

    // Add new manufacturer
    Task<Guid> AddNewManufacturer(Manufacturer entity);

    // Delete manufacturer
    Task<bool> DeleteManufacturerById(Guid ManufacturerId);

    // Update manufacturer

    // Fetching all manufacturers
    Task<IEnumerable<Manufacturer>> GetAllManufacturer();
}
