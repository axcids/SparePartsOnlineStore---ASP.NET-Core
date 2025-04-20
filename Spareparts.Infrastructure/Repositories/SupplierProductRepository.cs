using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;

namespace Spareparts.Infrastructure.Repositories;
public class SupplierProductRepository(SparepartsDbContext dbContext) : ISupplierProductRepository {
    public async Task<Guid> AddNewSupplierProduct(SupplierProduct entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task<bool> DeleteSupplierProductByCarId(Guid id) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteSupplierProductById(Guid id) {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteSupplierProductByProductId(Guid id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SupplierProduct>> GetAllSuppliersProduct() {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SupplierProduct>> GetAllSuppliersProductByCarId(Guid id) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SupplierProduct>> GetAllSuppliersProductByProductId(Guid id) {
        throw new NotImplementedException();
    }
}
