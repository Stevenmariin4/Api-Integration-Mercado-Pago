using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiMercadoPago.Models
{
	public class UserItems
	{
		public string id { get; set; }
		public string title { get; set; }

		public int quantity { get; set; }

		public string currencyid { get; set; }

		public int unitPrice { get; set; }
	}
}