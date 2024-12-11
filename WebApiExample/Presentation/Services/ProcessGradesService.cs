using Application.Logic.Grades;
using Domain.CommonTypes.Records;
using Domain.Grades;
using MediatR;
using Commands = Application.Logic.Grades.Commands;
using Queries = Application.Logic.Grades.Queries;

namespace Presentation.Services;

public class ProcessGradesService : IProcessGradesService
{
    private IMediator _mediator;

    public ProcessGradesService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<IResult> GetGradesByProductIdAsync(AdvancedProductData productData)
    {
        var gradesByProductId = await _mediator.Send(new Queries.GetGradesByProductIdQuery { ProductData = productData });
        return Results.Ok(gradesByProductId);
    }

    public async Task<IResult> GetGradesByUserIdAsync(Guid userId)
    {
        var gradesByUserId = await _mediator.Send(new Queries.GetGradesByUserIdQuery { UserId = userId });
        return Results.Ok(gradesByUserId);
    }

    public async Task<IResult> GetAverageGradeByProductIdAsync(AdvancedProductData productData)
    {
        return Results.Ok(await _mediator.Send(new Queries.GetAverageGradeByProductIdQuery
        { ProductData = productData }));
    }

    public async Task<IResult> CreateGradeAsync(Grade grade)
    {
        await _mediator.Send(new Commands.CreateGradeCommand
        {
            Id = grade.Id,
            Rating = grade.Rating,
            Review = grade.Review,
            ProductId = grade.ProductId,
            UserId = grade.UserId
        });

        return Results.NoContent();
    }

    public async Task<IResult> UpdateGradeAsync(Grade grade)
    {
        await _mediator.Send(new Commands.UpdateGradeCommand
        {
            Id = grade.Id,
            Rating = grade.Rating,
            Review = grade.Review,
            UserId = grade.UserId
        });

        return Results.NoContent();
    }

    public async Task<IResult> DeleteGradeAsync(Guid gradeId)
    {
        await _mediator.Send(new Commands.DeleteGradeCommand
        {
            Id = gradeId
        });

        return Results.NoContent();
    }
}