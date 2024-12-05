using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Infrastructure.DI;

namespace ShoppingBlazor.Databases.DbContexts;

public class ShoppingBlazorDbContext : IShoppingBlazorDbContext, ISingletonService
{
    public IEnumerable<Stuff> Stuffs { get; set; } = [];
    public IEnumerable<Category> Categories { get; set; } = [];
    public IEnumerable<Brand> Brands { get; set; } = [];
}