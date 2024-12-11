namespace Domain.Users;

/// <summary>
/// Сущность пользователя
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// Наименование пользователя
    /// </summary>
    public string Name { get; set; }
}