using Microsoft.Identity.Client;
using Spareparts.API.Extensions;
using Spareparts.Application;
using Spareparts.Infrastructure.Extensions;
using Spareparts.Infrastructure.Seeders;
using Spareparts.Application.Extensions;
using Spareparts.API.Middlewares;

//Create builder:
var builder = WebApplication.CreateBuilder(args);

//Add Extensions builders:
builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Adding Middlewares 
builder.Services.AddScoped<ErrorHandlingMiddle>();

// Read from the appsettings file some variables.
var ConnectionString = builder.Configuration.GetConnectionString("OfficeConnection");
var settingsAppName = builder.Configuration["Settings:AppName"];
var settingsContactEmail = builder.Configuration["Settings:ContactEmail"];

//Building the application pipeline
var app = builder.Build();


// =======================================
// Configure the HTTP request pipeline.
// =======================================


// Use 
app.UseMiddleware<ErrorHandlingMiddle>();

// Configure the development application enviroment 
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seeding data using a sccoped service 
using (var scope = app.Services.CreateScope()) {
    var CategoySeeder = scope.ServiceProvider.GetRequiredService<ICategorySeeder>();
    var ManufacturerSeeder = scope.ServiceProvider.GetRequiredService<IManufacturerSeeder>();

    // Adding the seeders 
    await CategoySeeder.Seed();
    await ManufacturerSeeder.Seed();
}

//  Using the app services
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
