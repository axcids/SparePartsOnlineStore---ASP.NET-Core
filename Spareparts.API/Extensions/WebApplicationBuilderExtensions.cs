using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

namespace Spareparts.API.Extensions; 
public static class WebApplicationBuilderExtensions {
    public static void AddPresentation(this WebApplicationBuilder builder) {
        // Adding Controllers services
        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        }); 
        // Adding Swagger services
        builder.Services.AddSwaggerGen(c => {
            // Adding Swagger documentation
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Spareparts API", Version = "v1" });
            // Adding Security definition for JWT Bearer
            c.AddSecurityDefinition("bearer", new OpenApiSecurityScheme { 
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
            });
            // Adding Security Requirement for JWT Bearer
            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference{Type = ReferenceType.SecurityScheme, Id = "bearerAuth"}
                    },
                    []
                }
            });

            // Adding Authentication and Authorization services
            builder.Services.AddAuthorization();
            // Adding Endpoints API Explorer  
            builder.Services.AddEndpointsApiExplorer();



        });
    }
}
