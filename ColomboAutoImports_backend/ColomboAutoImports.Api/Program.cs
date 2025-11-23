using ColomboAutoImports.Api;
using ColomboAutoImports.Api.MappingProfiles;
using ColomboAutoImports.Core.Interfaces.Repositories;
using ColomboAutoImports.Core.Interfaces.Services;
using ColomboAutoImports.Core.Services;
using ColomboAutoImports.Infrastructure;
using ColomboAutoImports.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddAutoMapper(typeof(VehicleDetailsMappings).Assembly);

builder.Services.AddScoped<IVehicleDetailsRepository, VehicleDetailsRepository>();
builder.Services.AddScoped<IVehicleDetailsService, VehicleDetailsService>();
builder.Services.AddScoped<IEstimationService, EstimationService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
