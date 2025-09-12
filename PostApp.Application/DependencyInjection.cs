using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace PostApp.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Add MediatR
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly);
        });

        // Add FluentValidation
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);

        return services;
    }
}