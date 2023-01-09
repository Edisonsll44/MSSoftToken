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
    /// Datos para procesar operaciones (Bloqueo,Desbloqueo,Habilitación, Deshabilitación,Eliminación) con el proveedor VU
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionTOTP:EOperacionBase
    {
       

        /// <summary>
        /// Usuario registrado en el proveedor VU => Softoken TOTP
        /// </summary>
        [DataMember]
        public EOperacionUsuarioTOTP Operacion { get; set; }
    }
}
