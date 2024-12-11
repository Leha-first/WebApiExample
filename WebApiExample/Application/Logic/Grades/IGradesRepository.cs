using Domain.CommonTypes.Records;
using Domain.Grades;

namespace Application.Logic.Grades;

/// <summary>
/// Интерфейс для обеспчения функциональности репозитория оценок
/// </summary>
public interface IGradesRepository
{
    /// <summary>
    /// Получение средней оценки по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
    /// </summary>
    /// <param name="productData"> Данные по продукту для обеспечения запросов </param>
    /// <param name="cancellationToken"> <inheritdoc cref="CancellationToken"/> </param>
    /// <returns> Последовательность оценок </returns>
    Task<IEnumerable<Grade>> GetGradesByProductIdAsync(AdvancedProductData productData, CancellationToken cancellationToken);
    /// <summary>
    /// Получение средней оценки по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
    /// </summary>
    /// <param name="productData"> Данные по продукту для обеспечения запросов </param>
    /// <param name="cancellationToken"> <inheritdoc cref="CancellationToken"/> </param>
    /// <returns> Значение </returns>
    Task<double> GetAverageGradeByProductIdAsync(AdvancedProductData productData, CancellationToken cancellationToken);
    /// <summary>
    /// Получение оценок по идентификатору пользователя
    /// </summary>
    /// <param name="userId"> Идентификатор пользователя </param>
    /// <param name="cancellationToken"> <inheritdoc cref="CancellationToken"/> </param>
    /// <returns> Последовательность оценок </returns>
    Task<IEnumerable<Grade>> GetGradesByUserIdAsync(Guid userId, CancellationToken cancellationToken);
    /// <summary>
    /// Cоздание оценки
    /// </summary>
    /// <param name="grade"> Оценка </param>
    /// <param name="cancellationToken"> <inheritdoc cref="CancellationToken"/> </param>
    /// <returns> Созданная оценка </returns>
    Task<Grade> CreateGradeAsync(Grade grade, CancellationToken cancellationToken);
    /// <summary>
    /// Обновление оценки
    /// </summary>
    /// <param name="grade"> Оценка </param>
    /// <param name="cancellationToken"> <inheritdoc cref="CancellationToken"/> </param>
    /// <returns> Обновленная оценка </returns>
    Task<Grade> UpdateGradeAsync(Grade grade, CancellationToken cancellationToken);
    /// <summary>
    /// Удаление оценки
    /// </summary>
    /// <param name="gradeId"> Идентификатор оценки </param>
    /// <param name="cancellationToken"> <inheritdoc cref="CancellationToken"/> </param>
    /// <returns> Успех операции удаления </returns>
    Task<bool> DeleteGradeAsync(Guid gradeId, CancellationToken cancellationToken);
}