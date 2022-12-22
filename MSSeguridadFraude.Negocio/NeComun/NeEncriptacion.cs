using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Utilitarios;

namespace MSSeguridadFraude.Negocio.NeComun
{
    /// <summary>
    /// NeEncriptacion
    /// </summary>
    public  class NeEncriptacion
    {
        /// <summary>
        /// Instanciar y recuperar parametros desde Centralizada para la encriptación y desencriptacion
        /// </summary>
        /// <returns>CSeguridad</returns>
        public static CSeguridad InstanciarEncriptacion()
        {
            string llave = NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.Seguridad.LLAVE);
            string vector = NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.Seguridad.VECTOR);
            string salt = NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.Seguridad.SALT);
            return new CSeguridad(llave, vector, salt);
        }
    }
}
