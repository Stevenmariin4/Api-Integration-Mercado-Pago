using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MercadoPago;
using MercadoPago.Resources;
using MercadoPago.DataStructures.Preference;
using MercadoPago.Common;
using MercadoPago.DataStructures.Payment;
using Item = MercadoPago.DataStructures.Preference.Item;
using Payer = MercadoPago.DataStructures.Preference.Payer;
using System.Configuration;

namespace apiMercadoPago.Models
{
	public class SetData
	{
		
		public Response  setDataInMercado(userAndItems data)
		{
			var appSettings = ConfigurationManager.AppSettings;
			String token = appSettings["AccessToken"];
			MercadoPago.SDK.AccessToken = token;
			var preference = new Preference();
			Response response = new Response();
			try
			{
				MercadoPago.DataStructures.AdvancedPayment.Payer payer = new MercadoPago.DataStructures.AdvancedPayment.Payer();
				payer.Email = data.user.email;
				preference.Payer = new Payer()
				{
					Email = data.user.email
				};

				foreach (UserItems items in data.UserItems)
				{
					preference.Items.Add(new Item()
					{
						Id = items.id,
						Title = items.title,
						Quantity = items.quantity,
						CurrencyId = CurrencyId.COP,
						UnitPrice = items.unitPrice
					});
				};

				preference.Taxes.Add(new Tax()
				{
					Type = TaxType.IVA,
					Value = 16
				});

				preference.Save();
				if (string.IsNullOrEmpty(preference.InitPoint))
				{
					response.status = false;
					response.message = "Error al generar url";
				}
				else
				{
					response.status = true;
					response.message = preference.InitPoint;
				}
			}
			catch(Exception error)
			{
				response.status = false;
				response.message = error.Message;
				
			}

			return response;

		}
	}
}