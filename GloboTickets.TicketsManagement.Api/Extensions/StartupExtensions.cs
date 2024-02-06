using GloboTickets.Application;
using GloboTickets.Infrastructure;
using Microsoft.EntityFrameworkCore.Query;

namespace GloboTickets.TicketsManagement.Api.Extensions;

public static class StartupExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddApplicationServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);
        builder.Services.AddPersistanceServices(builder.Configuration);
        
        builder.Services.AddCors(options => options.AddPolicy(
            "open",
            policy => policy.WithOrigins(new string[] {
                    builder.Configuration["AppUrl"] ?? "https://localhost:7020",
                    builder.Configuration["BlazorUrl"] ?? "https://localhost:7080"
                })
                .AllowAnyHeader()
                .SetIsOriginAllowed(pol => true)
                .AllowAnyMethod()
                .AllowCredentials()));
        
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseCors("open");
        app.UseHttpsRedirection();
        app.MapControllers();
        return app;
    }
    
    // Clean up the database before running the tests
    public static async Task ResetDatabaseAsync(this WebApplication app)
    {
        using var serviceScope = app.Services.CreateScope();
        try
        {
            var context = serviceScope.ServiceProvider.GetRequiredService<GloboTickets.Infrastructure.Data.GloboTicketsDbContext>();
            if (context != null)
            {
                await context.Database.EnsureDeletedAsync();
                await context.Database.EnsureCreatedAsync();
            }
        }catch(Exception ex)
        {
            var logger = serviceScope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        }
      
    }
}