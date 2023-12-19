using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WarsztatApi.Security.Interfaces;
using WarsztatApi.Security;
using WarsztatApi.Repo;
using WarsztatApi.Repo.Interfaces;
using WarsztatApi.Services;
using WarsztatApi.Services.Interfaces;
using DB;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodaj konfiguracjê CORS w metodzie ConfigureServices
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dodaj DbContext z biblioteki DB
builder.Services.AddDbContext<MyDbContext>(options =>
{
    // Pobierz ConnectionString z konfiguracji
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // Skonfiguruj DbContext z uwzglêdnieniem ConnectionString
    options.UseSqlServer(connectionString);
});

// Dodaj repozytorium i serwis
    builder.Services.AddScoped<ISecurity, Security>();

//REPOZYTORIA 
    builder.Services.AddScoped<IPersonRepository, PersonRepository>();
    builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
    builder.Services.AddScoped<ICarRepository, CarRepository>();

//SERWISY
    builder.Services.AddScoped<IPersonService, PersonService>();
    builder.Services.AddScoped<IUserTypeService, UserTypeService>();
    builder.Services.AddScoped<ICarService, CarService>();

//konfiguracja kontrolerów i swagera



// Pozosta³a konfiguracja
var app = builder.Build();

// Dodaj obs³ugê CORS w metodzie Configure
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Dodaj obs³ugê CORS przed UseAuthorization
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
