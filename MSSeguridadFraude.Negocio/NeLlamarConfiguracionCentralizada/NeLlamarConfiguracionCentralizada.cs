using MSSeguridadFraude.AccesoDatos.AdComun;

namespace MSSeguridadFraude.Negocio.NeLlamarConfiguracionCentralizada
{
    /// <summary>
    /// NeLlamarConfiguracionCentralizada
    /// </summary>
    public class NeLlamarConfiguracionCentralizada
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected NeLlamarConfiguracionCentralizada()
        {
        }

        /// <summary>
        /// Carga la Configuracion centralizada
        /// </summary>
        public static void CargarConfiguraciones()
        {
            AdLlamarConfiguracionCentralizada.CargarConfiguraciones();
        }

        /// <summary>
        /// Consulta el tag de la Configuracion centralizada
        /// </summary>
        /// <param name="tag">Tag para acceder a la configuracion centralizada</param>
        /// <returns>el tag de Configuracion</returns>
        public static string ConsultarTagConfiguracion(string tag)
        {
            return AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(tag);
        }

        /// <summary>
        /// Consultar servidor Autorizado
        /// </summary>
        /// <param name="servidor">Servidor</param>
        /// <returns>el nombre del Servidor Autorizado</returns>
        public static bool ConsultarServidorAutorizado(string servidor)
        {
            return AdLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(servidor);
        }
    }
}
