using System;
using System.Globalization;
using Xamarin.Forms;

namespace xamarin.course
{
    public class BoolToColorConverter : IValueConverter
    {
        //Converts value from View Model to the View.
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Color.FromHex("#20A4B4");
            }
            return Color.FromHex("#3988F1");
        }

        //Converts value from the View to the View Model.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
