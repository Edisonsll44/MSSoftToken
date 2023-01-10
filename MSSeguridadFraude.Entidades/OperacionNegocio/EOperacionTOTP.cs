using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad;
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
<<<<<<<< HEAD:MSSeguridadFraude.Entidades/OperacionNegocio/EOperacionActivarTOTP.cs
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
========
    public class EOperacionTOTP:EOperacionBase
    {
       

>>>>>>>> origin/master-soft-token:MSSeguridadFraude.Entidades/OperacionNegocio/EOperacionTOTP.cs
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
<<<<<<<< HEAD:MSSeguridadFraude.Entidades/OperacionNegocio/EOperacionActivarTOTP.cs
        public string Cupon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Callback { get; set; }

========
        public EOperacionUsuarioTOTP Operacion { get; set; }
>>>>>>>> origin/master-soft-token:MSSeguridadFraude.Entidades/OperacionNegocio/EOperacionTOTP.cs
    }
}
