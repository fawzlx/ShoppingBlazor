using MudBlazor;
using ShoppingBlazor.Services.Common;

namespace ShoppingBlazor.Extensions;

public static class TableStateExtension
{
    public static void Set(this BasePagination pagination, TableState state)
    {
        pagination.Index = state.Page;
        pagination.Take = state.PageSize;
        pagination.Order = state.SortDirection.ToString();
        pagination.Sort = state.SortLabel;
    }
}