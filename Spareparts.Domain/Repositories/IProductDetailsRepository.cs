using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface IProductDetailsRepository {

    // Add new product details 
    Task<Guid> AddNewProductDetails(ProductDetails entity);

    // Delete product details 
    Task<bool>DeleteProductById(Guid productId);

    // Update product detials


    // Fetching all products by :
    Task<IEnumerable<ProductDetails>> GetAllProducts();
    Task<IEnumerable<ProductDetails>> GetAllProductsByName(String Name);
    Task<IEnumerable<ProductDetails>> GetAllProductsByUPC(String UPC);
    Task<IEnumerable<ProductDetails>> GetAllProductsByBrandId(Guid ManufacturerId);
    Task<IEnumerable<ProductDetails>> GetAllProductsByCategoryId(Guid CategoryDetails);

    // Fetching specific details
    Task<ProductDetails> GetProductDetailsByProductId(Guid productId);

}
