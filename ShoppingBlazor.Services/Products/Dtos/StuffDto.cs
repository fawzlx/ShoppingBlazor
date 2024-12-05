using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Dtos;

public record StuffDto(
    int Id,
    string Name,
    string CategoryName,
    string BrandName,
    string? SupplierName,
    uint Stock,
    uint Price)
{
    public StuffDto(Stuff stuff) : this(stuff.Id, stuff.Name, stuff.Category.Name, stuff.Brand.Name, stuff.SupplierName, stuff.Stock, stuff.Price)
    {
    }
}