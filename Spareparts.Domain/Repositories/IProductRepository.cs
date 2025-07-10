using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface IProductRepository {

    // Add new product details 
    Task<Guid> AddNewProduct(Product entity);
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(Guid id);
    Task<bool> UpdateProduct(Product entity);
    Task<bool> DeleteProductById(Guid id);

}
