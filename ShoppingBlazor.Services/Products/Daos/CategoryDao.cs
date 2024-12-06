using ShoppingBlazor.Databases.DbContexts;
using ShoppingBlazor.Databases.Repositories;
using ShoppingBlazor.Entities.Products;

namespace ShoppingBlazor.Services.Products.Daos;

public class CategoryDao(IShoppingBlazorDbContext dbContext) : Repository<Category>(dbContext)
{
    public override Category Create(Category entity)
    {
        var nextId = DbContext.Categories.MaxBy(x => x.Id)?.Id + 1 ?? 1;

        entity.Id = (short)nextId;

        DbContext.Categories = DbContext.Categories.Append(entity);

        return entity;
    }

    public override IQueryable<Category> Read()
    {
        return DbContext.Categories.AsQueryable();
    }

    public override Category? ReadById(long id)
    {
        return DbContext.Categories.SingleOrDefault(x => x.Id == (int)id);
    }

    public override Category Update(Category entity)
    {
        var oldCategory = DbContext.Categories.Single(x => x.Id == entity.Id);

        var categories = DbContext.Categories.ToList();

        var index = categories.IndexOf(entity);

        categories[index] = entity;

        DbContext.Categories = categories;

        return oldCategory;
    }

    public override Category Delete(Category entity)
    {
        var remainingCategories = DbContext.Categories.Where(x => x.Id != entity.Id);

        DbContext.Categories = remainingCategories;

        return entity;
    }

    public override Category? DeleteById(long id)
    {
        var category = DbContext.Categories.SingleOrDefault(x => x.Id == id);

        return category is null ? null : Delete(category);
    }
}