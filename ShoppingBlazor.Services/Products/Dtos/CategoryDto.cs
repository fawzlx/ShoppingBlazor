using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Dtos;

public record CategoryDto(short Id, string Name)
{
    public CategoryDto(Category category) : this(category.Id, category.Name)
    {
    }
}