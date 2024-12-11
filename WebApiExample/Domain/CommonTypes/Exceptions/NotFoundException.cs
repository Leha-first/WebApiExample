namespace Domain.CommonTypes.Exceptions;

/// <summary>
/// Реализация кастомного типа исключения NotFoundException
/// </summary>
/// <param name="message"> Сообщение </param>
public class NotFoundException(string message) : Exception(message)
{
    /// <summary>
    /// Создание и вызов исключения
    /// </summary>
    /// <param name="entityType"> Сущность </param>
    /// <param name="additionalMessage"> Дополнительное сообщение </param>
    /// <exception cref="NotFoundException"> Исключение </exception>
    public static void Throw(string entityType, string additionalMessage = "")
    {
        var message = $"Не обнаружено сущности(-ей) \"{entityType}\" с указанными идентификаторами." +
                      $"\n\r Проверьте корректность выполняемых операций." +
                      $"\n\rПри необходимости сообщите о проблеме в службу поддержки.";

        if (string.IsNullOrEmpty(additionalMessage))
            message += $"\n\r\n\rДополнительная информация: {additionalMessage}";

        throw new NotFoundException(message);
    }
}