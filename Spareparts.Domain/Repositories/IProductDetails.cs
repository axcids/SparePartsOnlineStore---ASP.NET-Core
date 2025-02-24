using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface IProductDetails {

    // Add new product details 
    Task<Guid> AddNewProductDetails(ProductDetails entity);

    // Delete product details 
    Task DeleteProductById(Guid productId);

    // Update product detials


    // Fetching all details
    Task<ProductDetails> GetAllProductDetailsByProductId(Guid productId);
    Task<IEnumerable<ProductDetails>> GetAllProductDetailsByName(String Name);
    Task<IEnumerable<ProductDetails>> GetAllProductDetailsByUPC(String UPC);
    Task<IEnumerable<ProductDetails>> GetAllProductDetailsByBrandId(Guid BrandId);
    Task<IEnumerable<ProductDetails>> GetAllProductDetailsByCategoryId(Guid BrandId);

    // Fetching specific 
    Task<ProductDetails> GetProductPhysicalAttributesById(Guid productId);
    Task<ProductDetails> GetWarrantyDetailsById(Guid warrantyId);
    Task<ProductDetails> GetProductPriceById(Guid productId);
    Task<IEnumerable<ProductDetails>> GetProductPriceByUPC(Guid UPC);


}
