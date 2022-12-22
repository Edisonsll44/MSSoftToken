using System;

namespace MSSeguridadFraude.Entidades.Mensajes
{
    /// <summary>
    /// Clase para manejo de Mensajes desde parametros
    /// </summary>
    [Serializable]
    public class EMensaje
    {
        /// <summary>
        /// Codigo de mensaje en la tabla de mensajes de las aplicaciones
        /// </summary>
        public string CodigoMensajeAplicacion { get; set; }

        /// <summary>
        /// Mensaje de respuesta hacia los legacys
        /// </summary>
        public string MensajeAplicacion { get; set; }

        /// <summary>
        /// Codigo de mensaje en la tabla de mensaje de empresas
        /// </summary>
        public string CodigoMensajeEmpresa { get; set; }

        /// <summary>
        /// Codigo de mensaje en la tabla de mensajes de proveedores
        /// </summary>
        public string CodigoMensajeProveedor { get; set; }

        /// <summary>
        /// Codigo de mensaje de la tabla mensaje de siglo 21
        /// </summary>
        public string CodigoMensajeSiglo { get; set; }
    }
}
