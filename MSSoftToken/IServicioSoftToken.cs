﻿using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using System.ServiceModel;

namespace MSSoftToken
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
	[ServiceContract]
	public interface IServicioSoftToken
	{
        ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion);
        ERespuesta DesbloquearTOTP( EOperacionesTOTP operacion);
        ERespuesta DesabilitarTOTP( EOperacionesTOTP operacion);

		ERespuesta RegistrarUsuario();
		ERespuesta BloquearTotp();
		ERespuesta HabilitarTotp();
		ERespuesta EliminarTotp();
		ERespuesta LoginOtp();
	}


	
}
