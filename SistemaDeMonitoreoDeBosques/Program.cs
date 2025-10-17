
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SistemaDeMonitoreoDeBosques.Core.Interfaces;
using SistemaDeMonitoreoDeBosques.Core.Services;
using SistemaDeMonitoreoDeBosques.Infraestructure.Data;
using SistemaDeMonitoreoDeBosques.Infraestructure.Filterss;
using SistemaDeMonitoreoDeBosques.Infraestructure.Mappings;
using SistemaDeMonitoreoDeBosques.Infraestructure.Repositories;
using SistemaDeMonitoreoDeBosques.Infraestructure.Validators;
using SistemaDeMonitoreoDeBosques.Infraestructure.Validatorss;

namespace SistemaDeMonitoreoDeBosques
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("ConnectionMySql");
            builder.Services.AddDbContext<ForestMonitoringDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                b=> b.MigrationsAssembly("SistemaDeMontireoDeBosques.Infraestructure")));
            
            builder.Services.AddAutoMapper(cfg => { }, typeof(MappingForest).Assembly);


            builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
            builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
            builder.Services.AddScoped<IVisitorService, VisitorService>();
            builder.Services.AddScoped<IVehicleService, VehicleService>();

            builder.Services.AddValidatorsFromAssemblyContaining<VisitorDtoValidator>();

            // Servicio de validación
            builder.Services.AddScoped<IValidationService, ValidationService>();

            // Filtro global
            builder.Services.AddControllers(opt => opt.Filters.Add<ValidationFilter>());



            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
