using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace XamDataGrid.Zoomable
{
    class PercentageToTextConverter : IValueConverter
    {
        public Object Convert(Object value, System.Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {
            var percentage = (double)value;
            var additionalText = parameter as String;

            if (additionalText == null)
                additionalText = String.Empty;

            if (additionalText != null)
                return (percentage * 100).ToString() + " " + additionalText;
            else
                return (percentage * 100).ToString();
        }

        public Object ConvertBack(Object value, System.Type targetType, Object parameter, System.Globalization.CultureInfo culture)
        {
            var text = value as String;
            text = text.Replace("%", "");
            text = text.Replace(" ", "");

            return Double.Parse(text) / 100;
        }
    }
}
