using Domain.CommonTypes.Records;
using MediatR;

namespace Application.Logic.Grades.Queries;

/// <summary>
/// Запрос получения средней оценки по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
/// </summary>
public class GetAverageGradeByProductIdQuery : IRequest<double>
{
    /// <summary>
    /// <inheritdoc cref="AdvancedProductData"/>
    /// </summary>
    public AdvancedProductData ProductData { get; set; }
}