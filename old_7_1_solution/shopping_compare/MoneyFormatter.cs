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
		public static string FormattedDollarCentString(double dollars)
		{
			// here, dollars is any double

			if (dollars < 0 || double.IsNaN(dollars) || double.IsPositiveInfinity(dollars))
			{
				throw new ArgumentOutOfRangeException("value is negative, NaN, or positive infinity.");
			}
			else if (dollars < 1)
			{
				// here, dollars is a double in [0,1)
				// So, format it as cents:

				double cents = dollars * 100;

				// Keeping 3 sigfigs:
				int roundDigits =
					(cents < 10.0) ?
					((cents < 1.00) ? 3 : 2) :
					1;

				return Math.Round(cents, roundDigits).ToString() + " cents";
			}
			else
			{
				// here, dollars is a double in [1,double.MaxValue]
				// So, format it in dollar format:

				return "$" + ToStringAddZeroIfNeeded(Math.Round(dollars, 2));
			}
		}

		/// <summary>
		/// Formats the inputted double-type value as a string, and if it will turn out with one decimal place, adds a zero.
		/// </summary>
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
