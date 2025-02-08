using api.Context;
using api.Models;
using api.Services.Implementations;
using api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión desde appsettings.json
string connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

// Configuración de servicios
builder.Services.AddScoped<IGenericService<Concept, int>, ConceptService>();
builder.Services.AddScoped<IGenericService<Supplier, long>, SupplierService>();
builder.Services.AddScoped<IGenericService<Consortium, int>, ConsortiumService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consorcio API", Version = "v1" });
});

// Registrar DbContext para EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))));

var app = builder.Build();

// Configuración de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
