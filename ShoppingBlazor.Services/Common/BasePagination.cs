namespace ShoppingBlazor.Services.Common;

public abstract class BasePagination
{
    public int Index { get; set; } = 0;
    public int Take { get; set; } = 10;
    public string Order { get; set; } = "Ascending";
    public string? Sort { get; set; }
}