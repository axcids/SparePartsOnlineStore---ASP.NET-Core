
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Spareparts.Application.Extensions; 
public static class ServiceCollectionExtensions {
    public static void AddApplication(this IServiceCollection service) {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;
        
        service.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));
        service.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidation();
    }
}
