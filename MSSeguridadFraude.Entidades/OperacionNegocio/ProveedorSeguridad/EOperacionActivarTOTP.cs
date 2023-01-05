using MSSeguridadFraude.Entidades.Comun;
using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio
{
    /// <summary>
    /// Datos de entrada para realizar el consumo del metodo (a) Activar TOTP
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionActivarTOTP
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public EAuditoria Auditoria { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public EEntorno Entorno { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Cupon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Callback { get; set; }

    }
}
