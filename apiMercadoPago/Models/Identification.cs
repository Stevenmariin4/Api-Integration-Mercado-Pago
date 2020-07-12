using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiMercadoPago.Models
{
	public class Identification
	{
		private static Identification instance = new Identification();

		private string type;

		private string number;


		private Identification() { }
		public static Identification getInstance()
		{
			return instance;
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

		public string Type{
				
			get
			{
				return type;
			}

			set
			{
				type = value;
			}

		}
	}
}