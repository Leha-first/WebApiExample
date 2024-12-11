using Application.Logic.Grades;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureDependency(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<GradesDbContext>(options => { options.UseSqlite(connectionString); });
        services.AddScoped<IGradesRepository, GradesRepository>();
    }
}