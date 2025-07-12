using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using Spareparts.Infrastructure.Repositories;
using Spareparts.Infrastructure.Seeders;


namespace Spareparts.Infrastructure.Extensions {
    public static class ServiceCollectionExtensions {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("HomeConnection");
            services.AddDbContext<SparepartsDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            //Add Scoped Entities ....
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            //Add Scoped Seeders ....
            services.AddScoped<ICategorySeeder, CategorySeeder>();
            services.AddScoped<IManufacturerSeeder, ManufacturerSeeder>();

        }
    }
}
