using Spareparts.Domain.Entities;

namespace Spareparts.Domain.Repositories; 
public interface ISupplierRepository {

    Task<Guid> AddNewSupplier(Supplier entity);
    Task<IEnumerable<Supplier>> GetAllSuppliers();
    Task<IEnumerable<Supplier>> GetSuppliersBySupplierCode(string supplierCode);
    Task<bool> DeleteSupplier(Guid CategoryId);

    // Update category



}
