using Application.Logic.Grades.Queries;
using MediatR;

namespace Application.Logic.Grades.Handlers;

/// <summary>
/// Обработчик получения средней оценки по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
/// </summary>
public class GetAverageGradeByProductIdHandler(IGradesRepository gradesRepository) : IRequestHandler<GetAverageGradeByProductIdQuery, double>
{
    public async Task<double> Handle(GetAverageGradeByProductIdQuery request, CancellationToken cancellationToken)
    {
        return await gradesRepository.GetAverageGradeByProductIdAsync(request.ProductData, cancellationToken);
    }
}