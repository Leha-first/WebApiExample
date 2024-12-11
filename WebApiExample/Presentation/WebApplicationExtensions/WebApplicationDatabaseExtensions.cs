using Infrastructure.Contexts;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Presentation.WebApplicationExtensions;

public static class WebApplicationDatabaseExtensions
{
    /// <summary>  
    /// Миграция базы данных   
    /// </summary>  
    /// <typeparam name="T"> <inheritdoc cref="DbContext"/> </typeparam> 
    /// <returns> WebApplication </returns>  
    public static WebApplication CreateDatabase<T>(this WebApplication app) where T : DbContext
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        try
        {
            var db = services.GetRequiredService<T>();
            db.Database.Migrate();
            if (db is GradesDbContext context) context.AddDataAsync();
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "Database Creation/Migrations failed!");
        }

        return app;
    }
}