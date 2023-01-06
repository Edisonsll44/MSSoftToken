using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Negocio.NeServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace MSSoftToken
{
    /// <summary>
    /// Servicio  SofToke  que expone metodos de operaciones para obtene Procesos el softoken
    /// </summary>
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class ServicioSoftToken : IServicioSoftToken
	{



		public ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion)
		{
            return NeServicio.ActivarTOTP(operacion);
        }

		public ERespuesta DesabilitarTOTP(EOperacionesTOTP operacion)
		{
			return NeServicio.DesabilitarTOTP(operacion);
        }

		public ERespuesta DesbloquearTOTP(EOperacionesTOTP operacion)
		{
            return NeServicio.DesbloquearTOTP(operacion);
        }

		public ERespuesta SincronizarTiempoTOTP(EOperacionesTOTP operacion)
		{
            return null;
        }

		
	}
}
