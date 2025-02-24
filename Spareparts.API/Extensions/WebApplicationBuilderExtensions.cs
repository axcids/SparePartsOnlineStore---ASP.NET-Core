using Microsoft.OpenApi.Models;

namespace Spareparts.API.Extensions; 
public static class WebApplicationBuilderExtensions {
    public static void AddPresentation(this WebApplicationBuilder builder) {
        builder.Services.AddControllers();
        builder.Services.AddSwaggerGen(c => { 
            
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Spareparts API", Version = "v1" });
            c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme { 
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                    },
                    []
                }
            });
            builder.Services.AddAuthorization();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddAuthentication();   
        });
    }
}
