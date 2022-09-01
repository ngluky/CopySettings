using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CopySettings.Hellp
{
    public class biningConver : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? data = value as string;
            if (data == null) return null;
            return data.Split("::")[1];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? data = value as string;
            return "EAresFloatSettingName::" + data;
        }
    }
}
