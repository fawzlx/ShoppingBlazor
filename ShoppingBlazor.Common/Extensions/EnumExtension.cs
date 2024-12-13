using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ShoppingBlazor.Infrastructure.Extensions;

public static class EnumExtension
{
    public static string Display(this Enum eEnum)
    {
        var enumMemberInfo = eEnum.GetType()
            .GetMember(eEnum.ToString())
            .FirstOrDefault();

        var display = enumMemberInfo?
            .GetCustomAttribute<DisplayAttribute>();

        return display?.Name ?? eEnum.ToString();
    }
}