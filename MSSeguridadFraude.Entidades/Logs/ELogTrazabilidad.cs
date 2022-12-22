using System;

namespace MSSeguridadFraude.Entidades.Logs
{
    /// <summary>
    /// Entidad que permite el manejo del log de trazabilidad
    /// </summary>
    [Serializable]
    public class ELogTrazabilidad : ICloneable
    {
        /// <summary>
        /// Identificador del registro en la tabla del log de trazabilidad
        /// </summary>
        public long Identificador { get; set; }

        /// <summary>
        /// Id unico de transaccion en siglo 21
        /// </summary>
        public string IdUnicoTransaccionSiglo { get; set; }

        /// <summary>
        /// Identificador de la transccion en el servicio
        /// </summary>
        public string GuidServicio { get; set; }

        /// <summary>
        /// Identificador de la aplicacion cliente
        /// </summary>
        public string GuidAplicacionCliente { get; set; }

        /// <summary>
        /// Identificacion del cliente
        /// </summary>
        public string Identificacion { get; set; }

        /// <summary>
        /// codigo de canal en siglo 21
        /// </summary>
        public string CodigoCanal { get; set; }

        /// <summary>
        /// Codigo  de transaccion en siglo 21
        /// </summary>
        public string CodigoTransaccion { get; set; }

        /// <summary>
        /// Codigo del medio de invocacion en siglo 21
        /// </summary>
        public string CodigoMedioInvocacion { get; set; }

        /// <summary>
        /// Tipo de evento de log (INICIO, FIN)
        /// </summary>
        public string TipoEvento { get; set; }

        /// <summary>
        /// Metodo actual de la operacion
        /// </summary>
        public string Metodo { get; set; }

        /// <summary>
        /// Nombre del servicio o tarea que se esta ejecutando
        /// </summary>
        public string ServicioTarea { get; set; }

        /// <summary>
        /// Fecha y hora de inicio de la transaccion (DateTime.Now)
        /// </summary>
        public DateTime FechaHoraInicio { get; set; }

        /// <summary>
        /// Datos de ingreso serializados
        /// </summary>
        public string DatoIngreso { get; set; }

        /// <summary>
        /// Respuesta serializada 
        /// </summary>
        public string DatoRespuesta { get; set; }

        /// <summary>
        /// Fecha y hora en que se finaliza la operacion
        /// </summary>
        public DateTime FechaHoraFin { get; set; }

        /// <summary>
        /// Ip del cliente
        /// </summary>
        public string IpCliente { get; set; }

        /// <summary>
        /// Ip del servidor donde se ejecuta el servicio
        /// </summary>
        public string IpServidor { get; set; }

        /// <summary>
        /// Fecha y hora actual
        /// </summary>
        public DateTime FechaActual { get; set; }

        /// <summary>
        /// Metodo que permite clonar la entidad
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
