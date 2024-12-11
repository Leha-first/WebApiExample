using Application;
using Application.Logic.Grades;
using FluentValidation;
using Infrastructure;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using Presentation.GlobalExceptionHandling;
using Presentation.Services;
using System.Globalization;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Presentation.WebApplicationExtensions;

public static class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder ConfigureApplicationBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.Configure<JsonOptions>(opt =>
        {
            opt.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            opt.SerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            opt.SerializerOptions.PropertyNameCaseInsensitive = true;
            opt.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            opt.SerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        });

        // Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase(builder.Environment.EnvironmentName)}",
                    Description = "Пример реализации web api",
                });

            options.DocInclusionPredicate((_, _) => true);
        });


        builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(), ServiceLifetime.Singleton);

        // Зависимости
        builder.Services.AddInfrastructureDependency(builder.Configuration.GetConnectionString("DefaultConnection"));
        builder.Services.AddApplicationDependency();
        builder.Services.AddScoped<IProcessGradesService, ProcessGradesService>();

        // Глобальная обработка исключений
        builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
        builder.Services.AddProblemDetails();

        return builder;
    }
}