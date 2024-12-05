using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Databases.DbContexts;

public interface IShoppingBlazorDbContext
{
    public IEnumerable<Stuff> Stuffs { get; set; }
    public IEnumerable<Category> Categories { get; set; }
    public IEnumerable<Brand> Brands { get; set; }
}