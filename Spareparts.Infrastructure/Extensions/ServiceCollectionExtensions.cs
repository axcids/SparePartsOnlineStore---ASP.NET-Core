using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Spareparts.Domain.Repositories;
using Spareparts.Infrastructure.Persistence;
using Spareparts.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spareparts.Infrastructure.Extensions {
    public static class ServiceCollectionExtensions {

        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("OfficeConnection");
            services.AddDbContext<SparepartsDbContext>(options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging());

            //Add Scoped Repositories down here ....
            services.AddScoped<IProductDetailsRepository, ProductDetailsRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IManufacturerRepository, ManufacturerRepository>();



        }
    }
}
