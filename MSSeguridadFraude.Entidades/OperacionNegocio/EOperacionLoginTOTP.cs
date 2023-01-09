using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguridadFraude.Entidades.OperacionNegocio
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionLoginTOTP
    {
        /// <summary>
        /// Datos de auditoria
        /// </summary>
        [DataMember]
        public EAuditoria Auditoria { get; set; }

        /// <summary>
        /// Datos de Entorno
        /// </summary>
        [DataMember]
        public EEntorno Entorno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public ELoginTOTP Login { get; set; }
    
    }
}
