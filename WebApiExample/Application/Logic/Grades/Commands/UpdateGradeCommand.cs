using Domain.Grades;
using MediatR;

namespace Application.Logic.Grades.Commands;

/// <summary>
/// Команда на обновление оценки
/// </summary>
public class UpdateGradeCommand : IRequest<Grade>
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Отзыв пользователя о продукте
    /// </summary>
    public string Review { get; set; }
    /// <summary>
    /// Количество звезд выбранных пользователем (от 0 до 5)
    /// </summary>
    public int Rating { get; set; }
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; }
}