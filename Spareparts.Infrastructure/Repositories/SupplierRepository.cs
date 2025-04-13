
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;

namespace Spareparts.Infrastructure.Repositories; 
internal class SupplierRepository(SparepartsDbContext dbContext) :  ISupplierRepository {

    public async Task<Guid> AddNewSupplier(Supplier entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<bool> DeleteSupplier(Guid supplierId) {
        var entity = dbContext.Suppliers.FirstOrDefault(x => x.Id == supplierId);
        dbContext.Suppliers.Remove(entity);
        var isDeleted = await dbContext.SaveChangesAsync();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public async Task<IEnumerable<Supplier>> GetAllSuppliers() {
        var AllSuppliers = dbContext.Suppliers.ToList();
        return AllSuppliers;
    }
}
