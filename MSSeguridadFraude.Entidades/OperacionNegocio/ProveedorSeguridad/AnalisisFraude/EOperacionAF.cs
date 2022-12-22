using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad.AnalisisFraude
{
    /// <summary>
    /// Entidad de entrada para enviarla a proveedor de seguridad
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionAF
    {
        /// <summary>
        /// Usuario del Portal que ejecuta la operacion
        /// </summary>
        [DataMember]
        public string userId { get; set; }
        /// <summary>
        /// Clave del API, tomada de Centralizada para consumo del servicio
        /// de fraude, esta propiedad se duplica porque no esta estandarizada
        /// como la propiedad que se usa para fingerPrint
        /// </summary>
        [DataMember]
        public string apiKey { get; set; }
        /// <summary>
        /// Clave del API, tomada de Centralizada para consumo del servicio
        /// </summary>      
        [DataMember]
        public int idChannel { get; set; }

        /// <summary>
        /// Clave del API, tomada de Centralizada para consumo del servicio
        /// </summary>      
        [DataMember]
        public int idOperation { get; set; }

        /// <summary>
        /// Fecha Operacion
        /// </summary>
        [DataMember]
        public DateTime eventDate { get; set; }

        /// <summary>
        /// Monto
        /// </summary>
        [DataMember]
        public decimal amount { get; set; }

        /// <summary>
        /// Cuenta de origen de la operacion
        /// </summary>
        [DataMember]
        public string debitAccount { get; set; }
        /// <summary>
        /// Cuenta destino de la operacion
        /// </summary>
        [DataMember]
        public string creditAccount { get; set; }

        /// <summary>
        /// Lsitado de Datos opcionales
        /// </summary>
        [DataMember]
        public  List<EDatosOpcionalesAF> optionalParams { get; set; }

    }
}
