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



		public ERespuestaOperacionSoftToken ActivarUsuario(EOperacionATOTP operacion)
		{
        
            return NeServicio.ProcesarActivarUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
             
        }
        public ERespuestaOperacionSoftToken HabilitarUsuario(EOperacionTOTP operacion)
        {
            return NeServicio.ProcesarHabilitarUsuario(operacion, HttpContext.Current.Request.UserHostAddress);

        }

        public ERespuestaOperacionSoftToken InhabilitarUsuario(EOperacionTOTP operacion)
        {
            return NeServicio.ProcesarInhabilitarUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
        }

        public ERespuestaOperacionSoftToken BloquearUsuario(EOperacionTOTP operacion)
        {
            return NeServicio.ProcesarBloqueoUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
        }

        public ERespuestaOperacionSoftToken DesbloquearUsuario(EOperacionTOTP operacion)
		{
            return NeServicio.ProcesarDesbloquearUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
        }

		public ERespuestaOperacionSoftToken SincronizarTiempoServidor(EOperacionATOTP operacion)
		{
            return NeServicio.ProcesarSincronizarTiempoServidor(operacion, HttpContext.Current.Request.UserHostAddress);
        }

        public ERespuestaOperacionSoftToken LoginTotp(EOperacionLoginTOTP operacion)
        {
            return NeServicio.ProcesarLoginTotp(operacion, HttpContext.Current.Request.UserHostAddress);
        }

        public ERespuestaOperacionSoftToken RegistrarUsuario(EOperacionRegistrarTOTP operacion)
        {
            return NeServicio.ProcesarRegistrarUsuario(operacion, HttpContext.Current.Request.UserHostAddress);

        }
        public ERespuestaOperacionSoftToken EstadoUsuario(EOperacionTOTP operacion)
        {
            return NeServicio.ProcesarEstadoUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
        }
        public ERespuestaOperacionSoftToken EliminarUsuario(EOperacionTOTP operacion)
        {
            return NeServicio.ProcesarEliminarUsuario(operacion, HttpContext.Current.Request.UserHostAddress);
        }

        
    }
}
