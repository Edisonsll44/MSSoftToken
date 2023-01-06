using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using System;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web.Script.Services;

namespace MSSoftToken
{
	[ServiceContract]
	public interface IServicioSoftToken
	{
        ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion);
        ERespuesta DesbloquearTOTP( EOperacionesTOTP operacion);
        ERespuesta DesabilitarTOTP( EOperacionesTOTP operacion);

		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "RegistrarUsuario",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken RegistrarUsuario();

		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "BloquearTotp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken BloquearTotp(EOperacionesTOTP operacion);


		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "HabilitarTotp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken HabilitarTotp();


		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "EliminarTotp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken EliminarTotp();


		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "LoginOtp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken LoginOtp();
	}


	
}
