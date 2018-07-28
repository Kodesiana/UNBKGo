using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace UNBKGo.Admin.Domain.Converters
{
    public class StatusToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is ClientStatus)) return Binding.DoNothing;
            switch ((ClientStatus)value)
            {
                case ClientStatus.Ready:
                    return Brushes.GreenYellow;

                case ClientStatus.Update:
                    return Brushes.Orange;

                case ClientStatus.Disconnected:
                    return Brushes.Red;

                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
