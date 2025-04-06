using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CelebrityQuiz.Converters
{
    public class AnswerToButtonStyleConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || !(values[0] is int) || !(values[1] is int))
                return DependencyProperty.UnsetValue;

            int actorId = (int)values[0];
            int correctAnswerId = (int)values[1];

            if (correctAnswerId == 0) // Quiz nije završen
                return Application.Current.FindResource("MaterialDesignRaisedButton");

            if (actorId == correctAnswerId)
                return Application.Current.FindResource("MaterialDesignRaisedAccentButton");

            return Application.Current.FindResource("MaterialDesignRaisedLightButton");
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

