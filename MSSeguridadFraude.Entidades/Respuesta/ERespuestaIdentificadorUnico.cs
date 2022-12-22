    using System;

namespace MSSeguridadFraude.Entidades.Respuesta
{
    /// <summary>
    /// Entidad que contiene la respuesta del identificador unico
    /// </summary>
    [Serializable]
    public class ERespuestaIdentificadorUnico
    {
        /// <summary>
        /// Respuesta del servicio
        /// </summary>
        public ERespuesta Respuesta { get; set; }

        /// <summary>
        /// Identificador Unico
        /// </summary>
        public string IdentificadorUnico { get; set; }
    }
}
