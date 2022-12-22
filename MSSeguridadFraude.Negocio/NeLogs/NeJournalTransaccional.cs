using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.Logs;
using MSSeguridadFraude.Entidades.Respuesta;

namespace MSSeguridadFraude.Negocio.NeLogs
{
    /// <summary>
    /// Capa de negocio que maneja el journal transaccional
    /// </summary>
    public  class NeJournalTransaccional
    {
        /// <summary>
        /// GrabarJournalTransaccional
        /// </summary>
        /// <param name="journalTransaccional">EJournalTransaccional</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <returns>ERespuesta</returns>
        public static ERespuesta GrabarJournalTransaccional(EJournalTransaccional journalTransaccional, EAuditoria auditoria)
        {
            return AdJournalTransaccional.GrabarJournalTransaccional(journalTransaccional, auditoria);
        }
    }
}
