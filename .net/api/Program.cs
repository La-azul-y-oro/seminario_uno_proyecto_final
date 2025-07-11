using System.Text;
using api.Auth;
using api.Context;
using api.Mappers;
using api.Services.Implementations;
using api.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Configuracion de la cadena de conexion desde appsettings.json
string connectionString = builder.Configuration.GetConnectionString("MySqlConnection");

builder.Services.AddHttpContextAccessor();

// Configuracion de servicios
builder.Services.AddScoped<IConceptService, ConceptService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IConsortiumService, ConsortiumService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFunctionalUnitService, FunctionalUnitService>();
builder.Services.AddScoped<IMovementService, MovementService>();
builder.Services.AddScoped<ILiquidationService, LiquidationService>();

builder.Services.AddScoped<IReportService, ReportService>();


builder.Services.AddSingleton<JwtService>();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<UserMapper>();
builder.Services.AddScoped<FunctionalUnitMapper>();
builder.Services.AddScoped<ConsortiumMapper>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Consorcio API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Por favor ingresa el token JWT en el campo. Ejemplo: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

// Registrar DbContext para EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32))));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        }; 
    });

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

QuestPDF.Settings.License = LicenseType.Community;

var app = builder.Build();

// Configuracion de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1"));
}

app.UseCors("AllowAnyOrigin");
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.Run();
