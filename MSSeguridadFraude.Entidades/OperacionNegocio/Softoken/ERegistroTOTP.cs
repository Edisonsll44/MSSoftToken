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
    public class ERegistroTOTP
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string phoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string passcode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string deploymentMechanism { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string  username { get; set; }
    }
}
