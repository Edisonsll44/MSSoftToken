using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Utilitarios;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Tcs.Provider.Settings.Base;

namespace MSSeguridadFraude.AccesoDatos.AdComun
{
    /// <summary>
    /// Clase de acceso a datos para llamar a la configuración centralizada
    /// </summary>
    public  class AdLlamarConfiguracionCentralizada
    {
        private static Hashtable configuraciones;

        /// <summary>
        /// metodo de carga de las configuraciones
        /// </summary>
        public static void CargarConfiguraciones()
        {
            int codigoAplicacion = Convert.ToInt32(SettingsManager.Group("ConfiguracionesServicioWeb")["IdAplicacion"].ToString());
            int timeOutCentralizada = Convert.ToInt16(SettingsManager.Group("ConfiguracionesServicioWeb")["TimeOutServicioConfiguracionCentralizada"].ToString());

            VerificarCentro(out string urlCodigoTrabajo, out string urlConfiguracionCentralizada);

            using (ConfiguracionCentralizada.ConfiguracionCentralizada configuracionCentral = new ConfiguracionCentralizada.ConfiguracionCentralizada())
            {
                if (configuraciones != null && configuraciones.Count > 0)
                    return;

                configuraciones = Hashtable.Synchronized(new Hashtable());

                string codigoTrabajo = string.Empty;

                using (CodigoTrabajoWS.Configuracion codigoTrabajoWS = new CodigoTrabajoWS.Configuracion())
                {
                    codigoTrabajoWS.Url = urlCodigoTrabajo;
                    codigoTrabajoWS.Timeout = timeOutCentralizada;

                    string aplicacionOfuscada =
                        Convert.ToBase64String(
                            Encoding.UTF8.GetBytes(
                                Convert.ToBase64String(
                                    Encoding.UTF8.GetBytes(codigoAplicacion.ToString()))));

                    CodigoTrabajoWS.Respuesta respuestaTrabajo = codigoTrabajoWS.ObtenerCodigoTrabajo(aplicacionOfuscada);
                    
                    if (respuestaTrabajo.Codigo != 0)
                    {
                        Exception ex = new Exception(string.Format("SERVICIO CENTRALIZADO: {0}.", respuestaTrabajo.MensajeMostrar));
                        AdLogsEventViewer.GuardarLogEventViewer(Environment.NewLine + ex.Message);
                        throw ex;
                    }
                    else
                    {
                        codigoTrabajo = respuestaTrabajo.Configuraciones;
                    }
                }

                if (codigoTrabajo != string.Empty)
                {
                    configuracionCentral.Url = urlConfiguracionCentralizada;
                    configuracionCentral.Timeout = timeOutCentralizada;

                    ConfiguracionCentralizada.Respuesta respuesta = configuracionCentral.ConsultarConfiguracion(codigoTrabajo);
                    
                    if (respuesta.Codigo != 0)
                    {
                        Exception ex = new Exception(string.Format("SERVICIO CENTRALIZADO: {0}", respuesta.MensajeMostrar));
                        AdLogsEventViewer.GuardarLogEventViewer(Environment.NewLine + ex.Message);
                        throw ex;
                    }
                    else
                    {
                        string xmlConfiguracion = Encoding.UTF8.GetString(Convert.FromBase64String(respuesta.Configuraciones));

                        Configuracion[] listaConfiguraciones = DeserealizarXML(xmlConfiguracion);

                        foreach (Configuracion conf in listaConfiguraciones)
                        {
                            if (!configuraciones.Contains(conf.Nombre))
                            {
                                configuraciones.Add(conf.Nombre, conf.DetalleConfiguracion);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Consulta de Tags de configuración Centralizada
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static string ConsultarTagConfiguracion(string tag)
        {
            if (configuraciones == null || configuraciones.Count <= 0)
            {
                CargarConfiguraciones();
            }

            if (configuraciones.ContainsKey(tag))
            {
                return configuraciones[tag].ToString();
            }

            return string.Empty;
        }

        /// <summary>
        /// Valida si es servidor autorizado
        /// </summary>
        /// <param name="servidor"></param>
        /// <returns></returns>
        public static bool ConsultarServidorAutorizado(string servidor)
        {
            if (configuraciones == null || configuraciones.Count <= 0)
            {
                CargarConfiguraciones();
            }

            return configuraciones.ContainsKey(servidor);
        }

        /// <summary>
        /// Deserealización de XML
        /// </summary>
        /// <param name="cadena"></param>
        /// <returns></returns>
        private static Configuracion[] DeserealizarXML(string cadena)
        {
            using (StringReader lector = new StringReader(cadena))
            {
                XmlSerializer s = new XmlSerializer(typeof(Configuracion[]));
                Configuracion[] retObject = (Configuracion[])s.Deserialize(lector);
                return retObject;
            }
        }

        /// <summary>
        /// Metodo para validar el servidor y obtener las configuraciones
        /// </summary>
        /// <param name="UrlCodigoTrabajo"></param>
        /// <param name="UrlConfiguracion"></param>
        private static void VerificarCentro(out string UrlCodigoTrabajo, out string UrlConfiguracion)
        {
            string nombreervidor = CUtil.ObtenerNombreServidor().ToUpper();
            string servidorDca = SettingsManager.Group("ConfiguracionesServicioWeb")["ServidorDCA"].ToString();

            if (nombreervidor.StartsWith(servidorDca))
            {
                UrlCodigoTrabajo = SettingsManager.Group("ConfiguracionesServicioWeb")["UrlServicioConfiguracionDCA"].ToString();
                UrlConfiguracion = SettingsManager.Group("ConfiguracionesServicioWeb")["UrlServicioConfiguracionCentralizadaDCA"].ToString();
            }
            else
            {
                UrlCodigoTrabajo = SettingsManager.Group("ConfiguracionesServicioWeb")["UrlServicioConfiguracion"].ToString();
                UrlConfiguracion = SettingsManager.Group("ConfiguracionesServicioWeb")["UrlServicioConfiguracionCentralizada"].ToString();
            }
        }
    }

    [Serializable]
    public class Configuracion
    {
        /// <summary>
        /// Nombre de la configuración
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Detalle de la configuración
        /// </summary>
        public string DetalleConfiguracion { get; set; }
    }
}