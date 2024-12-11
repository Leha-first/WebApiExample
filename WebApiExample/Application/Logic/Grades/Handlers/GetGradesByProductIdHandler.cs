using Application.Logic.Grades.Queries;
using Domain.Grades;
using MediatR;

namespace Application.Logic.Grades.Handlers;

/// <summary>
/// Обработчик получения оценок по продукту с пагинацией и сортировкой (по убыванию или возрастанию оценки)
/// </summary>
public class GetGradesByProductIdHandler(IGradesRepository gradesRepository) : IRequestHandler<GetGradesByProductIdQuery, IEnumerable<Grade>>
{
    public async Task<IEnumerable<Grade>> Handle(GetGradesByProductIdQuery request, CancellationToken cancellationToken)
    {
        return await gradesRepository.GetGradesByProductIdAsync(request.ProductData, cancellationToken);
    }
}