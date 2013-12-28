using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shopping_compare
{
	static class MoneyFormatter
	{
		/// <summary>
		/// Returns a formatted string for this Money.
		/// </summary>
		/// <returns>a formatted string for this Money</returns>
		public static String FormattedString(double val)
		{
			// here, val is a double in (0,double.MaxValue]
			if (Math.Abs(val) < 1)
			{
				#region commented out: long number handling
				//// The following code is used to handle large numbers of significant figures (if using decimals instead of doubles and not rounding)
				//string tempCents = (val * 100).ToString();
				//if(tempCents.Length >= 20)
				//{
				//	return tempCents.Remove(20) + " cents";
				//}
				//return tempCents + " cents";
				#endregion commented out: long number handling

				return Math.Round(val * 100, 4).ToString() + " cents";
			}
			// here, val is a double in [1,double.MaxValue] (or that range negative)
			else
			{
				#region commented out: long number handling
				//// The following code is used to handle large numbers of significant figures (if using decimals instead of doubles and not rounding)
				//string tempDollars = val.ToString();
				//if(tempDollars.Length >= 20)
				//{
				//	return "$" + tempDollars.Remove(20);
				//}
				//return "$" + tempDollars;
				#endregion commented out: long number handling

				String outputString = "$" + Math.Round(val, 4).ToString();

				// Check if a zero will need to be added (to follow the following format: "$24.40")
				if (
					val != Math.Floor(val) &&  // val is not a whole number, i.e. there will be a decimal place
					val * 10 == Math.Floor(val * 10) // val * 10 is not a whole number, i.e. there will be only one decimal place
					)
				{
					return outputString + "0";
				}
				else
				{
					return outputString;
				}
			}
		}
	}
}
