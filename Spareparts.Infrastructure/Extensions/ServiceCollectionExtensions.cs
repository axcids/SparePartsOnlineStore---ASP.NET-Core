using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using Spareparts.Infrastructure.Repositories;
using Spareparts.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spareparts.Infrastructure.Extensions {
    public static class ServiceCollectionExtensions {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("HomeConnection");
            services.AddDbContext<SparepartsDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            //Add Scoped Entities ....
            services.AddScoped<IProductDetailsRepository, ProductDetailsRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ICarProductRepository, CarProductRepository>();

            //Add Scoped Seeders ....
            services.AddScoped<ICategorySeeder, CategorySeeder>();
            services.AddScoped<IManufacturerSeeder, ManufacturerSeeder>();




        }
    }
}
