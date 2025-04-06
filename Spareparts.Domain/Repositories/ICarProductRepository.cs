
using Microsoft.EntityFrameworkCore;
using Spareparts.Domain.Entities;

namespace Spareparts.Domain.Repositories; 
public interface ICarProductRepository {

    //Add New Car Product 
    Task<Guid> AddNewCarProduct(CarProduct entity);

    // Delete car product 
    Task<bool> DeleteCarProductById(Guid id);
    Task<bool> DeleteCarProductByCarId(Guid id);
    Task<bool> DeleteCarProductByProductId(Guid id);


    // Update car product 
    

    // Fetch car product 
    Task<IEnumerable<CarProduct>> GetAllCarsProducts();
    Task<IEnumerable<CarProduct>> GetAllCarsProductsByCarId(Guid id);
    Task<IEnumerable<CarProduct>> GetAllCarsProductsByProductId(Guid id);

    //Saving Changes 
    Task SaveChanges();




}
