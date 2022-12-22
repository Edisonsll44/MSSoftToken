using MSSeguridadFraude.Entidades.Comun;
using System;

namespace MSSeguridadFraude.Entidades.ReglasOperacion
{
    /// <summary>
    /// Entidad que permite consultar una regla de negocio
    /// </summary>
    [Serializable]
    public class EReglaOperacion
    {
        /// <summary>
        /// Datos del entorno de siglo XXI
        /// </summary>
        public EEntorno Entorno { get; set; }

        /// <summary>
        /// Datos de auditoria
        /// </summary>
        public EAuditoria Auditoria { get; set; }

        /// <summary>
        /// Monto a validar
        /// </summary>
        public decimal Monto { get; set; }
    }
}
