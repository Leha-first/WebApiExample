using Application.Logic.Grades.Queries;
using Domain.Grades;
using MediatR;

namespace Application.Logic.Grades.Handlers;

/// <summary>
/// Обработчик получения оценок по пользователю
/// </summary>
public class GetGradesByUserIdHandler(IGradesRepository gradesRepository) : IRequestHandler<GetGradesByUserIdQuery, IEnumerable<Grade>>
{
    public async Task<IEnumerable<Grade>> Handle(GetGradesByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await gradesRepository.GetGradesByUserIdAsync(request.UserId, cancellationToken);
    }
}