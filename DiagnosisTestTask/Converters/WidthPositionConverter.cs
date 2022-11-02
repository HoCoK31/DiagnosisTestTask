using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace DiagnosisTestTask.Converters
{
    public class WidthPositionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(values[2]) / 20 * (System.Convert.ToDouble(values[0]) - System.Convert.ToDouble(values[1]) / 2);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
