using System;
using System.Globalization;
using System.Windows.Data;
using InvoiceApp.Model;

namespace InvoiceApp.View.Converters
{
    public class CurrencyToEnabledConverter : IValueConverter
    {
        // Returns true if a valid currency is selected.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return true;

            if (value is string s && string.IsNullOrWhiteSpace(s))
                return true;

            // You could also handle enum types if needed.
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
