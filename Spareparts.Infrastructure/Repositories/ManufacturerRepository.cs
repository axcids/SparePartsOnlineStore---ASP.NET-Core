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

    public async Task<bool> DeleteManufacturerById(Guid ManufacturerId) {
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
    public async Task<Manufacturer> GetManufacturerById(Guid id) {
        var manufacturer = await dbContext.Manufacturers.FirstOrDefaultAsync(x => x.Id == id);
        return manufacturer;
    }
    public async Task<Manufacturer> UpdateManufacturerById(Guid Id, Manufacturer newManufacturer) {
        //Validate the input Manufacturer object if necessary
        if(newManufacturer == null) {
            throw new ArgumentNullException(nameof(newManufacturer), "New Manufacturer details cannot be null.");
        }
        var fetchedEntity = await dbContext.Manufacturers.FirstOrDefaultAsync(x => x.Id == Id);
        if(fetchedEntity == null) return null;
        fetchedEntity.Name = newManufacturer.Name;
        fetchedEntity.Description = newManufacturer.Description;
        fetchedEntity.Logo = newManufacturer.Logo;
        dbContext.Update(fetchedEntity);
        await dbContext.SaveChangesAsync();
        return fetchedEntity;

    }

}
