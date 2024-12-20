using System.Globalization;
using System.Reflection;

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

    public static CultureInfo GetPersianCulture()
    {
        var culture = new CultureInfo("fa-IR");

        var formatInfo = culture.DateTimeFormat;

        SetFormInfo(formatInfo);

        var persianCalendar = new PersianCalendar();

        var fieldInfo = culture.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
        if (fieldInfo != null)
            fieldInfo.SetValue(culture, persianCalendar);
        var info = formatInfo.GetType().GetField("calendar", BindingFlags.NonPublic | BindingFlags.Instance);
        if (info != null)
            info.SetValue(formatInfo, persianCalendar);

        SetCultureInfoFormat(culture);

        return culture;
    }

    private static void SetCultureInfoFormat(CultureInfo culture)
    {
        culture.NumberFormat.NumberDecimalSeparator = "/";
        culture.NumberFormat.DigitSubstitution = DigitShapes.NativeNational;
        culture.NumberFormat.NumberNegativePattern = 0;
    }

    private static void SetFormInfo(DateTimeFormatInfo formatInfo)
    {
        formatInfo.AbbreviatedDayNames = ["ی", "د", "س", "چ", "پ", "ج", "ش"];
        formatInfo.DayNames = ["یکشنبه", "دوشنبه", "سه شنبه", "چهار شنبه", "پنجشنبه", "جمعه", "شنبه"];
        var monthNames = new[]
        {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن",
            "اسفند",
            "",
        };
        formatInfo.AbbreviatedMonthNames =
            formatInfo.MonthNames =
                formatInfo.MonthGenitiveNames = formatInfo.AbbreviatedMonthGenitiveNames = monthNames;
        formatInfo.AMDesignator = "ق.ظ";
        formatInfo.PMDesignator = "ب.ظ";
        formatInfo.ShortDatePattern = "yyyy/MM/dd";
        formatInfo.LongDatePattern = "dddd, dd MMMM,yyyy";
        formatInfo.FirstDayOfWeek = DayOfWeek.Saturday;
    }
}