using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ZegarekWpf
{
	class RadianDegreesConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is double))
				return value;
			double source = (double)value;
			return source * 180.0 / Math.PI;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is double))
				return value;
			double source = (double)value;
			return source * Math.PI / 180.0;
		}
	}
}
