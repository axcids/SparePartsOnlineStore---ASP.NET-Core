using Spareparts.Domain.Entities;

namespace Spareparts.Domain.Repositories; 
public interface ISupplierRepository {

    Task<Guid> AddNewSupplier(Supplier entity);
    Task<IEnumerable<Supplier>> GetAllSuppliers();
    Task<Supplier> GetSupplierById(Guid id);
    Task<IEnumerable<Supplier>> GetSuppliersBySupplierCode(string supplierCode);
    Task<Supplier> GetSupplierByName(string name);
    Task<IEnumerable<Supplier>> GetSuppliersByCountry(string country);
    Task<bool> DeleteSupplierById(Guid Id);
    Task<bool> DeleteSuppliersBySupplierCode(string supplierCode);
    Task SaveChanges();

    // Update category



}
