using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Services.Common;
using ShoppingBlazor.Services.Products.Dtos;

namespace ShoppingBlazor.Services.Products.Paginations;

public class StuffPagination : Paginator<Stuff>
{
    public string? Name { get; set; }

    public IEnumerable<CategoryDto>? Categories { get; set; }

    public string? SupplierName { get; set; }

    public string? BrandName { get; set; }

    protected override IQueryable<Stuff> ApplyConditions(IQueryable<Stuff> entities)
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            entities = entities.Where(x => x.Name.Contains(Name!));
        }
        if (Categories is not null && Categories.Any())
        {
            entities = entities.IntersectBy(Categories.Select(x => x.Id), stuff => stuff.CategoryId);
        }
        if (!string.IsNullOrWhiteSpace(SupplierName))
        {
            entities = entities.Where(x => x.SupplierName != null && x.SupplierName.Contains(SupplierName!));
        }
        if (!string.IsNullOrWhiteSpace(BrandName))
        {
            entities = entities.Where(x => x.Brand.Name.Contains(SupplierName!));
        }

        return entities;
    }
}