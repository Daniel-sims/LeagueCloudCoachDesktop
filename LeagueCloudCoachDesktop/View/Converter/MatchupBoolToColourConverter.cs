using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace LeagueCloudCoachDesktop.View.Converter
{
    public class MatchupBoolToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                {
                    return (SolidColorBrush)(new BrushConverter().ConvertFrom("#4caf50"));
                }
            }

            return (SolidColorBrush)(new BrushConverter().ConvertFrom("#f44336"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
