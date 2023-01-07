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


        

        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "ActivarTOTP",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken ActivarTOTP(EOperacionATOTP operacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "SincronizarTiempoTOTP",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "DesbloquearTOTP",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken DesbloquearTOTP( EOperacionesTOTP operacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "DesabilitarTOTP",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken DesabilitarTOTP( EOperacionesTOTP operacion);
	}


	
}
