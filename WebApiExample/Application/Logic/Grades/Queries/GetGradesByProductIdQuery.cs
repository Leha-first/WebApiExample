using Domain.CommonTypes.Records;
using Domain.Grades;
using MediatR;

namespace Application.Logic.Grades.Queries;

/// <summary>
/// Запрос получения оценок по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
/// </summary>
public class GetGradesByProductIdQuery : IRequest<IEnumerable<Grade>>
{
    /// <summary>
    /// <inheritdoc cref="AdvancedProductData"/>
    /// </summary>
    public AdvancedProductData ProductData { get; set; }
}