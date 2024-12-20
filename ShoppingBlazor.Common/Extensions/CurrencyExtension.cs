using System.Globalization;

namespace ShoppingBlazor.Infrastructure.Extensions;

public static class CurrencyExtension
{
    public static string ToRial(this uint price)
    {
        return price.ToString("C", new CultureInfo("fa-ir"));
    }

    public static string ToRial(this int price)
    {
        return price.ToString("C", new CultureInfo("fa-ir"));
    }
}