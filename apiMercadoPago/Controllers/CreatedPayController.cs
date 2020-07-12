using apiMercadoPago.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace apiMercadoPago.Controllers
{
	public class CreatedPayController : ApiController
	{

		public HttpResponseMessage Post([FromBody] SendApi data)
		{
			var status = Request.CreateResponse();
			try
			{

				if (String.IsNullOrEmpty(data.Payer.userName) || String.IsNullOrEmpty(data.Payer.userSurname) || String.IsNullOrEmpty(data.Payer.userEmail))
				{
					status = Request.CreateResponse(HttpStatusCode.BadRequest, "Usuario,Apellido,Email son campos obligatorios");
				}
				else if (String.IsNullOrEmpty(data.Payer.userPhone.Number))
				{
					status = Request.CreateResponse(HttpStatusCode.BadRequest, "El telefono es obligatorio");
				}
				else if (String.IsNullOrEmpty(data.Payer.userIdentification.Number) || String.IsNullOrEmpty(data.Payer.userIdentification.Type))
				{
					status = Request.CreateResponse(HttpStatusCode.BadRequest, "Los campos de userIdentification son obligatorios");
				}
				else if (String.IsNullOrEmpty(data.Payer.userAddress.StreetName) || String.IsNullOrEmpty(data.Payer.userAddress.ZipCode))
				{
					status = Request.CreateResponse(HttpStatusCode.BadRequest, "Los campos de userAddress son obligatorios");
				}
				if(data.items.Count == 0)
				{
					status = Request.CreateResponse(HttpStatusCode.BadRequest, "No se ha enviado items para agregar");
				}else
				{
					var items = data.items;
					foreach (Items element in items){
						if(string.IsNullOrEmpty(element.itemCurrencyid) || string.IsNullOrEmpty(element.itemId)|| string.IsNullOrEmpty(element.itemTitle))
						{
							status = Request.CreateResponse(HttpStatusCode.BadRequest, "Los Items que desea agregar no tienes los parametros correctos");
						}else
						{
							status = Request.CreateResponse(HttpStatusCode.OK, "Verificacion Exitosa");
						}
					};
				}
			}
			catch(Exception ex)
			{
				status = Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal server error");
			}




			return status;
		}

		public HttpResponseMessage Get()
		{
			var status = Request.CreateResponse();
			status = Request.CreateResponse(HttpStatusCode.OK, "Hola mundo");
			//status = Request.CreateResponse(HttpStatusCode.OK, rowCount, JsonMediaTypeFormatter.DefaultMediaType);

			return status;
		}
	}

	public class Array<Items>
	{
		public Items item;
	}
}
