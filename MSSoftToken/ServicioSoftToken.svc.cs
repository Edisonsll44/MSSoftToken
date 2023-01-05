using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using MSSeguridadFraude.Negocio.NeServicio;
using System;
using System.Web;

namespace MSSoftToken
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
	public class ServicioSoftToken : IServicioSoftToken
	{
		public ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion)
		{
			throw new NotImplementedException();
		}

		public ERespuestaOperacionSoftToken BloquearTotp(EOperacionesTOTP operacion)
		{
			return NeServicio.ProcesarBloqueoUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
		}

		public ERespuesta DesabilitarTOTP(EOperacionesTOTP operacion)
		{
			throw new NotImplementedException();
		}

		public ERespuesta DesbloquearTOTP(EOperacionesTOTP operacion)
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
	}
}
