using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CelebrityQuiz.Converters
{
    public class AnswerColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return Colors.Transparent;

            try
            {
                int answerId = (int)value;
                int correctId = (int)parameter;

                // Ako je ovo tačan odgovor, prikaži zelenu boju
                if (answerId == correctId)
                {
                    return Colors.Green;
                }

                // Ako nije tačan odgovor, vrati transparentnu boju (originalna boja dugmeta)
                return Colors.Transparent;
            }
            catch
            {
                return Colors.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

