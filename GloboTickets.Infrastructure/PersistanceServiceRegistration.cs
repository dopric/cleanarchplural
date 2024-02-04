using GloboTickets.Application.Contracts.Persistance;
using GloboTickets.Infrastructure.Data;
using GloboTickets.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTickets.Infrastructure;

public static class PersistanceServiceRegistration
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<GloboTicketsDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("GloboTicketsConnectionString"));
        });
        services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IEventRepository, EventsRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();

        return services;
    }
}