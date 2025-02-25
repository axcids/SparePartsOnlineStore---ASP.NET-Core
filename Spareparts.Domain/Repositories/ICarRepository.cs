using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface ICarRepository {

    // Add new car 
    Task<Guid> AddNewCar(ProductDetails entity);
    
    // Delete car 
    Task<bool> DeleteCar(Guid carId);

    // Update car

    // Fetching all cars 
    Task<IEnumerable<Car>> GetAllcars();

}
