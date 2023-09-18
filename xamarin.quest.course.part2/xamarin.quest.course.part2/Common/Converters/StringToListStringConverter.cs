using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xamarin.Forms;

namespace xamarin.quest.course.part2.Common.Converters
{
    public class StringToListStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var content = new List<string>();
            if (value is string)
            {
                var separators = new[] { ',' };
                content.AddRange((value as string).Split(separators)
                    .Where(s => !string.IsNullOrWhiteSpace(s))
                    .Select(s => s.Trim()));
            }
            else
            {
                content.Add(value.ToString());
            }
            return content;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
