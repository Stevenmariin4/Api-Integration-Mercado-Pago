using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiMercadoPago.Models
{
	public class Items
	{
		private static Items instance = new Items();
		private Items() { }
		public static Items getInstance()
		{
			return instance;
		}
		private string id;
		private string title;
		private string description;
		private int Quantity;
		private string CurrencyId;
		private float UnitPrice;

		public string itemId
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public string itemTitle
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}

		public string  itemDescription
		{
			get { return description; }
			set { description = value; }
		}

		public int itemQuiantity
		{
			get { return Quantity; }
			set { Quantity = value; }
		}
		public string itemCurrencyid
		{
			get { return CurrencyId; }
			set { CurrencyId = value; }
		}
		public float itemUnitPrice
		{
			get { return UnitPrice; }
			set { UnitPrice = value; }
		}
	}
}