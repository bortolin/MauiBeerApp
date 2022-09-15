using System.Globalization;
using System.Linq;

namespace MauiBeerApp.Converters
{
    public class ListOfStringConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Join(", ", (IEnumerable<string>)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string)value).Split(",").Select((s) => { return s.Trim(); });
        }
    }
}