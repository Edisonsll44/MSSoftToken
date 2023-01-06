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
