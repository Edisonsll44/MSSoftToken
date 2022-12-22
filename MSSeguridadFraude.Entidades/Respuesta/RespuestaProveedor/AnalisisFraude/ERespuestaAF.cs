using MSSeguridadFraude.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude
{
    /// <summary>
    /// Entidad de entrada para enviarla a proveedor de seguridad
    /// </summary>
    [DataContract]
    [Serializable]
    public class ERespuestaAF
    {
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public int result { get; set; }
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public int score { get; set; }
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public string triggeredRules { get; set; }
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public string error { get; set; }
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public int status { get; set; }
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public int IdEvento { get; set; }
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public int eventId { get; set; }
        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public int ofacCoincidence { get; set; }
    }
}
