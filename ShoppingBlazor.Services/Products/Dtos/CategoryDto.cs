using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Dtos;

public record CategoryDto(short Id, string Name, CategoryGroup Group)
{
    public CategoryDto(Category category) : this(category.Id, category.Name, category.Group)
    {
    }
}