using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad.AnalisisFraude
{
    /// <summary>
    /// Entidad general de entrada del MSSeguridadFraude
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionRegistroAF: EDatosEntornoAuditoria
    {
        /// <summary>
        /// OJO Variables o Entidades de entrada del Servicio
        /// </summary>
        [DataMember]
        public EOperacionAF OperacionAnalisisAF { get; set; }
    }
}
