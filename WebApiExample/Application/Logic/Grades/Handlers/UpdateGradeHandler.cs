using Application.Logic.Grades.Commands;
using Domain.Grades;
using MediatR;

namespace Application.Logic.Grades.Handlers;

/// <summary>
/// Обработчик обновления оценки
/// </summary>
public class UpdateGradeHandler(IGradesRepository gradesRepository) : IRequestHandler<UpdateGradeCommand, Grade>
{
    public async Task<Grade> Handle(UpdateGradeCommand request, CancellationToken cancellationToken)
    {
        return await gradesRepository.UpdateGradeAsync(
            new Grade { Id = request.Id, Rating = request.Rating, Review = request.Review, UserId = request.UserId }, cancellationToken);
    }
}