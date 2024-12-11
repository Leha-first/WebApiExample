using Domain.CommonTypes.Enums;

namespace Domain.CommonTypes.Records;

/// <summary>
/// Данные по продукту для обеспечения запросов
/// </summary>
/// <param name="ProductId"> Идентификатор продукта </param>
/// <param name="PageNumber"> Настройка пагинации - номер страницы </param>
/// <param name="PageSize"> Настройка пагинации - размер страницы </param>
/// <param name="SortingDirection"> Настройки сортировки </param>
public record AdvancedProductData(Guid ProductId, int PageNumber, int PageSize, SortingDirections SortingDirection);