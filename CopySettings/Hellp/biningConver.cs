using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace CopySettings.Hellp
{
    public class biningConver : IValueConverter
    {
        // not do anything

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


    public class AgentsName : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? developerName = value as string;
            if (developerName == null || developerName == "") return "";
            return Constants.NameAgents[developerName];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? displayName = value as string;
            if (displayName == null) return "";
            string developerName = Constants.NameAgents.FirstOrDefault(x => x.Value == displayName).Key;
            return displayName;
        }
    }

    public class DefaultValue : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return parameter;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }



    public class RoundConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? data = value as string;
            if (data == "") return null;
            return System.Convert.ToDouble(data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double? data = value as double?;
            return Math.Round((double)data, 2);
        }
    }

    public class WidthHalf : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FrameworkElement? data = value as FrameworkElement;
            return data.Width / 2.0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            float? data = value as float?;
            return data * 2.0;
        }
    }

    public class SwichConten : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string? data = value as string;
            string[] string_splti = data.Split('|');
            return string_splti;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string[] data = value as string[];
            return string.Join("|", data);
        }
    }
}
