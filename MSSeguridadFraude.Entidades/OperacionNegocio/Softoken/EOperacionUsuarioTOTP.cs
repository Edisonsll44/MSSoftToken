﻿using System;
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
    public class EOperacionUsuarioTOTP
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string username { get; set; }
    }
}