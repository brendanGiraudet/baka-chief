using bakaChiefApplication.Constants;
using Microsoft.AspNetCore.Components;
using System.Reflection;

namespace bakaChiefApplication.Components.Icon
{
    public partial class Icon
    {
        // ICON SVG
        [Parameter] public Enums.Icon IconSvgEnum { get; set; }
        private string _iconSvg => Utilities.GetPropertyValue<string>(typeof(SvgConstants), IconSvgEnum.ToString());
        
        // ICON SIZE
        [Parameter] public Enums.Size IconSize { get; set; } = Enums.Size.Normal;
        private string _iconSizeClass => IconSize.ToString().ToLower();

        // ICON STYLE
        [Parameter] public Enums.Style IconStyle { get; set; } = Enums.Style.Secondary;
        private string _iconStyleClass => IconStyle.ToString().ToLower();
    }

    public static class Utilities
    {
        public static T GetPropertyValue<T>(this Type t, string name)
        {
            if (t == null)
                return default(T);

            BindingFlags flags = BindingFlags.Static | BindingFlags.Public;

            PropertyInfo info = t.GetProperty(name, flags);

            if (info == null)
            {
                // See if we have a field;
                FieldInfo finfo = t.GetField(name, flags);
                if (finfo == null)
                    return default(T);

                return (T)finfo.GetValue(null);
            }

            return (T)info.GetValue(null, null);
        }
    }
}