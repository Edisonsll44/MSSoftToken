using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.Comun
{
    /// <summary>
    /// Entidad de Auditoria de transaccion
    /// </summary>
    [Serializable]
    [DataContract]
    public class EAuditoria : ICloneable
    {
        /// <summary>
        /// Usuario que ejecuto la Operacion
        /// </summary>
        [DataMember]
        public string Usuario { get; set; }

        /// <summary>
        /// fecha en la que se realizo la Operacion
        /// </summary>
        [DataMember(IsRequired = true)]
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Ip de dodne se efectuo la operacion
        /// </summary>
        [DataMember(IsRequired = true)]
        public string IpCliente { get; set; }

        /// <summary>
        /// Hash Mobil si se envia por el proveedor
        /// </summary>
        [DataMember]
        public string HashMobil { get; set; }

        /// <summary>
        /// Celualr de la Operacion
        /// </summary>
        [DataMember]
        public string Celular { get; set; }
        
        /// <summary>
        /// Identificacion del cliente
        /// </summary>
        [DataMember]        
        public string Identificacion { get; set; }

        /// <summary>
        /// Codigo del Canal de invocación
        /// </summary>
        [DataMember(IsRequired = true)]
        public string CodigoCanal { get; set; }

        /// <summary>
        /// Codigo de la Transaccion a realizar
        /// </summary>
        [DataMember(IsRequired = true)]
        public string CodigoTransaccion { get; set; }

        /// <summary>
        /// Codigo del Medio de Invocacion 
        /// </summary>
        [DataMember(IsRequired = true)]
        public string CodigoMedioInvocacion { get; set; }

        /// <summary>
        /// Identificador unico de transacciones generado por el Core
        /// </summary>
        [DataMember]
        public string IdentificadorUnicoOperacional { get; set; }

        /// <summary>
        /// Identificador unico de la aplicacion
        /// </summary>
        [DataMember(IsRequired = true)]
        public string IdentificadorGUID { get; set; }

        /// <summary>
        /// Identificador unico del servicio
        /// </summary>
        [DataMember]
        public string IdentificadorServicioGUID { get; set; }

        /// <summary>
        /// Identificador de transacción del cliente
        /// </summary>
        [DataMember]
        public string IdAplicacionCliente { get; set; }

        /// <summary>
        /// Codido de la agencia
        /// </summary>
        [DataMember]
        public string CodigoAgencia { get; set; }

        /// <summary>
        /// Codigo del centro 
        /// </summary>
        [DataMember]
        public string CodigoCentro { get; set; }

        /// <summary>
        /// Tipo de transacción que se esta realizando: F: Financiera; C: No Financiera
        /// </summary>
        public string TipoTransaccion { get; set; }

        /// <summary>
        /// Metodo Permite clonar la entidad
        /// </summary>
        /// <returns>object</returns>
        public object Clone()
        {
            EAuditoria objetoClonado = (EAuditoria)this.MemberwiseClone();
            return objetoClonado;
        }
    }
}
