using MSSeguridadFraude.Entidades.Comun;
using System;

namespace MSSeguridadFraude.Entidades.Logs
{
    /// <summary>
    /// entidada para manejo de excepciones de aplicacion
    /// </summary>
    [Serializable]
    public class ELogsExcepcion : ICloneable
    {
        /// <summary>
        /// Datos de Auditoria
        /// </summary>
        public EAuditoria Auditoria { get; set; }

        /// <summary>
        /// Metodo en donde se produjo la excepcion
        /// </summary>
        public string Metodo { get; set; }

        /// <summary>
        /// Identificador GUID
        /// </summary>
        public string GUID { get; set; }

        /// <summary>
        /// Pila de Seguimiento de error
        /// </summary>
        public string PiladeError { get; set; }

        /// <summary>
        /// Mensaje de la Excepcion
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Excepcion de la aplicacion
        /// </summary>
        public string Excepcion { get; set; }

        /// <summary>
        /// Dato de ingreso
        /// </summary>
        public string DatosIngreso { get; set; }

        /// <summary>
        /// Fecha Hora de la Excepcion
        /// </summary>
        public DateTime FechaHora { get; set; }

        /// <summary>
        /// Trama de salida
        /// </summary>
        public string DatosSalida { get; set; }

        /// <summary>
        /// Metodo que permite clonar la entidad
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}