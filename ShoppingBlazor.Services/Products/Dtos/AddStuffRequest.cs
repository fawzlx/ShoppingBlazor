using ShoppingBlazor.Services.Common;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using DNTPersianUtils.Core;

namespace ShoppingBlazor.Services.Products.Dtos;

public class AddStuffRequest : BaseRequest
{
    [Required(ErrorMessage = "نام کالا اجباری می باشد")]
    [MaxLength(30, ErrorMessage = "نام کالا حداکثر 30 حرف می باشد")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "دسته بندی اجباری می باشد")]
    public CategoryDto? Category { get; set; }
    public short CategoryId => Category?.Id ?? 0;

    [Required(ErrorMessage = "برند اجباری می باشد")]
    public BrandDto? Brand { get; set; }
    public short BrandId => Brand?.Id ?? 0;

    [MaxLength(30, ErrorMessage = "نام تأمین کننده حداکثر 30 حرف می باشد")]
    public string? SupplierName { get; set; }
    [EmailAddress(ErrorMessage = "ایمیل تأمین کننده معتبر نمی باشد")]
    public string? SupplierEmail { get; set; }
    [Range(1, 1_000_000, ErrorMessage = "مقادیر معتبر برای موجودی بین 1 تا یک میلیون تعداد می باشد")]
    public required int Stock { get; set; }
    [Range(5000, 1_000_000_000, ErrorMessage = "مقادیر معتبر برای قیمت بین 5000 ریال تا یک میلیارد ریال می باشد")]
    public required int Price { get; set; }

    [ValidPersianDateTime(ErrorMessage = "تاریخ شروع معتبر نمی باشد")]
    public DateTime? StartDate { get; set; }
    [ValidPersianDateTime(ErrorMessage = "تاریخ پایان معتبر نمی باشد")]
    public DateTime? EnDateTime { get; set; }

    [MaxLength(50)]
    public required string Image { get; set; }

    [MaxLength(50)]
    public string? Catalog { get; set; }

    public required IEnumerable<Color> ColorOptions { get; set; }
}