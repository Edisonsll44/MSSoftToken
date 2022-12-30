using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken
{
    /// <summary>
    /// Entidad de respuesta para integracion VU Softoken
    /// </summary>
    [DataContract]
    [Serializable]
    public class ERespuestaST
    {
        /// <summary>
        /// Codigo de mensaje devuelto por el proveedor
        /// </summary>
        [DataMember]
        public string Codigo { get; set; }

        /// <summary>
        /// Mensaje  obtenido en la respuesta del proveedor 
        /// </summary>
        [DataMember]
        public string Mensaje { get; set; }

        /// <summary>
        /// Fecha y hora de la respuesta Obtenida
        /// </summary>
        [DataMember]
        public DateTime FechaRespuesta { get; set; }
    }
}
