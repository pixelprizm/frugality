using System;
using System.Collections.Generic;
using System.ComponentModel; // for INotifyPropertyChanged
using System.Linq;
using System.Text;

namespace shopping_compare
{
	public class CompareItem : INotifyPropertyChanged
	{
		#region Data

		#region Fields and Field-backed Properties

		private double _price;
		public double Price
		{
			get
			{
				return _price;
			}
			set
			{
				// Only call NotifyPropertyChanged if it has indeed changed.
				double old = _price;
				_price = value;
				//if(_price != old)
				//{
				// if Price is changing either to or from 0, Good may have changed.
				if (old == 0 || _price == 0)
					NotifyPropertyChanged("Good");

				NotifyPropertyChanged("Price");
				NotifyPropertyChanged("PricePerUnit");
				//}
			}
		}

		private double _quantity;
		public double Quantity
		{
			get
			{
				return _quantity;
			}
			set
			{
				// Only call NotifyPropertyChanged if it has indeed changed.
				double old = _quantity;
				_quantity = value;
				//if(_quantity != old)
				//{
				// if Quantity is changing either to or from 0, Good may have changed.
				if (old == 0 || _quantity == 0)
					NotifyPropertyChanged("Good");

				NotifyPropertyChanged("Quantity");
				NotifyPropertyChanged("PricePerUnit");
				//}
			}
		}

		// Implicit field
		public int Number { get; private set; }

		// The following property is generally for exterior use.
		/// <summary>
		/// Used for assigning CompareItems to a range of colors by normalizing them between 0 to 1 (based on the PricePerUnit)
		/// </summary>
		private double _colorIndex = -1;
		public double ColorIndex
		{
			get { return _colorIndex; }
			set { _colorIndex = value; NotifyPropertyChanged("ColorIndex"); }
		}

		#endregion

		#region Non-field Properties

		public double PricePerUnit
		{
			get
			{
				if (_quantity != 0)
				{
					return _price / _quantity;
				}
				else
				{
					return -1;
				}
			}
		}

		/// <summary>
		/// False if this CompareItem has one or more blank values
		/// </summary>
		public bool Good
		{
			get
			{
				return ((_quantity != 0) && (_price != 0));
			}
		}

		#endregion Non-field Properties

		#endregion Data

		#region Constructor
		public CompareItem(int number)
		{
			Number = number;
		}
		#endregion

		#region Property Changed
		public event PropertyChangedEventHandler PropertyChanged;
		private void NotifyPropertyChanged(string propName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propName));
		}
		#endregion
	}
}
