using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace API.Extensions;

public static class DatabaseMigrationExtensions
{
    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
            appDbContext.Database.Migrate();
            logger.LogInformation("Database migrations applied automatically");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to apply database migrations.");
        }

        return app;
    }
}
