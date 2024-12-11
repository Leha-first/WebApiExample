using Application.Logic.Grades.Commands;
using Domain.Grades;
using MediatR;

namespace Application.Logic.Grades.Handlers;

/// <summary>
/// Обработчик создания оценки
/// </summary>
/// <param name="gradesRepository"></param>
public class CreateGradeHandler(
    IGradesRepository gradesRepository) : IRequestHandler<CreateGradeCommand, Grade>
{
    public async Task<Grade> Handle(CreateGradeCommand request, CancellationToken cancellationToken)
    {
        return await gradesRepository.CreateGradeAsync(
            new Grade
            {
                Id = request.Id,
                Rating = request.Rating,
                Review = request.Review,
                UserId = request.UserId,
                ProductId = request.ProductId
            }, cancellationToken);
    }
}