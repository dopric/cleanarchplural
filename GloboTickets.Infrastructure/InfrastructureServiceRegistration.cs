using GloboTickets.Application.Contracts.Infrastructure;
using GloboTickets.Application.Models.Mail;
using GloboTickets.Infrastructure.Services.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GloboTickets.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(options=>configuration.GetSection("EmailSettings"));
        services.AddScoped<IEmailService, EmailService>();
        return services;
    }
}