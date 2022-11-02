using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace DiagnosisTestTask.Converters
{
    public class HeightPercentageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return System.Convert.ToDouble(value) * 12 / 20;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return System.Convert.ToDouble(value) * 20/ 12;
        }
    }
}
