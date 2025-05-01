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
    
}
