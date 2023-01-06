using MSSeguridadFraude.Entidades.Comun;
<<<<<<<< HEAD:MSSeguridadFraude.Entidades/OperacionNegocio/ProveedorSeguridad/EOperacionActivarTOTP.cs
========
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad;
using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
>>>>>>>> master:MSSeguridadFraude.Entidades/OperacionNegocio/EOperacionATOTP.cs
using System;
using System.Runtime.Serialization;

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
