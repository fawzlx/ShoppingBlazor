using System.ComponentModel.DataAnnotations;
using ShoppingBlazor.Services.Common;

namespace ShoppingBlazor.Services.Products.Dtos;

public class AddStuffRequest : BaseRequest
{
    [MaxLength(30)]
    public required string Name { get; set; }
    public required short CategoryId { get; set; }
    public required short BrandId { get; set; }
    [MaxLength(30)]
    public string? SupplierName { get; set; }
    [EmailAddress]
    public string? SupplierEmail { get; set; }
    public required uint Stock { get; set; }
    [Range(5000, 1_000_000_000)]
    public required uint Price { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EnDateTime { get; set; }
    [MaxLength(50)]
    public required string Image { get; set; }

    [MaxLength(50)]
    public string? Catalog { get; set; }
}