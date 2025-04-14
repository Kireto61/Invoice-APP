using InvoiceApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InvoiceApp.View.Converters
{
    public class EnumToString : IValueConverter
    {
        // Convert an enum value to a string using the Description attribute if available.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            Type enumType = value.GetType();
            if (!enumType.IsEnum)
                return value.ToString();

            // Get the field info for the enum value.
            FieldInfo field = enumType.GetField(value.ToString());
            if (field != null)
            {
                // Look for a Description attribute on the field.
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    return attribute.Description;
                }
            }
            // Fallback to the enum's name.
            return value.ToString();
        }

        // Optionally implement ConvertBack if you need two‑way binding.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string enumString && targetType.IsEnum)
            {
                foreach (var enumValue in Enum.GetValues(targetType))
                {
                    FieldInfo field = targetType.GetField(enumValue.ToString());
                    DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                    string description = attribute != null ? attribute.Description : enumValue.ToString();
                    if (string.Equals(enumString, description, StringComparison.OrdinalIgnoreCase))
                    {
                        return enumValue;
                    }
                }
            }
            return Binding.DoNothing;
        }
    }
}
