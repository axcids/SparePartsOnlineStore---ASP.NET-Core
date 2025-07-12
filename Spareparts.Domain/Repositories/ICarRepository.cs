using Spareparts.Domain.Entities;
using System.Threading.Tasks;

namespace Spareparts.Domain.Repositories; 
public interface ICarRepository {

    // Add new car 
    Task<Guid> AddNewCar(Car car);

    // Delete car 
    Task<bool> DeleteCarById(Guid carId);
    Task<bool> DeleteCarsByManufacturerId(Guid carId);

    // Update car

    // Fetching all cars 
    Task<IEnumerable<Car>> GetAllcars();

    //Fetch Cars by specific data
    Task<Car> GetCarById(Guid carId);
    Task<IEnumerable<Car>> GetCarsByManufacturerId(Guid manfacturerId);

    // Update car by Id
    Task<Car?> UpdateCarById(Guid carId, Car newCar);

    // Update car Model
    Task<Car?> UpdateCarModel(Guid CarId, string newModel);

    // Saving Changes 
    Task SaveChanges();

}
