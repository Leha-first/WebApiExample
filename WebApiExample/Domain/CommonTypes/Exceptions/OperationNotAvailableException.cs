namespace Domain.CommonTypes.Exceptions;

/// <summary>
/// Реализация кастомного типа исключения OperationNotAvailableException
/// </summary>
/// <param name="message"> Сообщение </param>
public class OperationNotAvailableException(string message) : Exception(message)
{
    /// <summary>
    /// Создание и вызов исключения
    /// </summary>
    /// <param name="entityType"> Сущность </param>
    /// <param name="additionalMessage"> Дополнительное сообщение </param>
    /// <exception cref="OperationNotAvailableException"> Исключение </exception>
    public static void Throw(string entityType, string additionalMessage = "")
    {
        var message = $"Операция над сущностью \"{entityType}\" недоступна для пользователя." +
                      $"\n\r Проверьте корректность выполняемых операций." +
                      $"\n\rПри необходимости сообщите о проблеме в службу поддержки.";

        if (string.IsNullOrEmpty(additionalMessage))
            message += $"\n\r\n\rДополнительная информация: {additionalMessage}";

        throw new OperationNotAvailableException(message);
    }
}

