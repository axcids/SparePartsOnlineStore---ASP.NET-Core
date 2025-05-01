using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface IProductDetailsRepository {

    // Add new product details 
    Task<Guid> AddNewProductDetails(ProductDetails entity);

}
