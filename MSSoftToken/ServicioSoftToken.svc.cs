using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using MSSeguridadFraude.Negocio.NeServicio;
using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Services.Description;

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

		public ERespuestaOperacionSoftToken DesbloquearTOTP(EOperacionesTOTP operacion)
		{
            return NeServicio.DesbloquearTOTP(operacion);
        }

		public ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion)
		{
			return NeServicio.SincronizarTiempoTOTP(operacion);
		}

		public ERespuestaOperacionSoftToken EliminarTotp(EOperacionesTOTP operacion)
		{
			return NeServicio.ProcesarEliminarTotp(operacion, HttpContext.Current.Request.UserHostAddress);
		}

		public ERespuestaOperacionSoftToken HabilitarTotp(EOperacionesTOTP operacion)
		{
			return NeServicio.ProcesarHabilitarTotp(operacion, HttpContext.Current.Request.UserHostAddress);

		}

		public ERespuestaOperacionSoftToken LoginOtp(EOperacionesLoginTOTP operacion)
		{
			return NeServicio.ProcesarLoginTotp(operacion, HttpContext.Current.Request.UserHostAddress);
		}

		public ERespuestaOperacionSoftToken RegistrarUsuario(EOperacionesRegistrarTOTP operacion)
		{
			return NeServicio.ProcesarRegistrarUsuario(operacion, HttpContext.Current.Request.UserHostAddress);

		}

		public ERespuestaOperacionSoftToken EstadoUsuario(EOperacionesTOTP operacion)
		{
			return NeServicio.ProcesarEstadoUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
		}
	}
}
