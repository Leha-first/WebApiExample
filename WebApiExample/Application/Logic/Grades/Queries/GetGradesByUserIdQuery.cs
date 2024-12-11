using Domain.Grades;
using MediatR;

namespace Application.Logic.Grades.Queries;

/// <summary>
/// Запрос получения оценок по пользователю
/// </summary>
public class GetGradesByUserIdQuery : IRequest<IEnumerable<Grade>>
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
}