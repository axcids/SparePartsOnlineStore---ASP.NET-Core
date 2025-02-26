using Spareparts.Domain.Entities;
using Spareparts.Infrastructure.Persistence;

namespace Spareparts.Infrastructure.Seeders;
internal class ManufacturerSeeder(SparepartsDbContext dbContext) : IManufacturerSeeder {
    public async Task Seed() {
        if (await dbContext.Database.CanConnectAsync()) {
            if (!dbContext.Manufacturers.Any()) {
                var Manufacturers = GetManufacturer();
                dbContext.AddRange(Manufacturers);
                await dbContext.SaveChangesAsync();
            }
        }
    }
    private IEnumerable<Manufacturer> GetManufacturer() {
        List<Manufacturer> manfacturers = [
                new(){
                    Name = "BMW Group",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                },
                new(){
                    Name = "Mercedes-Benz",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                }
               
        ];
        return manfacturers;
    }
}
