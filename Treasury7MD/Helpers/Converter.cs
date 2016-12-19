using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace Treasury7MD.Helpers
{
    public class Converter : IValueConverter
    {
        private int[] calculatingKEKVs = { 1, 2000, 2100, 2200};
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return Array.Exists(calculatingKEKVs, x=>x == (int)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // throw new NotImplementedException();
            return null;
        }
    }
}
