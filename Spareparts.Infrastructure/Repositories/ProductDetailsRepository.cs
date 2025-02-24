using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;



namespace Spareparts.Infrastructure.Repositories;
internal class ProductDetailsRepository(SparepartsDbContext dbContext) : IProductDetailsRepository {
    public async Task<Guid> AddNewProductDetails(Domain.Entities.ProductDetails entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public Task<IEnumerable<ProductDetails>> GetAllProductsDetails() {
        throw new NotImplementedException();
    }
    public async Task<bool> DeleteProductById(Guid productId) {
        var entity = dbContext.ProductsDetails
            .FirstOrDefault(x => x.Id == productId);
        dbContext.Remove(entity.Id);
        await dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Domain.Entities.ProductDetails>> GetAllProductDetailsByBrandId(Guid BrandId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.ProductDetails>> GetAllProductDetailsByCategoryId(Guid BrandId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.ProductDetails>> GetAllProductDetailsByName(string Name) {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.ProductDetails> GetAllProductDetailsByProductId(Guid productId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.ProductDetails>> GetAllProductDetailsByUPC(string UPC) {
        throw new NotImplementedException();
    }


    public Task<Domain.Entities.ProductDetails> GetProductPhysicalAttributesById(Guid productId) {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.ProductDetails> GetProductPriceById(Guid productId) {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.Entities.ProductDetails>> GetProductPriceByUPC(Guid UPC) {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.ProductDetails> GetWarrantyDetailsById(Guid warrantyId) {
        throw new NotImplementedException();
    }
}
