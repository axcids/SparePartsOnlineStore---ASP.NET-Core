using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;

namespace Spareparts.Infrastructure.Repositories;
internal class ProductDetailsRepository(SparepartsDbContext dbContext) : IProductRepository {
    public async Task<Guid> AddNewProduct(Product entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id; //this might be error 
    }
    public async Task<bool> DeleteProductById(Guid id) {
        var entity = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        var isDeleted = dbContext.Products.Remove(entity);
        if (isDeleted != null) {
            await dbContext.SaveChangesAsync();
            return true;
        }
        else {
            return false;
        }
    }
    public async Task<IEnumerable<Product>> GetAllProducts() {
        var entities = await dbContext.Products.ToListAsync();
        return entities;
    }

    public async Task<Product> GetProductById(Guid id) {
        var entity = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        return entity;
    }
    public Task<bool> UpdateProduct(Product entity) {
        throw new NotImplementedException();
    }
}
