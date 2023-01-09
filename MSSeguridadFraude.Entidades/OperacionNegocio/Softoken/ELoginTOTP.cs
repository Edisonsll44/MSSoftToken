using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio.Softoken
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    [Serializable]
    public  class ELoginTOTP: EOperacionTOTP
	{
		/// <summary>
		/// Otp
		/// </summary>
		[DataMember]
        public string Otp { get; set; }

    }
}
