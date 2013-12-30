using System;
using System.Windows.Data; // for IValueConverter

namespace shopping_compare
{
	public class NumberFormatter : IValueConverter
	{
		/// <summary>
		/// Converts a double from calculations into a string, either for price per unit output or for output to display in the textboxes.
		/// </summary>
		/// <param name="value">(double)</param>
		/// <param name="targetType"></param>
		/// <param name="parameter">if equal to "PricePerUnitOutput", value will be formatted to be output for reading price per unit; otherwise, it will be formatted numerically (just adding a zero if needed)</param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double val = (double)value;
			string parameterString = parameter as string;

			// Price Per Unit output:
			if (parameterString == "PricePerUnitOutput")
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
					return MoneyFormatter.FormattedDollarCentString(val);
				}
			}
			// Output back to the textboxes:
			else
			{
				if (val == 0)
				{
					return "";
				}
				return MoneyFormatter.ToStringAddZeroIfNeeded(val);
			}
		}

		/// <summary>
		/// Converts a string entered into a TextBox into a double to be used in calculations.
		/// </summary>
		/// <param name="value"></param>
		/// <param name="targetType"></param>
		/// <param name="parameter"></param>
		/// <param name="culture"></param>
		/// <returns></returns>
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			string val = (string)value;
			if (val == "") return 0;
			double temp;
			try
			{
				temp = System.Convert.ToDouble(val);
			}
			catch // if that conversion did not work (if the user copy-pastes a string with nondigits or the user enters more than one decimal point)
			{
				return 0;
			}
			// If the user copy-pasted a negative value in
			if (temp < 0) return 0;
			return temp;
		}
	}
}
