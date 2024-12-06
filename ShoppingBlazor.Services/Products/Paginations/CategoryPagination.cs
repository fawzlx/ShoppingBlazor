using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Services.Common;

namespace ShoppingBlazor.Services.Products.Paginations;

public class CategoryPagination : Paginator<Category>
{
    protected override IQueryable<Category> ApplyConditions(IQueryable<Category> models)
    {
        return models;
    }
}