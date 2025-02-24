using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface ICars {

    // Add new car 
    Task<Guid> AddNewCar(ProductDetails entity);
    
    // Delete car 
    Task DeleteCarById(Guid carId);

    // Update car

    // Fetching all cars 
    Task<IEnumerable<ICars>> GetAllcars();
    Task<IEnumerable<ICars>> GetAllcarsByManufacturer(String Manufacturer);
    Task<IEnumerable<ICars>> GetAllcarsByYear(int ModelYear);

    // Fetching specific details
    Task<IEnumerable<ICars>> GetAllModelsByManufacturer(String Manufacturer);



}
