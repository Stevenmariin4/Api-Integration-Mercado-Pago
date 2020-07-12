using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiMercadoPago.Models
{
	public class Address
	{
		private static Address instance = new Address();

		private string streetname;

		private string zipcode;

		private int streetnumber;


		private Address() { }
		public static Address getInstance()
		{
			return instance;
		}

		public string StreetName
		{
			get
			{
				return streetname;
			}
			set
			{
				streetname = value;
			}
		}

		public string ZipCode
		{
			get
			{
				return zipcode;
			}
			set
			{
				zipcode = value;
			}

		}

		public int StreetNumber
		{
			get
			{
				return streetnumber;
			}
			set
			{
				streetnumber = value;
			}
		}
	}
}