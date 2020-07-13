using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiMercadoPago.Models
{
	public class userAndItems
	{
		public UserData user { get; set; }

		public  List<UserItems> UserItems { get; set; }
	}
}