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
    public class EOperacionLoginTOTP:EOperacionBase
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public ELoginTOTP Login { get; set; }
    
    }
}
