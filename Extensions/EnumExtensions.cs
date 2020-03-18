using System.ComponentModel;
using System.Reflection;

namespace FullStack_Project_IE_2.Extensions
{
    public static class EnumExtensions
    {
        public static string ToDescriptionEnum<TEnum>(this TEnum @enum )
        {
            FieldInfo info = @enum.GetType().GetField(@enum.ToString());
            var atributes = (DescriptionAttribute[])info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return atributes?[0].Description ?? @enum.ToString();
        }
    }
}
