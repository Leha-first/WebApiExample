using Domain.CommonTypes.Records;
using Domain.Grades;
using Microsoft.AspNetCore.Http;

namespace Application.Logic.Grades;

public interface IProcessGradesService
{
    /// <summary>
    /// Получение средней оценки по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
    /// </summary>
    /// <param name="productData"> Данные по продукту для обеспечения запросов </param>
    /// <returns> <inheritdoc cref="IResult"/> </returns>
    Task<IResult> GetGradesByProductIdAsync(AdvancedProductData productData);
    /// <summary>
    /// Получение средней оценки по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
    /// </summary>
    /// <param name="productData"> Данные по продукту для обеспечения запросов </param>
    /// <returns> <inheritdoc cref="IResult"/> </returns>
    Task<IResult> GetAverageGradeByProductIdAsync(AdvancedProductData productData);
    /// <summary>
    /// Получение оценок по идентификатору пользователя
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя </param>
    /// <returns> <inheritdoc cref="IResult"/> </returns>
    Task<IResult> GetGradesByUserIdAsync(Guid userId);
    /// <summary>
    /// Cоздание оценки
    /// </summary>
    /// <param name="grade"> Оценка </param>
    /// <returns> <inheritdoc cref="IResult"/> </returns>
    Task<IResult> CreateGradeAsync(Grade grade);
    /// <summary>
    /// Обновление оценки
    /// </summary>
    /// <param name="grade"> Оценка </param>
    /// <returns> <inheritdoc cref="IResult"/> </returns>
    Task<IResult> UpdateGradeAsync(Grade grade);
    /// <summary>
    /// Удаление оценки
    /// </summary>
    /// <param name="gradeId"> Идентификатор оценки </param>
    /// <returns> <inheritdoc cref="IResult"/> </returns>
    Task<IResult> DeleteGradeAsync(Guid gradeId);
}