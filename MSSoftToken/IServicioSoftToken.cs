using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace MSSoftToken
{
	[ServiceContract]
	public interface IServicioSoftToken
	{
		/// <summary>
		/// Registro de usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "RegistrarUsuario",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken RegistrarUsuario(EOperacionesRegistrarTOTP operacion);

		/// <summary>
		/// Activacion de OTP
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "ActivarTOTP",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken ActivarTOTP(EOperacionATOTP operacion);

		/// <summary>
		/// Sincronizacion de tiempo para OTP
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "SincronizarTiempoTOTP",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion);

		/// <summary>
		/// Bloquear usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "BloquearTotp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken BloquearTotp(EOperacionesTOTP operacion);

		/// <summary>
		/// Desbloquear usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				  BodyStyle = WebMessageBodyStyle.Bare,
				  UriTemplate = "DesbloquearTOTP",       // Nombre adicional del metodo para la transaccion
				  RequestFormat = WebMessageFormat.Json,
				  ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken DesbloquearTOTP(EOperacionesTOTP operacion);

		/// <summary>
		/// Desabilitar usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				  BodyStyle = WebMessageBodyStyle.Bare,
				  UriTemplate = "DesabilitarTOTP",       // Nombre adicional del metodo para la transaccion
				  RequestFormat = WebMessageFormat.Json,
				  ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken DesabilitarTOTP(EOperacionesTOTP operacion);

		/// <summary>
		/// Habilitar usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "HabilitarTotp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken HabilitarTotp(EOperacionesTOTP operacion);

		/// <summary>
		/// Eliminar usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "EliminarTotp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken EliminarTotp(EOperacionesTOTP operacion);

		/// <summary>
		/// Estado del usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "EstadoUsuario",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken EstadoUsuario(EOperacionesTOTP operacion);

		/// <summary>
		/// Login Otp
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
		[WebInvoke(Method = "POST",
				   BodyStyle = WebMessageBodyStyle.Bare,
				   UriTemplate = "LoginOtp",       // Nombre adicional del metodo para la transaccion
				   RequestFormat = WebMessageFormat.Json,
				   ResponseFormat = WebMessageFormat.Json)]
		ERespuestaOperacionSoftToken LoginOtp(EOperacionesLoginTOTP operacion);






	}


	
}
