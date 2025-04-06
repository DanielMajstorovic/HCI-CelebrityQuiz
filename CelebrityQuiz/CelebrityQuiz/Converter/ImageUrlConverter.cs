using System;
using System.Globalization;
using System.Windows.Data;

namespace CelebrityQuiz
{
    public class ImageUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string imagePath && !string.IsNullOrEmpty(imagePath))
            {
                //return $"https://image.tmdb.org/t/p/w500{imagePath}";  //Skidanje sa neta
                //return $"C:/Users/Dell/Documents/GitHub/CelebrityQuiz/CelebrityQuiz/CelebrityQuiz/bin/Debug/net6.0-windows/Images/{imagePath}";
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Images", imagePath.TrimStart('/'));
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
