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

    public async Task<bool> DeleteCar(Guid carId) {
        var entity = dbContext.Cars.FirstOrDefault(x => x.Id == carId);
        dbContext.Cars.Remove(entity);
        var isDeleted = await dbContext.SaveChangesAsync();
        if(isDeleted == 1) {
            return true;
        }
        else {
            return false;
        }
    }

    public async Task<IEnumerable<Car>> GetAllcars() {
        var AllCars = dbContext.Cars.ToList();
        return AllCars;
    }

}
