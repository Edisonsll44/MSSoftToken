using System;

namespace MSSeguridadFraude.Entidades.Comun
{
    /// <summary>
    /// Entidad para consulta de la activación de logs
    /// </summary>
    [Serializable]
    public class EParametroLogs
    {
        /// <summary>
        /// Identificador en la tabla del parametro
        /// </summary>
        public int IdParametro { get; set; }

        /// <summary>
        /// Codigo de canal
        /// </summary>
        public string CodigoCanal { get; set; }

        /// <summary>
        /// Codigo de medio de invocacion
        /// </summary>
        public string CodigoMedioInvocacion { get; set; }

        /// <summary>
        /// Codigo de transaccion
        /// </summary>
        public string CodigoTransaccion { get; set; }

        /// <summary>
        /// Codigo de cabecera del tipo de log (Trazabilidad, journal eventos, etc.)
        /// </summary>
        public string CodigoCabeceraTipoLog { get; set; }

        /// <summary>
        /// Bandera que indica si el canal esta activo o no.
        /// </summary>
        public bool Activo { get; set; }
    }
}
