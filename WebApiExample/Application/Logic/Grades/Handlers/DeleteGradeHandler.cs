using Application.Logic.Grades.Commands;
using MediatR;

namespace Application.Logic.Grades.Handlers;

/// <summary>
/// Обработчик удаления оценки
/// </summary>
internal class DeleteGradeHandler(IGradesRepository gradesRepository) : IRequestHandler<DeleteGradeCommand, bool>
{
    public async Task<bool> Handle(DeleteGradeCommand request, CancellationToken cancellationToken)
    {
        return await gradesRepository.DeleteGradeAsync(request.Id, cancellationToken);
    }
}