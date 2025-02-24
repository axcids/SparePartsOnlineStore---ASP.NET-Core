using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spareparts.Application; 
public static class ServiceCollectionExtensions {

    public static void AddApplication(this IServiceCollection services) {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;



    }
}
