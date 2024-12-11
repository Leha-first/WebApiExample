using MediatR;

namespace Application.Logic.Grades.Commands;

/// <summary>
/// Команда на удаление оценки
/// </summary>
public class DeleteGradeCommand : IRequest<bool>
{
    /// <summary>
    /// Идентификатор оценки
    /// </summary>
    public Guid Id { get; set; }
}