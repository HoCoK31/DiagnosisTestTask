using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace DiagnosisTestTask.Converters
{
    public class BoolToRussianConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            return value is true ? "Да" : "Нет";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            return value is "Да";
        }
    }
}
