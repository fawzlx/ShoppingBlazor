using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Infrastructure.DI;

namespace ShoppingBlazor.Databases.DbContexts;

public class ShoppingBlazorDbContext : IShoppingBlazorDbContext, ISingletonService
{
    public IEnumerable<Stuff> Stuffs { get; set; } = [];
    public IEnumerable<Category> Categories { get; set; } = 
    [
        new()
        {
            Id = 1,
            Name = "دسته بندی اول",
            Group = CategoryGroup.Group1
        },
        new()
        {
            Id = 2,
            Name = "دسته بندی دوم",
            Group = CategoryGroup.Group2
        },
        new()
        {
            Id = 3,
            Name = "دسته بندی سوم",
            Group = CategoryGroup.Group3
        }
    ];
    public IEnumerable<Brand> Brands { get; set; } = [
        new()
        {
            Id = 1,
            Name = "برند اول"
        },
        new()
        {
            Id = 2,
            Name = "برند دوم"
        },
        new()
        {
            Id = 3,
            Name = "برند سوم"
        }
    ];
}