using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;

namespace Spareparts.Infrastructure.Repositories;
internal class ManufacturerRepository(SparepartsDbContext dbContext) : IManufacturerRepository {
    public async Task<Guid> AddNewManufacturer(Manufacturer entity) {
        var trackedEntity = dbContext.Manufacturers.Add(entity);
        await dbContext.SaveChangesAsync();
        return trackedEntity.Entity.Id;
    }

    public async Task<bool> DeleteManufacturer(Guid ManufacturerId) {
        var entity = dbContext.Manufacturers.FirstOrDefault(x => x.Id == ManufacturerId);
        dbContext.Remove(entity);
        var isDeleted = await dbContext.SaveChangesAsync();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false; 
        }
    }

    public async Task<IEnumerable<Manufacturer>> GetAllManufacturer() {
        var allManufacturers = dbContext.Manufacturers.ToList();
        return allManufacturers;
    }
}
