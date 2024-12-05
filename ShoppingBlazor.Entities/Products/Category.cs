using System.ComponentModel.DataAnnotations;
using ShoppingBlazor.Entities.Base;

namespace ShoppingBlazor.Entities.Products;

public class Category : BaseEntity<short>
{
    [MaxLength(30)]
    public required string Name { get; set; }

    [EnumDataType(typeof(CategoryGroup))]
    public required CategoryGroup Group { get; set; }

    public IEnumerable<Stuff>? Stuffs { get; set; }
}