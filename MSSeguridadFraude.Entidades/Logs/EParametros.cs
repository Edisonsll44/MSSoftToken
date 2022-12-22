using System;

namespace MSSeguridadFraude.Entidades.Logs
{
    /// <summary>
    /// Parametros
    /// </summary>
    [Serializable]
    public class EParametros
    {
        /// <summary>
        /// NombreParametro
        /// </summary>
        public string NombreParametro { get; set; }

        /// <summary>
        /// TipoParametro
        /// </summary>
        public string TipoParametro { get; set; }

        /// <summary>
        /// ValorParametro
        /// </summary>
        public string ValorParametro { get; set; }
    }
}
