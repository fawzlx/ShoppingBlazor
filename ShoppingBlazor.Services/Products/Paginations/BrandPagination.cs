using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Services.Common;

namespace ShoppingBlazor.Services.Products.Paginations;

public class BrandPagination : Paginator<Brand>
{
    protected override IQueryable<Brand> ApplyConditions(IQueryable<Brand> models)
    {
        return models;
    }
}