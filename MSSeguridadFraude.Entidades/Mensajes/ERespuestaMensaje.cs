using MSSeguridadFraude.Entidades.Respuesta;
using System;

namespace MSSeguridadFraude.Entidades.Mensajes
{
    /// <summary>
    /// Entidad para manejo de mensajes de respeusta Parametrizables y Homologados
    /// </summary>
    [Serializable]
    public class ERespuestaMensaje
    {
        /// <summary>
        /// retorna repsuesta de la consulta en la Base
        /// </summary>
        public ERespuesta Respuesta { get; set; }

        /// <summary>
        /// Mensaje Consultado en la Base de datos ya homologado deacuerdo a parametros
        /// </summary>
        public EMensaje RespuestaMensaje { get; set; }
    }
}