using Spareparts.Domain.Entities;

namespace Spareparts.Domain.Repositories; 
public interface ISupplierRepository {

    // Add new category 
    Task<Guid> AddNewSupplier(Supplier entity);

    // Delete a category
    Task<bool> DeleteSupplier(Guid CategoryId);

    // Update category

    // Fetching all category
    Task<IEnumerable<Supplier>> GetAllSuppliers();


}
