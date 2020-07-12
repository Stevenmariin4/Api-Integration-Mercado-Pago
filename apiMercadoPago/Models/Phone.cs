using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiMercadoPago.Models
{
	public class Phone
	{
		private static Phone instance = new Phone();

		private string areaCode;

		private string number;

		public Phone() { 		
		
		}

		public Phone(string areaCode, string number)
		{
			this.areaCode = areaCode;
			this.number = number;
		}
		public static Phone getInstance()
		{
			return instance;
		}

		public string AreaCode
		{
			get
			{
				return areaCode;
			}
			set
			{
				areaCode = value;
			}
		}

		public string Number
		{
			get
			{
				return number;
			}
			set
			{
				number = value;
			}
		}

	}
}