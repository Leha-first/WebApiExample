using Presentation.Endpoints;
using System.Globalization;

namespace Presentation.WebApplicationExtensions;

public static class WebApplicationConfigurationExtensions
{
    public static WebApplication ConfigureApplication(this WebApplication app)
    {
        app.UseHsts();

        app.UseHttpsRedirection();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
            c.SwaggerEndpoint(
                "/swagger/v1/swagger.json",
                $"WebApiExample - {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(app.Environment.EnvironmentName)} - V1"));

        // конфигурация точек
        app.MapGradesEndpoints();
        // обработка исключений
        app.UseExceptionHandler();

        return app;
    }
}