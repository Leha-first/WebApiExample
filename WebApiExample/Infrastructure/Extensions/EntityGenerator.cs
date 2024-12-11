using Bogus;
using Domain.Products;
using Domain.Users;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class EntityGenerator
{
    /// <summary>
    /// Генерация сущностей
    /// </summary>
    /// <param name="context"> Контекст GradesDbContext </param>
    public static async Task<int> AddDataAsync(this GradesDbContext context)
    {
        if (await context.Products.AnyAsync() && await context.Users.AnyAsync()) return 0;

        // Генерация продуктов
        var products = new Faker<Product>()
            .RuleFor(a => a.Id, _ => Guid.NewGuid())
            .RuleFor(a => a.Name, f => f.Commerce.ProductName())
            .Generate(150);

        context.AddRange(products);

        // Генерация пользователей
        var users = new Faker<User>()
            .RuleFor(user => user.Id, _ => Guid.NewGuid())
            .RuleFor(user => user.Name, f => f.Person.FirstName)
            .Generate(15);

        context.AddRange(users);

        return await context.SaveChangesAsync();
    }
}