using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostApp.Application.Interfaces.Repositories;
using PostApp.Application.Interfaces.Services;
using PostApp.Infra.Repositories;
using PostApp.Infra.Services;
using PostApp.Infra.Data;
using PostApp.Application.Common.Models;

namespace PostApp.Infra;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add JWT Settings
        services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
        
        // Add Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        // Add repositories
        services.AddScoped<IManagerRepository, ManagerRepository>();
        services.AddScoped<IDriverRepository, DriverRepository>();
        services.AddScoped<IMissionRepository, MissionRepository>();
        
        // Add services
        services.AddScoped<IJwtService, JwtService>();
        
        return services;
    }
}