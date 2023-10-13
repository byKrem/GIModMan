using GIModMan.Enums;
using System;
using System.Globalization;
using System.Windows.Data;

namespace GIModMan.Converters
{
    internal class ModVisibilityToImageBlurConverter : IValueConverter
    {
        private const int NO_BLUR = 0;
        private const int BLUR = 20;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value is ModVisibility modVisibility)
            {
                if(modVisibility != ModVisibility.show)
                    return BLUR;
            }
            return NO_BLUR;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
