using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.Logs;
using MSSeguridadFraude.Entidades.Respuesta;
using System;
using System.Data.SqlClient;

namespace MSSeguridadFraude.AccesoDatos.AdLogs
{
    /// <summary>
    /// AdJournalTransaccional
    /// </summary>
    public class AdJournalTransaccional : AdBase
    {
        /// <summary>
        /// Graba en la tabla JournalTransaccional
        /// </summary>
        /// <param name="journal">EJournalTransaccional</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <returns>ERespuesta</returns>
        public static ERespuesta GrabarJournalTransaccional(EJournalTransaccional journal, EAuditoria auditoria)
        {
            ERespuesta respuesta = new ERespuesta();
            
            object[] parametros = new object[]
            {
                journal.CodigoCanal,
                journal.CodigoTransaccion,
                journal.CodigoMedioInvocacion,
                journal.IdTransaccionUnicoSiglo,
                journal.NumeroDocumentoSiglo,
                journal.TipoIdentificacion,
                journal.IdentificacionCliente,
                journal.TipoProductoOrigen,
                journal.NumeroProductoOrigen,
                journal.AliasProductoOrigen,
                journal.TipoProductoDestino,
                journal.NumeroProductoDestino,
                journal.AliasProductoDestino,
                journal.TipoIdentificacionBeneficiario,
                journal.IdentificacionBeneficiario,
                journal.IdEmpresa,
                journal.IdProveedor,
                journal.NumeroDocumentoProveedor,
                journal.NumeroContrato,
                journal.NumeroCuota,
                journal.ReferenciaDescripcion,
                journal.CodigoConcepto,
                journal.Concepto,
                journal.MontoEfectivo,
                journal.Comision,
                journal.MontoCheques,
                journal.NumeroLibreta,
                journal.CodBancoOrigen,
                journal.BancoOrigen,
                journal.CodBancoDestino,
                journal.BancoDestino,
                journal.IdTransaccionalCliente,
                journal.IpOrigen,
                journal.IpServidor,
                journal.Usuario,
                journal.FechaHoraInicioCore,
                journal.FechaHoraFinCore,
                journal.FechaHoraInicioProveedor,
                journal.FechaHoraFinProveedor,
                journal.FechaOperacion,
                journal.Guid,
                journal.HashImei,
                journal.TramaIngreso,
                journal.TramaSalida,
                journal.EstadoOperacion,
                journal.EstadoFlujoTransaccion,
                journal.CodigoMensajeSiglo,
                journal.MensajeSiglo,
                journal.CodigoMensajeProveedor,
                journal.MensajeProveedor,
                journal.IdUnicoTransaccionReverso,
                journal.CodigoTransaccionReverso,
                journal.CodigoAgencia,
                journal.CodigoCentro,
                journal.Accion,
                journal.ValidaFechas
            };
            try
            {                
                ExecuteDataset(CadenaConexion[CConstantes.Base.BASE_DATOS_LOGS], CConstantes.Sps.PRO_LOG_JOURNAL_TRANSACCIONAL, parametros);

                respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO.ToString();
                respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                respuesta.FechaRespuesta = DateTime.Now;
                respuesta.OperacionProcesada = true;
            }
            catch (SqlException sqlEx)
            {
                AdLogsExcepcion.GuardarLogExcepcion(sqlEx, auditoria, () => journal, () => respuesta);
             
                respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuesta.FechaRespuesta = DateTime.Now;
                respuesta.ExcepcionAplicacion = true;
            }

            return respuesta;
        }
    }
}
