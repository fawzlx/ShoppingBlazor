using System.Globalization;

namespace ShoppingBlazor.Infrastructure.Extensions;

public static class DateTimeExtension
{
    public static string ToPersianDateTime(this DateTime dateTime)
    {
        return dateTime.ToString("yyyy/MM/dd", new CultureInfo("fa-ir"));
    }

    public static string ToPersianDateTime(this DateTime? dateTime)
    {
        return dateTime is null
            ? string.Empty : 
            dateTime.Value.ToString("yyyy/MM/dd", new CultureInfo("fa-ir"));
    }
}