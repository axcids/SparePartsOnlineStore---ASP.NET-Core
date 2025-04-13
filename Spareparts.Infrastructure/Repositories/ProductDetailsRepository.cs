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
    public async Task<bool> DeleteProductById(Guid productId) {
        var entity = dbContext.ProductsDetails
            .FirstOrDefault(x => x.Id == productId);
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
        return true;
    }


    public async Task<IEnumerable<ProductDetails>> GetAllProducts() {
        var AllProductDetails = dbContext.ProductsDetails.ToList();
        return AllProductDetails;
    }

    public async Task<IEnumerable<Domain.Entities.ProductDetails>> GetAllProductsByCategoryId(Guid CategoryId) {
        var AllProductsDetails = dbContext.ProductsDetails.Where(x => x.CategoryId == CategoryId);
        return AllProductsDetails.ToList();
    }

    public async Task<IEnumerable<Domain.Entities.ProductDetails>> GetAllProductsByName(string Name) {
        var AllProductsDetails = dbContext.ProductsDetails.Where(x => x.Name.Contains(Name));
        return AllProductsDetails.ToList();
    }

    public async Task<Domain.Entities.ProductDetails> GetProductDetailsByProductId(Guid productId) {
        var entity = dbContext.ProductsDetails.FirstOrDefault(x => x.Id == productId);
        return entity;
    }

    public async Task<IEnumerable<Domain.Entities.ProductDetails>> GetAllProductsByUPC(string UPC) {
        var Products = dbContext.ProductsDetails.Where(x => x.UPC == UPC);
        return Products;
    }
}
