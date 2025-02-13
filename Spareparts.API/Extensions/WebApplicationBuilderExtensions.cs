using Microsoft.OpenApi.Models;

namespace Spareparts.API.Extensions; 
public static class WebApplicationBuilderExtensions {
    public static void AddPresentation(this WebApplicationBuilder builder) {
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c => {
            c.SwaggerDoc("V1", new OpenApiInfo { Title = "SparepartsAPIs", Version = "v1" });
            c.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme {
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });
            

        });
    }
}
