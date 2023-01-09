using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken
{
    /// <summary>
    /// 
    /// </summary>
    public class ERespuestaOperacionSoftToken
    {/// <summary>
     /// Entidad que contiene el codigo y mensaje de respuesta
     /// </summary>
        [DataMember]
        public ERespuesta Respuesta { get; set; }

        /// <summary>
        /// Entidad que contiene el codigo y mensaje de respuesta
        /// </summary>
        [DataMember]
        public ERespuestaST RespuestaSoftToken { get; set; }
    }
}
