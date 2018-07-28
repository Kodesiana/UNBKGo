using System;
using System.Globalization;
using System.Windows.Data;

namespace UNBKGo.Admin.Domain.Converters
{
    public class StatusToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ClientStatus)) return Binding.DoNothing;
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
