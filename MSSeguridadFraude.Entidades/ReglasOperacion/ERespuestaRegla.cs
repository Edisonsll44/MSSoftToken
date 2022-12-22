using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.Respuesta;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.ReglasOperacion
{
    /// <summary>
    /// Permite consultar las reglas de negocio
    /// </summary>
    [Serializable]
    public class ERespuestaRegla
    {
        /// <summary>
        /// Contiene el codigo de respuesta y el mensaje correspondiente
        /// </summary>
        public ERespuesta Respuesta { get; set; }

        /// <summary>
        /// Indica si la operacion se encuentra permitida
        /// </summary>
        public bool Permitido { get; set; }

        /// <summary>
        /// Indica si la cuenta es escriptada o no
        /// </summary>
        public bool Encriptado { get; set; }

        //ECUMBAL 07/09/2021 MEJORAS
        /// <summary>
        /// Clave para guardar la informacion en cache
        /// </summary>
        public string Clave { get; set; }
        //FIN ECUMBAL 07/09/2021 MEJORAS

        /// <summary>
        /// 
        /// </summary>
        [DataMember(IsRequired = true, Order = 3)]
        public List<ERegla> ReglasValidadas { get; set; }
    }
}
