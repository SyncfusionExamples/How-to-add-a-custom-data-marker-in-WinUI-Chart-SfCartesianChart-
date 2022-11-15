using Microsoft.UI;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDataLabel
{
    public class BorderColorConverter : IValueConverter
    {
        static double YValue = 0;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value != null)
            {
                var yData =  System.Convert.ToDouble(value);
                if (yData >= YValue)
                {
                    //if y value increased
                    YValue = yData;
                    return new SolidColorBrush(Colors.Green);
                }
                else
                {
                    //if y value decreased
                    YValue = yData;
                    return new SolidColorBrush(Colors.Red);
                }
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
