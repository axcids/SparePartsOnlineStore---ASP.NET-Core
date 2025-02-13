//Create builder
var builder = WebApplication.CreateBuilder(args);
//Add Builders Extensions 


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Read from the appsettings file
var ConnectionString = builder.Configuration.GetConnectionString("OfficeConnection");
var settingsAppName = builder.Configuration["Settings:AppName"];
var settingsContactEmail = builder.Configuration["Settings:ContactEmail"];

//Building the application pipeline
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Middlewares
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
