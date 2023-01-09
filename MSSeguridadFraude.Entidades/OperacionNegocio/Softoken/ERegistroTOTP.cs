using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio.Softoken
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public  class ERegistroTOTP
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PhoneNumber { get; set; }

    }
}
