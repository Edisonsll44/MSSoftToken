namespace MSSeguridadFraude.Comun.Enumeraciones
{
    /// <summary>
    /// Clase de enumeracion para campos de las respuestas de siglo
    /// </summary>
    public class CCampos
    {
        /// <summary>
        /// Enumeracion Respuesta de siglo para canal
        /// </summary>
        public enum TablaMensajes
        {
            /// <summary>
            /// CODIGO_MENSAJE
            /// </summary>
            CODIGO_MENSAJE,

            /// <summary>
            /// CODIGO_MENSAJE_SIGLO
            /// </summary>
            CODIGO_MENSAJE_SIGLO,

            /// <summary>
            /// MENSAJE
            /// </summary>
            MENSAJE
        }

        /// <summary>
        /// Enumeracion Tipo de Mensaje
        /// </summary>
        public enum TipoMensaje
        {
            /// <summary>
            /// SIGLO
            /// </summary>
            SIGLO,

            /// <summary>
            /// APP
            /// </summary>
            APP,

            /// <summary>
            /// EMPRESA
            /// </summary>
            EMPRESA,

            /// <summary>
            /// PROV
            /// </summary>
            PROV
        }
    }
}
