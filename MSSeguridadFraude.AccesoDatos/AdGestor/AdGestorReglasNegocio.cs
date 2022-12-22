using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.MSReglasNegocio;
using MSSeguridadFraude.Comun.Constantes;
using System;
using System.Net;
using Tcs.Provider.Settings.Base;

namespace MSSeguridadFraude.AccesoDatos.AdGestor
{
    /// <summary>
    /// Gestor del servicio de reglas de negocio
    /// </summary>
    public  class AdGestorReglasNegocio
    {

        protected AdGestorReglasNegocio()
        {

        }
        /// <summary>
        /// Permite gestionar la conexion con el servicio de reglas de negocio
        /// </summary>
        /// <returns>ServicioReglasNegocio</returns>
        public static ServicioReglasNegocio ConectarServicioReglasNegocio()
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            ServicioReglasNegocio servicioReglasNegocio = new ServicioReglasNegocio
            {
                Url = AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.TagsCentralizada.URL_SERVICIO_REGLAS_NEGOCIO),
                Timeout = Convert.ToInt32(SettingsManager.Group("ConfiguracionesServicioWeb")["TimeOutServicioReglasNegocio"].ToString())
            };
            return servicioReglasNegocio;
        }
    }
}
