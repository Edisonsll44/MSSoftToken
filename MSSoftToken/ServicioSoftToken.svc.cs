using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using MSSeguridadFraude.Negocio.NeServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;

namespace MSSoftToken
{
    /// <summary>
    /// Servicio  SofToke  que expone metodos de operaciones para obtene Procesos el softoken
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServicioSoftToken : IServicioSoftToken
	{



		public ERespuestaOperacionSoftToken ActivarTOTP(EOperacionATOTP operacion)
		{
            return NeServicio.ActivarTOTP(operacion);
        }

		public ERespuestaOperacionSoftToken DesabilitarTOTP(EOperacionesTOTP operacion)
		{
			return NeServicio.DesabilitarTOTP(operacion);
        }

		public ERespuestaOperacionSoftToken BloquearTotp(EOperacionesTOTP operacion)
		{
			return NeServicio.ProcesarBloqueoUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
		}

		public ERespuesta DesabilitarTOTP(EOperacionesTOTP operacion)
		public ERespuestaOperacionSoftToken DesbloquearTOTP(EOperacionesTOTP operacion)
		{
            return NeServicio.DesbloquearTOTP(operacion);
        }

		public ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion)
		{
			throw new NotImplementedException();
		}

		public ERespuestaOperacionSoftToken EliminarTotp()
		{
			throw new NotImplementedException();
		}

		public ERespuestaOperacionSoftToken HabilitarTotp()
		{
			throw new NotImplementedException();
		}

		public ERespuestaOperacionSoftToken LoginOtp()
		{
			throw new NotImplementedException();
		}

		public ERespuestaOperacionSoftToken RegistrarUsuario()
		{
			throw new NotImplementedException();
		}
            return NeServicio.SincronizarTiempoTOTP(operacion);
        }

		
	}
}
