using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data; // for IValueConverter

namespace shopping_compare
{
	public class NumberFormatter : IValueConverter
	{
		// To convert from double-type data to string UI for the text boxes and the price per unit output:
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			Money val = (Money)value;
			string theParameter = parameter as string;

			// For the Price Per Unit output:
			if (theParameter == "PricePerUnitOutput")
			{
				if (val == 0 || val == -1)
				{
					return "";
				}
				else if (val < 0)
				{
					throw new ArgumentOutOfRangeException();
				}
				else
				{
					return MoneyFormatter.FormattedString(val);
				}
			}
			// For output back to the textboxes:
			else
			{
				if (val == 0)
				{
					return "";
				}
				return val.ToString();
			}
		}

		// Called when the user enters a string value into a textbox:
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string val = (string)value;
			if (val == "") return 0;
			double temp;
			try
			{
				temp = System.Convert.ToDouble(val);
			}
			// If that conversion did not work (usually if the user copy-pastes a string with nondigits or with more than one decimal point):
			catch
			{
				return 0;
			}
			// If the user copy-pasted a negative value in
			if (temp < 0) return 0;
			return temp;
		}
	}
}
