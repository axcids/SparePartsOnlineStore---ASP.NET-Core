using Spareparts.Domain.Entities;

namespace Spareparts.Domain.Repositories; 
public interface ISupplierProductRepository {
    // C
    Task<Guid> AddNewSupplierProduct(SupplierProduct entity);
    // R
    Task<IEnumerable<SupplierProduct>> GetAllSuppliersProduct();
    Task<IEnumerable<SupplierProduct>> GetAllSuppliersProductByCarId(Guid id);
    Task<IEnumerable<SupplierProduct>> GetAllSuppliersProductByProductId(Guid id);
    // U
    // D
    Task<bool> DeleteSupplierProductById(Guid id);
    Task<bool> DeleteSupplierProductByCarId(Guid id);
    Task<bool> DeleteSupplierProductByProductId(Guid id);
}
