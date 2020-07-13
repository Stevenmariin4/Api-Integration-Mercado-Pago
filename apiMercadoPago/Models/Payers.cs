using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiMercadoPago.Models
{
	public class Payer
	{
		private static Payer instance = new Payer();

		private string name;

		private string surname;

		private string email;

		private Phone phone;

		private Identification identification;

		private Address address;



		private Payer() { }
		public static Payer getInstance()
		{
			return instance;
		}

		public string userName
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
			}
		}

		public string userSurname
		{
			get
			{
				return surname;
			}
			set
			{
				surname = value;
			}
		}

		public string userEmail
		{
			get
			{
				return email;
			}
			set
			{
				email = value;
			}
		}

		public Phone userPhone
		{
			get
			{
				return phone;
			}

			set
			{
				phone = value;
			}
		}

		public Identification userIdentification
		{
			get
			{
				return identification;
			}
			set
			{
				identification = value;
			}
		}

		public Address userAddress
		{
				get
			{
				return address;
			}
			set
			{
				address = value;
			}
		}

		
	}
}