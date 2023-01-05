using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using System;

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

		public ERespuesta BloquearTotp()
		{
			throw new NotImplementedException();
		}

		public ERespuesta DesabilitarTOTP(EOperacionesTOTP operacion)
		{
			throw new NotImplementedException();
		}

		public ERespuesta DesbloquearTOTP(EOperacionesTOTP operacion)
		{
			throw new NotImplementedException();
		}

		public ERespuesta EliminarTotp()
		{
			throw new NotImplementedException();
		}

		public ERespuesta HabilitarTotp()
		{
			throw new NotImplementedException();
		}

		public ERespuesta LoginOtp()
		{
			throw new NotImplementedException();
		}

		public ERespuesta RegistrarUsuario()
		{
			throw new NotImplementedException();
		}
	}
}
