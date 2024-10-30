using Skat_statistics_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Load configuration (connection string) from appsettings.json
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();

// Register DatabaseService with the connection string from configuration
builder.Services.AddSingleton(new DatabaseService(configuration));

// Configure Swagger/OpenAPI
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Your API",
        Version = "v1",
        Description = "API documentation for your project.",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Your Name",
            Email = "you@example.com",
            Url = new Uri("https://yourwebsite.com")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
