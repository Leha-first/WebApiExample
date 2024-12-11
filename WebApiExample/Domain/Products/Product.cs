namespace Domain.Products;

/// <summary>
/// Сущность продукта
/// </summary>
public class Product
{
    /// <summary>
    /// Идентификатор продукта
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование продукта
    /// </summary>
    public string Name { get; set; }
}