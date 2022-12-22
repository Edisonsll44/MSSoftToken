using MSSeguridadFraude.Entidades.Comun;
using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad
{
    /// <summary>
    /// Clase padre que encapsula las propiedades comunes
    /// en las apis con sms y mail
    /// </summary>
    [DataContract]
    [Serializable]
    public class EDatosNotificacionesVu
    {
        /// <summary>
        /// username
        /// </summary>
        [DataMember(IsRequired = true)]
        public string username { get; set; }

        /// <summary>
        /// Id de pais-negocio-canal correspondiente
        /// </summary>
        [DataMember]
        public string countryBusinessChannel { get; set; }
    }

    /// <summary>
    /// Clase padre que encapsula
    /// los dtos de Entorno y Auditoria
    /// </summary>
    [DataContract]
    [Serializable]
    public class EDatosEntornoAuditoria
    {
        /// <summary>
        /// Datos del entorno de
        /// </summary>
        public EEntorno Entorno { get; set; }

        /// <summary>
        /// Entidad de Auditoria 
        /// </summary>
        [DataMember]
        public EAuditoria Auditoria { get; set; }
    }

    /// <summary>
    /// Clase para amnejod e datos opcionales
    /// </summary>
    [DataContract]
    [Serializable]
    public class EDatosOpcionalesAF
    {

        /// <summary>
        /// 
        /// </summary>
        protected EDatosOpcionalesAF()
        {

        }
        /// <summary>
        /// Clave del Parametro a enviar
        /// </summary>
        [DataMember]
        public string name { get; set; }

        /// <summary>
        /// Valor del Parametro a enviar
        /// </summary>
        [DataMember]
        public string value { get; set; }

    }
}
