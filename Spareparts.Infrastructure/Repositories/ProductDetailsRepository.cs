using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;



namespace Spareparts.Infrastructure.Repositories;
internal class ProductDetailsRepository(SparepartsDbContext dbContext) : IProductDetailsRepository {
    public async Task<Guid> AddNewProductDetails(ProductDetails entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id; //this might be error 
    }

    public async Task<bool> DeleteProductDetailsById(Guid id) {
        var entity = await dbContext.ProductsDetails.FirstOrDefaultAsync(x => x.Id == id);
        var isDeleted = dbContext.ProductsDetails.Remove(entity);
        if (isDeleted != null) {
            await dbContext.SaveChangesAsync();
            return true;
        }
        else {
            return false;
        }

    }

    public async Task<IEnumerable<ProductDetails>> GetAllProductsDetails() {
        var entities = await dbContext.ProductsDetails.ToListAsync();
        return entities;
    }
    public async Task<ProductDetails> GetProductDetailsById(Guid id) {
        var entity= await dbContext.ProductsDetails.FirstOrDefaultAsync(x => x.Id == id);
        return entity;

    }

    public Task<bool> UpdateProductDetails(ProductDetails entity) {
        throw new NotImplementedException();
    }
}
