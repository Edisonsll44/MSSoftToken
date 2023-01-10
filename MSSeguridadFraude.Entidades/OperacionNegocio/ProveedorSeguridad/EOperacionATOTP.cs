using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio
{
    /// <summary>
    /// Datos de entrada para realizar el consumo del metodo (a) Activar TOTP
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionATOTP:EOperacionBase
    {
       
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public EActivarTOTP Activar{get;set;}

        ///
        [DataMember]
        public  ESincronizacionTOTP Sincronizacion { get; set; }
    }
}
