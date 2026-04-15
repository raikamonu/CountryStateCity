
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddControllers();

// ?? Swagger (correct setup)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ?? Connection String
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine(connectionString);

// ?? Dependency Injection
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ProfileRepository>();

// ?? DbContext
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// ?? Swagger Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // ?? ye missing tha
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();