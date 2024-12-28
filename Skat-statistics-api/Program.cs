using Scalar.AspNetCore;
using Skat_statistics_api.Services;
using Skat_statistics_api.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<PlayerService>();
//builder.Services.AddScoped<DatabaseService>();
builder.Services.AddOpenApi();
builder.Services.AddControllers();

// Add database connection string
builder.Configuration.AddJsonFile("appsettings.json");

// Load configuration (connection string) from appsettings.json
//var configuration = builder.Configuration;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SkatStatisticsContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.DeepSpace);    
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
