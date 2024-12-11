using System.ComponentModel;
using System.Reflection;

namespace Infrastructure.Extensions;

public class EnumDescription
{
    /// <summary>
    /// Метод получения описания из элемента Enum
    /// </summary>
    /// <param name="value"> Значение Enum </param>
    /// <returns> Описание </returns>
    public static string GetEnumDescription(Enum value)
    {
        FieldInfo? fi = value.GetType().GetField(value.ToString());

        if (fi?.GetCustomAttributes(typeof(DescriptionAttribute), false) is DescriptionAttribute[] attributes && attributes.Any())
        {
            return attributes.First().Description;
        }

        return value.ToString();
    }
}