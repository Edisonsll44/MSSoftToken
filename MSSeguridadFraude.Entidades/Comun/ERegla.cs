using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguridadFraude.Entidades.Comun



{
   
    /// <summary>
    /// Clase de Reglas
    /// </summary>
    [Serializable]
[DataContract(Name = "Regla")]
public class ERegla
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = true, Order = 0)]
        public string NombreRegla { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = true, Order = 1)]
        public bool Activo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = true, Order = 2)]
        public string CodigoError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = true, Order = 3)]
        public string MensajeError { get; set; }
    }
}
