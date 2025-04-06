using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;

namespace Spareparts.Infrastructure.Repositories;
public class CarProductRepository(SparepartsDbContext dbContext) : ICarProductRepository {
    public async Task<Guid> AddNewCarProduct(CarProduct entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }
    public async Task<bool> DeleteCarProductByCarId(Guid id) {
        var entity = dbContext.CarsProducts.FirstOrDefault(x => x.CarId == id);
        var isDeleted = await dbContext.SaveChangesAsync();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public async Task<bool> DeleteCarProductById(Guid id) {
        var entity = dbContext.CarsProducts.FirstOrDefault(x => x.Id == id);
        var isDeleted = await dbContext.SaveChangesAsync();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public async Task<bool> DeleteCarProductByProductId(Guid id) {
        var entity = dbContext.CarsProducts.FirstOrDefault(x => x.ProductId == id);
        var isDeleted = await dbContext.SaveChangesAsync();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public async Task<IEnumerable<CarProduct>> GetAllCarsProducts() {
        var AllCarsProducts = await dbContext.CarsProducts.ToListAsync();
        return AllCarsProducts;
    }

    public async Task<IEnumerable<CarProduct>> GetAllCarsProductsByCarId(Guid id) {
        var AllCarsProducts = await dbContext.CarsProducts.Where(d => d.CarId == id).ToListAsync();
        return AllCarsProducts;
    }

    public async Task<IEnumerable<CarProduct>> GetAllCarsProductsByProductId(Guid id) {
        var AllCarsProducts = await dbContext.CarsProducts.Where(d => d.ProductId == id).ToListAsync();
        return AllCarsProducts;
    }

    public async Task SaveChanges() {
        await dbContext.SaveChangesAsync();
    }
}
