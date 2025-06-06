using Microsoft.Identity.Client;
using Spareparts.API.Extensions;
using Spareparts.Application;
using Spareparts.Infrastructure.Extensions;
using Spareparts.Infrastructure.Seeders;
using Spareparts.Application.Extensions;
using Spareparts.API.Middlewares;

//Create builder:
var builder = WebApplication.CreateBuilder(args);

//Add Builders Extensions:

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails(options => {
    options.CustomizeProblemDetails = context => {
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
    };
});

builder.AddPresentation();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

//Read from the appsettings file
var ConnectionString = builder.Configuration.GetConnectionString("OfficeConnection");
var settingsAppName = builder.Configuration["Settings:AppName"];
var settingsContactEmail = builder.Configuration["Settings:ContactEmail"];

//Building the application pipeline
var app = builder.Build();

// Configure the HTTP request pipeline.

//app.UseMiddleware<ErrorHandlingMiddle>();
app.UseExceptionHandler();

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

//Middlewares
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.UseHttpsRedirection();
app.Run();
