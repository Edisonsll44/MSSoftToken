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
    public class ESincronizacionTOTP
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string timesyncauto { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string timesyncmanual { get; set; }

    }
}