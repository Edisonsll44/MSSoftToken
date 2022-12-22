using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.Respuesta;
using System;

namespace MSSeguridadFraude.Entidades.Mensajes
{
    /// <summary>
    /// Entidad con los parametros de negocio para la consulta de mensajes
    /// </summary>
    [Serializable]
    public class EConsultaMensaje
    {
        /// <summary>
        /// Entidad de Auditoria
        /// </summary>
        public EAuditoria Auditoria { get; set; }

        /// <summary>
        /// Respuesta
        /// </summary>
        public ERespuesta Respuesta { get; set; }
    }
}