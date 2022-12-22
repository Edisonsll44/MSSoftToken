using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Serializacion;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.Logs;
using MSSeguridadFraude.Entidades.Respuesta;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MSSeguridadFraude.AccesoDatos.AdLogs
{
    /// <summary>
    /// AdLogsTrazabilidad
    /// </summary>
    public class AdLogsTrazabilidad : AdBase
    {

        /// <summary>
        /// datosParametros
        /// </summary>
        private static StringDictionary datosParametros;

        /// <summary>
        /// Permite Almacenar los Logs de Trazabilidad de la Operacion
        /// </summary>
        /// <param name="logTrazabilidad">Datos del log de trazabilidad</param>
        /// <param name="auditoria">Datos de auditoria</param>
        /// <returns>(ERespuesta)Respuesta del proceso de guardar logs</returns>
        public static ERespuesta GuardarLogTrazabilidad(ELogTrazabilidad logTrazabilidad, EAuditoria auditoria)
        {
            ERespuesta respuesta = new ERespuesta();

            try
            {
                object[] parametros = new object[]
                {
                    logTrazabilidad.IdUnicoTransaccionSiglo,
                    logTrazabilidad.GuidServicio,
                    logTrazabilidad.GuidAplicacionCliente,
                    logTrazabilidad.Identificacion,
                    logTrazabilidad.CodigoCanal,
                    logTrazabilidad.CodigoTransaccion,
                    logTrazabilidad.CodigoMedioInvocacion,
                    logTrazabilidad.TipoEvento,
                    logTrazabilidad.Metodo,
                    logTrazabilidad.ServicioTarea,
                    logTrazabilidad.FechaHoraInicio,
                    logTrazabilidad.DatoRespuesta,
                    logTrazabilidad.FechaHoraFin,
                    logTrazabilidad.DatoIngreso,
                    logTrazabilidad.IpCliente,
                    logTrazabilidad.IpServidor
                };

                SqlCommand comando = new SqlCommand
                {
                    CommandText = CConstantes.Sps.PRO_LOG_TRAZABILIDAD
                };

                ExecuteNonQuery(
                    CadenaConexion[CConstantes.Base.BASE_DATOS_LOGS],
                    parametros,
                    comando);

                respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO.ToString();
                respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                respuesta.FechaRespuesta = DateTime.Now;
                respuesta.OperacionProcesada = true;
            }
            catch (Exception ex)
            {
                AdLogsExcepcion.GuardarLogExcepcion(ex, auditoria, () => logTrazabilidad, () => respuesta);

                respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuesta.FechaRespuesta = DateTime.Now;
                respuesta.ExcepcionAplicacion = true;
            }

            return respuesta;
        }

        /// <summary>
        /// Genera log de trazabilidad
        /// </summary>
        /// <param name="ubicacionMetodo">string</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <param name="parametrosMetodo">Expression</param>
        public static void Trazabilidad(string ubicacionMetodo, EAuditoria auditoria, params Expression<Func<object>>[] parametrosMetodo)
        {
            int mismaCapa = 1, diferenteCapa;

            #if (DEBUG)
                diferenteCapa = 2;
            #else
                diferenteCapa = 1;
            #endif

            int numeroParametros = 0;
            StackTrace pilaCompleta = new StackTrace();
            List<string> pila = pilaCompleta.ToString().Split(Environment.NewLine[1]).ToList();
            var metodoInvocador = pilaCompleta.GetFrame(mismaCapa).GetMethod();

            string nombreServicio = CUtil.ObtenerNombreAplicacion();

            if (pilaCompleta.GetFrame(0).GetMethod().Module.ToString() != pilaCompleta.GetFrame(1).GetMethod().Module.ToString())
            {
                #if (DEBUG)
                    pila.RemoveAt(0);
                #endif
                metodoInvocador = pilaCompleta.GetFrame(diferenteCapa).GetMethod();
            }

            pila.RemoveAt(0);
            EParametros[] parametros = new EParametros[parametrosMetodo.Count()];
            foreach (var tipoExpresion in parametrosMetodo)
            {
                parametros[numeroParametros] = CSerializacion.CargarParametros(tipoExpresion);
                numeroParametros++;
            }

            string datos = numeroParametros == 0 ? string.Empty : CSerializacion.SerializarXML(parametros, Encoding.UTF8, false).Replace(CConstantes.Trazas.MAYORQUESERIALIZADO, CConstantes.Trazas.CARACTERMAYORQUE).Replace(CConstantes.Trazas.MENORQUESERIALIZADO, CConstantes.Trazas.CARACTERMENORQUE);

            ELogTrazabilidad logTrazabilidad = new ELogTrazabilidad
            {
                CodigoCanal = auditoria.CodigoCanal,
                CodigoMedioInvocacion = auditoria.CodigoMedioInvocacion,
                CodigoTransaccion = auditoria.CodigoTransaccion,
                DatoIngreso = ubicacionMetodo == CConstantes.Textos.TIPO_EVENTO_INICIO ? datos : string.Empty,
                DatoRespuesta = ubicacionMetodo == CConstantes.Textos.TIPO_EVENTO_FIN ? datos : string.Empty,
                FechaActual = auditoria.Fecha,
                FechaHoraInicio = DateTime.Now,
                FechaHoraFin = DateTime.Now,

                GuidAplicacionCliente = string.IsNullOrEmpty(auditoria.IdentificadorGUID) ? string.Empty : auditoria.IdentificadorGUID,
                GuidServicio = auditoria.IdentificadorServicioGUID,

                Identificacion = string.IsNullOrEmpty(auditoria.Identificacion) ? string.Empty : auditoria.Identificacion.Trim(),
                IdUnicoTransaccionSiglo = string.IsNullOrEmpty(auditoria.IdentificadorUnicoOperacional) ? string.Empty : auditoria.IdentificadorUnicoOperacional,
                IpCliente = auditoria.IpCliente,
                IpServidor = CUtil.ObtenerIPServidor(),
                Metodo = metodoInvocador.Name,
                ServicioTarea = nombreServicio + " - " + metodoInvocador.DeclaringType.FullName,
                TipoEvento = ubicacionMetodo
            };

            GuardarLogTrazabilidad(logTrazabilidad, auditoria);
        }

        /// <summary>
        /// Metodo que verifica si el LOG de Trazabilidad esta Activo para almacenar la informacion
        /// </summary>
        /// <param name="auditoria">Entidad de auditoria</param>
        /// <returns>bool si esta activo o no el log paar el ingreso de informacion</returns>
        public static bool VerificarLogTrazabilidadActivo(EAuditoria auditoria)
        {
            bool respuesta = false;

            if (datosParametros != null)
            {
                string valorParametro = datosParametros[CConstantes.Server.PARAMETRO_CONSULTA_LOG_TRAZABILIDAD];

                if (valorParametro.Equals("1"))
                {
                    respuesta = true;
                }
                else
                {
                    respuesta = false;
                }

                return respuesta;
            }

            EParametroLogs parametro = new EParametroLogs
            {
                CodigoCanal = auditoria.CodigoCanal,
                CodigoMedioInvocacion = auditoria.CodigoMedioInvocacion,
                CodigoTransaccion = auditoria.CodigoTransaccion,
                CodigoCabeceraTipoLog = CConstantes.Server.CODIGO_TIPO_LOG_TRAZABILIDAD
            };

            parametro = AdParametrosLogs.ConsultaParametrosLogs(parametro, auditoria);

            if (parametro == null)
            {
                return false;
            }

            if (parametro.IdParametro == 0)
            {
                return false;
            }

            datosParametros = new StringDictionary();

            if (parametro.Activo)
            {
                respuesta = true;
                datosParametros[CConstantes.Server.PARAMETRO_CONSULTA_LOG_TRAZABILIDAD] = "1";
            }
            else
            {
                datosParametros[CConstantes.Server.PARAMETRO_CONSULTA_LOG_TRAZABILIDAD] = "0";
            }

            return respuesta;
        }
    }
}