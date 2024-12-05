using System.ComponentModel.DataAnnotations;

namespace ShoppingBlazor.Entities.Products;

[Flags]
public enum CategoryGroup : byte
{
    [Display(Name = "دسته بندی اول")]
    Group1 = 1,

    [Display(Name = "دسته بندی دوم")]
    Group2 = 2,

    [Display(Name = "دسته بندی سوم")]
    Group3 = 3
}