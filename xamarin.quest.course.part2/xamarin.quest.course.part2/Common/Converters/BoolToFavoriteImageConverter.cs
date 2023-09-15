using System;
using System.Globalization;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Common.Converters
{
    public class BoolToFavoriteImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return "fullHeart.png";
            }

            return "emptyHeart.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
