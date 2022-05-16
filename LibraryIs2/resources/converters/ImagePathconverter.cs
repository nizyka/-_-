using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LibraryIs2.resources.converters
{
    class ImagePathconverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string path = value as string;
                if (File.Exists(path))
                {
                    return path = Path.GetFullPath(path);
                }
                else return "resources/images/1.jpg";
            }
            catch(Exception)
            {
                return "resources/images/1.jpg";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
