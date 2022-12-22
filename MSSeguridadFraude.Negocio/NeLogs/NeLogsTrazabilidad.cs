using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Entidades.Comun;
using System;
using System.Linq.Expressions;

namespace MSSeguridadFraude.Negocio.NeLogs
{
    /// <summary>
    /// NeLogsTrazabilidad
    /// </summary>
    public class NeLogsTrazabilidad
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected NeLogsTrazabilidad()
        {
        }

        /// <summary>
        /// Genera log de trazabilidad
        /// </summary>
        /// <param name="ubicacionMetodo">string</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <param name="parametrosMetodo">Expression</param>
        public static void GuardarLogsTrazabilidad(string ubicacionMetodo, EAuditoria auditoria, params Expression<Func<object>>[] parametrosMetodo)
        {
            if (VerificarLogTrazabilidadActivo(auditoria))
            {
                AdLogsTrazabilidad.Trazabilidad(ubicacionMetodo, auditoria, parametrosMetodo);
            }
        }

        /// <summary>
        /// Datos para la verificacion de si esta activo el log de trazabilidad
        /// </summary>
        /// <param name="auditoria">EAuditoria</param>
        /// <returns>Bandera que indica si esta activo el log de trazabilidad</returns>
        public static bool VerificarLogTrazabilidadActivo(EAuditoria auditoria)
        {
            return AdLogsTrazabilidad.VerificarLogTrazabilidadActivo(auditoria);
        }
    }
}