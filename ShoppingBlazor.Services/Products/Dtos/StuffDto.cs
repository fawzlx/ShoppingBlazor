using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Dtos;

public record StuffDto(
    int Id,
    string Name,
    short CategoryId,
    string CategoryName,
    short BrandId,
    string BrandName,
    string? SupplierName,
    uint Stock,
    uint Price,
    DateTime? StartDate,
    DateTime? EndDateTime,
    string Image,
    string? Catalog
)
{
    public StuffDto(Stuff stuff) : this(stuff.Id, stuff.Name, stuff.CategoryId, stuff.Category.Name, stuff.BrandId,
        stuff.Brand.Name, stuff.SupplierName, stuff.Stock, stuff.Price, stuff.StartDate, stuff.EnDateTime, stuff.Image,
        stuff.Catalog)
    {
    }
}