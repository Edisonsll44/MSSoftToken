using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad;
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
    /// Datos de entrada para realizar el consumo del metodo (a) Activar TOTP
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionATOTP
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
        public EActivarTOTP ActivarTOTP{get;set;}

        ///
        [DataMember]
        public  ESincronizacionTOTP Sincronizacion { get; set; }
    }
}
