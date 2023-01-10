using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguridadFraude.Entidades.OperacionNegocio.Softoken
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public  class EActivarTOTP
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string cupon { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string callback { get; set; }

    }
}
