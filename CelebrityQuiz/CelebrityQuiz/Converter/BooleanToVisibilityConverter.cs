﻿using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CelebrityQuiz.Converters
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return Visibility.Collapsed;

            bool visibility = (bool)value;

            if (parameter != null && parameter.ToString().ToLower() == "inverse")
                visibility = !visibility;

            return visibility ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}