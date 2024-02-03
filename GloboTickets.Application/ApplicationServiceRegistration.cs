using System.Reflection;
using GloboTickets.Application.Profiles;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTickets.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var config = new TypeAdapterConfig();
        var mappingProfile = new MappingProfile();
        mappingProfile.Register(config);
        services.AddSingleton(config);
        
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
        
        return services;
    }
}