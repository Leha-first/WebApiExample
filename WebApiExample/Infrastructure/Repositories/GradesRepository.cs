using Application.Logic.Grades;
using Domain.CommonTypes.Enums;
using Domain.CommonTypes.Exceptions;
using Domain.CommonTypes.Records;
using Domain.Grades;
using Infrastructure.Contexts;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

internal class GradesRepository : IGradesRepository
{
    private readonly GradesDbContext _gradesContext;
    private readonly string GradeDescription = EnumDescription.GetEnumDescription(EntitiesTypes.Grade);

    public GradesRepository(GradesDbContext gradesContext)
    {
        _gradesContext = gradesContext;
    }

    public async Task<IEnumerable<Grade>> GetGradesByProductIdAsync(AdvancedProductData productData,
        CancellationToken cancellationToken)
    {
        var gradesByProductId = _gradesContext.Grades
            .AsNoTracking().Where(grade => grade.ProductId == productData.ProductId);

        var countGrades = await gradesByProductId.CountAsync(cancellationToken);

        if (countGrades == 0) NotFoundException.Throw(GradeDescription);

        gradesByProductId = productData.SortingDirection switch
        {
            SortingDirections.Ascending => gradesByProductId.OrderBy(s => s.Rating),
            SortingDirections.Descending => gradesByProductId.OrderByDescending(s => s.Rating),
            _ => gradesByProductId
        };

        return await gradesByProductId.ToListAsync(cancellationToken);
    }

    public async Task<double> GetAverageGradeByProductIdAsync(AdvancedProductData productData,
        CancellationToken cancellationToken)
    {
        var grades = _gradesContext.Grades
            .AsNoTracking().Where(grade => grade.ProductId == productData.ProductId)
            .Skip((productData.PageNumber - 1) * productData.PageSize).Take(productData.PageSize);

        var countGrades = await grades.CountAsync(cancellationToken);

        if (countGrades == 0) NotFoundException.Throw(GradeDescription);

        return await grades.AverageAsync(s => s.Rating, cancellationToken);
    }


    public async Task<IEnumerable<Grade>> GetGradesByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var gradesByUserId = _gradesContext.Grades.AsNoTracking().Where(grade => grade.UserId == userId);

        var countGrades = await gradesByUserId.CountAsync(cancellationToken);

        if (countGrades == 0) NotFoundException.Throw(GradeDescription);

        return await gradesByUserId.ToListAsync(cancellationToken);
    }

    public async Task<Grade> CreateGradeAsync(Grade grade, CancellationToken cancellationToken)
    {
        await _gradesContext.AddAsync(grade, cancellationToken);
        await _gradesContext.SaveChangesAsync(cancellationToken);

        var insertedGrade = await _gradesContext.Grades.FirstOrDefaultAsync(g => g.Id == grade.Id, cancellationToken);
        if (insertedGrade == null) NotFoundException.Throw(GradeDescription);

        return insertedGrade;
    }

    public async Task<Grade> UpdateGradeAsync(Grade grade, CancellationToken cancellationToken)
    {
        var gradeForUpdate = await _gradesContext.Grades.FirstOrDefaultAsync(g => g.Id == grade.Id, cancellationToken);
        if (gradeForUpdate == null) NotFoundException.Throw(GradeDescription);
        if (gradeForUpdate.UserId != grade.UserId) OperationNotAvailableException.Throw(GradeDescription);

        gradeForUpdate.Rating = grade.Rating;
        gradeForUpdate.Review = grade.Review;

        _gradesContext.Update(gradeForUpdate);
        await _gradesContext.SaveChangesAsync(cancellationToken);

        var updatedGrade = await _gradesContext.Grades.FirstOrDefaultAsync(g => g.Id == grade.Id, cancellationToken);
        if (updatedGrade == null) NotFoundException.Throw(GradeDescription);

        return updatedGrade;
    }

    public async Task<bool> DeleteGradeAsync(Guid gradeId, CancellationToken cancellationToken)
    {
        var gradeForDelete = await _gradesContext.Grades.FirstOrDefaultAsync(g => g.Id == gradeId, cancellationToken);
        if (gradeForDelete == null) NotFoundException.Throw(GradeDescription);

        _gradesContext.Remove(gradeForDelete);

        await _gradesContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}