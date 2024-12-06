using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Dtos;

public record BrandDto(short Id, string Name)
{
    public BrandDto(Brand brand) : this(brand.Id, brand.Name)
    {
    }
}