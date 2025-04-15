using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Spareparts.Domain.Entities;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using System.Threading.Tasks;

namespace Spareparts.Infrastructure.Repositories;
internal class CarRepository(SparepartsDbContext dbContext) : ICarRepository {
    public async Task<Guid> AddNewCar(Car entity) {
        dbContext.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id; // This might be error 
    }
    public async Task<IEnumerable<Car>> GetAllcars() {
        var AllCars = dbContext.Cars.ToList();
        return AllCars;
    }

    public async Task<Car> GetCarById(Guid carId) {
        var car = dbContext.Cars.FirstOrDefault(o => o.Id == carId);
        return car;
    }
    public async Task<IEnumerable<Car>>GetCarsByManufacturerId(Guid manufacturerId) {
        var cars = await dbContext.Cars.Where(o => o.ManufacturerId == manufacturerId).ToListAsync();
        return cars;
    }

    public async Task<Car?> UpdateCarModel(Guid CarId, string newModel) {
        var car = await dbContext.Cars.FirstOrDefaultAsync(r => r.Id == CarId);
        if (car == null) return null;
        car.Model = newModel;
        dbContext.Cars.Update(car);
        return car;
    }
    public async Task<Car?> UpdateCarById(Guid carId, Car newCar) {
        var car = await dbContext.Cars.FirstOrDefaultAsync(r => r.Id == carId);
        if (car == null) return null;
        car.ManufacturerId = newCar.ManufacturerId;
        car.Model = newCar.Model;
        car.ModelYear = newCar.ModelYear;
        car.TrimLevel = newCar.TrimLevel;
        car.BodyStyle = newCar.BodyStyle;
        car.TransmissionType = newCar.TransmissionType;
        car.FuelType = newCar.FuelType;
        dbContext.Cars.Update(car);
        return car;
    }
    public async Task<bool> DeleteCarById(Guid carId) {
        var entity = dbContext.Cars.FirstOrDefault(x => x.Id == carId);
        dbContext.Cars.Remove(entity);
        var isDeleted = await dbContext.SaveChangesAsync();
        if (isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }
    public async Task<bool> DeleteCarsByManufacturerId(Guid manufacturerId) {
        var cars = await GetCarsByManufacturerId(manufacturerId);
        if (cars == null || !cars.Any()) {
            // Return false if there were no cars to delete.
            return false;
        }
        dbContext.Cars.RemoveRange(cars);
        return true;

    }
    public async Task SaveChanges() {
        await dbContext.SaveChangesAsync();
    }
}
