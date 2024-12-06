using ShoppingBlazor.Entities.Products;
using ShoppingBlazor.Services.Common;

namespace ShoppingBlazor.Services.Products.Paginations;

public class StuffPagination : Paginator<Stuff>
{
    public string? Name { get; set; }

    public string? CategoryName { get; set; }

    public string? SupplierName { get; set; }
    
    protected override IQueryable<Stuff> ApplyConditions(IQueryable<Stuff> entities)
    {
        if (!string.IsNullOrWhiteSpace(Name))
        {
            entities = entities.Where(x => x.Name.Contains(Name!));
        }
        if (!string.IsNullOrWhiteSpace(CategoryName))
        {
            entities = entities.Where(x => x.Category.Name.Contains(CategoryName!));
        }
        if (!string.IsNullOrWhiteSpace(SupplierName))
        {
            entities = entities.Where(x => x.SupplierName != null && x.SupplierName.Contains(SupplierName!));
        }

        return entities;
    }
}