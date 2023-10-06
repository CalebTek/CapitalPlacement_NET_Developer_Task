using System.ComponentModel;
using System.Reflection;

namespace CapitalPlacement.Domain.Enums.Helper
{
    public class EnumHelper
    {
        public static string GetEnumDescription<TEnum>(TEnum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            if (fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
            {
                return attribute.Description;
            }

            return value.ToString();
        }
    }
}
