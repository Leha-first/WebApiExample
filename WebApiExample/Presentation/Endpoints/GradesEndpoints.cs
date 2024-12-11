using Application.Logic.Grades;
using Domain.CommonTypes.Records;
using Domain.Grades;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Endpoints;

public static class GradesEndpoints
{
    /// <summary>
    /// Формирование endpoints для оценок
    /// </summary>
    /// <param name="app"> <inheritdoc cref="WebApplication"/> </param>
    public static void MapGradesEndpoints(this WebApplication app)
    {
        var root = app.MapGroup("/api/grade")
            .WithTags("grade")
            .WithDescription("Функционал по оценкам продуктов(grades)")
            .WithOpenApi();

        root.MapGet(
                "/GetGradesByProductIdAsync",
                async ([FromServices] IProcessGradesService processGradesService, [AsParameters] AdvancedProductData productData) =>
                    await processGradesService.GetGradesByProductIdAsync(productData))
            .WithSummary("Получение оценок по идентификатору продукта с пагинацией и сортировкой")
            .WithDescription("\n GetGradesByProductIdAsync");

        root.MapGet("/GetAverageGradeByProductIdAsync",
                async ([FromServices] IProcessGradesService processGradesService,
                        [AsParameters] AdvancedProductData productData) =>
                    await processGradesService.GetAverageGradeByProductIdAsync(productData))
            .WithSummary("Получение средней оценки по продукту с пагинацией и сортировкой")
            .WithDescription("\n GetGradesByProductIdAsync");

        root.MapGet("/GetGradesByUserIdAsync/{userId:guid}",
                async ([FromServices] IProcessGradesService processGradesService, Guid userId) =>
                await processGradesService.GetGradesByUserIdAsync(userId))
            .WithSummary("Получение оценок по идентификатору пользователя")
            .WithDescription("\n GetGradesByProductIdAsync/00000000-0000-0000-0000-000000000000");

        root.MapPost("/CreateGradeAsync",
                async ([FromServices] IProcessGradesService processGradesService, Grade grade) =>
                await processGradesService.CreateGradeAsync(grade))
            .WithSummary("Создание оценки пользователем")
            .WithDescription("\n CreateGradeAsync");

        root.MapPut("/UpdateGradeAsync",
                async ([FromServices] IProcessGradesService processGradesService, Grade grade) =>
                await processGradesService.UpdateGradeAsync(grade))
            .WithSummary("Редактирование оценки пользователем")
            .WithDescription("\n UpdateGradeAsync");

        root.MapDelete("/DeleteGradeAsync/{gradeId:guid}",
                async ([FromServices] IProcessGradesService processGradesService, Guid gradeId) =>
                await processGradesService.DeleteGradeAsync(gradeId))
            .WithSummary("Удаление оценки по идентификатору")
            .WithDescription("\n DeleteGradeAsync/00000000-0000-0000-0000-000000000000");
    }
}