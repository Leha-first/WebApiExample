using System.ComponentModel;

namespace Domain.CommonTypes.Enums;

public enum EntitiesTypes
{
    [Description("Оценка")]
    Grade,
    [Description("Продукт")]
    Product,
    [Description("Пользователь")]
    User,
}