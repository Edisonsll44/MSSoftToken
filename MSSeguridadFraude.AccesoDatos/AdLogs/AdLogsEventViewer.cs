using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Utilitarios;
using System;
using System.Diagnostics;

namespace MSSeguridadFraude.AccesoDatos.AdLogs
{
    /// <summary>
    /// AdLogsEventViewer
    /// </summary>
    public  class AdLogsEventViewer
    {
        /// <summary>
        /// Guarda log en event viewer
        /// </summary>
        /// <param name="mensaje">string</param>
        public static void GuardarLogEventViewer(string mensaje)
        {
            mensaje = CUtil.ObtenerNombreAplicacion() + Environment.NewLine + mensaje;
            string nombreAplicacion = CConstantes.Textos.EVENT_VIEWER;

            EventLog evento = new EventLog();
            if (!EventLog.SourceExists(nombreAplicacion))
            {
                EventLog.CreateEventSource(nombreAplicacion, nombreAplicacion);
            }

            evento.Log = nombreAplicacion;
            evento.Source = nombreAplicacion;
            evento.WriteEntry(mensaje, EventLogEntryType.Error);
            evento.Dispose();
        }
    }
}