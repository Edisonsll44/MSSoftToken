using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MSSoftToken
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
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
        ERespuestaOperacionSoftToken RegistrarUsuario(EOperacionRegistrarTOTP operacion);

       


        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "ActivarUsuario",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken ActivarUsuario(EOperacionATOTP operacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "SincronizarTiempoServidor",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken SincronizarTiempoServidor(EOperacionATOTP operacion);


        /// <summary>
		/// Bloquear usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "BloquearUsuario",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken BloquearUsuario(EOperacionTOTP operacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "DesbloquearUsuario",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken DesbloquearUsuario(EOperacionTOTP operacion);


        /// <summary>
        /// Habilitar usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "HabilitarUsuario",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken HabilitarUsuario(EOperacionTOTP operacion);

        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "InhabilitarUsuario",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken InhabilitarUsuario(EOperacionTOTP operacion);


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
        ERespuestaOperacionSoftToken EstadoUsuario(EOperacionTOTP operacion);

        /// <summary>
		/// Eliminar usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		[OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "EliminarUsuario",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken EliminarUsuario(EOperacionTOTP operacion);



        [OperationContract]
        [WebInvoke(Method = "POST",
                   BodyStyle = WebMessageBodyStyle.Bare,
                   UriTemplate = "LoginTopt",       // Nombre adicional del metodo para la transaccion
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json)]
        ERespuestaOperacionSoftToken LoginTotp(EOperacionLoginTOTP operacion);

    }


	
}
