using apiMercadoPago.Models;
using MercadoPago.DataStructures.AdvancedPayment;
using MercadoPago.Resources;
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

		public HttpResponseMessage Post([FromBody]	userAndItems  data )
		{
			var status = Request.CreateResponse();
			Response response = new Response();
			SetData set = new SetData();

			try
			{
				if(String.IsNullOrEmpty(data.user.email) || String.IsNullOrEmpty(data.user.typeIdentificacion) || String.IsNullOrEmpty(data.user.identification)){
					response.status = false;
					response.message = "Los datos del usuario estan incompletos por favor verificar";
					status = Request.CreateResponse(HttpStatusCode.BadRequest, response);
				}
				if(data.UserItems.Count == 0)
				{
					response.status = false;
					response.message = "No se ha enviado ningun item para agregar";
					status = Request.CreateResponse(HttpStatusCode.BadRequest, response);
				}
				else
				{
					foreach(UserItems items in data.UserItems)
					{
						if(String.IsNullOrEmpty(items.id) || String.IsNullOrEmpty(items.title) || String.IsNullOrEmpty(items.currencyid))
						{
							response.status = false;
							response.message = "Uno de los productos no cuenta con los datos necesarios para ser agregados";
							status = Request.CreateResponse(HttpStatusCode.BadRequest, response);

						}
						else if(items.quantity == 0)
						{
							response.status = false;
							response.message = "Uno de los productos no cuenta con los datos necesarios para ser agregados";
							status = Request.CreateResponse(HttpStatusCode.BadRequest, response);
						}else if (items.unitPrice < 2000)
						{
							response.status = false;
							response.message = "Uno de los productos no cuenta con el valor minimo; Valor minimo 2000";
							status = Request.CreateResponse(HttpStatusCode.BadRequest, response);
						}
						else
						{
							var RData = set.setDataInMercado(data);
							if(RData.status == true)
							{
								response.status = RData.status;
								response.message = RData.message;
								status = Request.CreateResponse(HttpStatusCode.OK, response);
							}
							else
							{
								response.status = RData.status;
								response.message = RData.message;
								status = Request.CreateResponse(HttpStatusCode.InternalServerError, response);
							}
							
						}

					}
				}
				
			}
			catch(Exception error)
			{
				status = Request.CreateResponse(HttpStatusCode.InternalServerError, error);
			}

			


			return status;
		}

	}

}
