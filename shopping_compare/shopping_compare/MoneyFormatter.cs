using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopping_compare
{
	static class MoneyFormatter
	{
		/// <summary>
		/// Returns a formatted string for displaying a money value to the screen.
		/// </summary>
		/// <returns>a formatted string for this Money</returns>
		public static string FormattedDollarCentString(double value)
		{
			// here, value is a double in (0,double.MaxValue]
			if (Math.Abs(value) < 1)
			{
				return Math.Round(value * 100, 4).ToString() + " cents";
			}
			// here, value is a double in [1,double.MaxValue] (or that range negative)
			else
			{
				return "$" + ToStringAddZeroIfNeeded(Math.Round(value, 4));
			}
		}

		/// <summary>
		/// Formats the inputted double-type value as a string, and if it will turn out with one decimal place, adds a zero.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static string ToStringAddZeroIfNeeded(double value)
		{
			#region commented out: long number handling
			//// The following code is used to handle large numbers of significant figures (if using decimals instead of doubles and not rounding)
			//string tempDollars = value.ToString();
			//if(tempDollars.Length >= 20)
			//{
			//	return "$" + tempDollars.Remove(20);
			//}
			//return "$" + tempDollars;
			#endregion commented out: long number handling

			string output = value.ToString();
			// Check if a zero will need to be added (to follow the following format: "24.40")
			if (
				value != Math.Floor(value) &&  // value is not an integer, i.e. there will be a decimal place
				value * 10 == Math.Floor(value * 10) // value * 10 is not an integer, i.e. there will be only one decimal place
				)
			{
				return output + "0";
			}
			else
			{
				return output;
			}
		}
	}
}
