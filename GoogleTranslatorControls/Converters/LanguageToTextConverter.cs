using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.ComponentModel;
using Google.API.Translate;

namespace GoogleTranslatorControls.Converters
{
    [ValueConversion(typeof(Language), typeof(String))]
    class LanguageToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return GoogleTranslatorWebService.Translator.FromName(value.ToString());
        }
    }
}
