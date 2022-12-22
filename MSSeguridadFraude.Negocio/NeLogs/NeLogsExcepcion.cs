using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Entidades.Comun;
using System;
using System.Linq.Expressions;

namespace MSSeguridadFraude.Negocio.NeLogs
{
    /// <summary>
    /// NeLogsExcepcion
    /// </summary>
    public class NeLogsExcepcion
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected NeLogsExcepcion()
        {
        }

        /// <summary>
        /// Genera log de excepciones
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <param name="parametrosMetodo">Expression</param>
        /// () >= Entidad Datos Entrada
        /// () >= Entidad Datos Salida/Respuesta
        public static void GuardarLogExcepcion(Exception ex, EAuditoria auditoria, params Expression<Func<object>>[] parametrosMetodo)
        {
            AdLogsExcepcion.GuardarLogExcepcion(ex, auditoria, parametrosMetodo);
        }
    }
}
