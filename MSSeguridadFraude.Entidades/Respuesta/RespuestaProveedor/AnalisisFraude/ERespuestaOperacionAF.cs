using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude
{
    /// <summary>
    /// Entidad de respuesta general del MSSeguridadFraude
    /// </summary>
    [Serializable]
    [DataContract]
    public class ERespuestaOperacionAF
    {
        /// <summary>
        /// Entidad que contiene el codigo y mensaje de respuesta
        /// </summary>
        [DataMember]
        public ERespuesta Respuesta { get; set; }

        /// <summary>
        /// Estado de la operacion
        /// </summary>
        [DataMember]
        public ERespuestaAF RespuestaAF { get; set; }
    }
}
