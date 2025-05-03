using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface IProductDetailsRepository {

    // Add new product details 
    Task<Guid> AddNewProductDetails(ProductDetails entity);
    Task<IEnumerable<ProductDetails>> GetAllProductsDetails();
    Task<ProductDetails> GetProductDetailsById(Guid id);
    Task<bool> UpdateProductDetails(ProductDetails entity);
    Task<bool> DeleteProductDetailsById(Guid id);

}
