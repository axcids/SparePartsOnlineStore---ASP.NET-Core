using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface ICarRepository {

    // Add new car 
    Task<Guid> AddNewCar(ProductDetails entity);
    
    // Delete car 
    Task DeleteCarById(Guid carId);

    // Update car

    // Fetching all cars 
    Task<IEnumerable<ICarRepository>> GetAllcars();
    Task<IEnumerable<ICarRepository>> GetAllcarsByManufacturer(String Manufacturer);
    Task<IEnumerable<ICarRepository>> GetAllcarsByYear(int ModelYear);

    // Fetching specific details
    Task<IEnumerable<ICarRepository>> GetAllModelsByManufacturer(String Manufacturer);




}
