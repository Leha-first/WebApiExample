using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class DependencyInjection
{
    /// <summary>
    /// Регистрация обработчиков и типов для Mediatr
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static void AddApplicationDependency(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }
}