using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Serializacion;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.Logs;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MSSeguridadFraude.AccesoDatos.AdLogs
{
    /// <summary>
    /// Clase para manejo de los Logs de exccepcion
    /// </summary>
    public class AdLogsExcepcion : AdBase
    {
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
            int mismaCapa = 1, diferenteCapa;

            #if (DEBUG)
                diferenteCapa = 2;
            #else
                diferenteCapa = 1;
            #endif

            ELogsExcepcion logExcepcion = new ELogsExcepcion();
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

            string datosEntrada = numeroParametros <= 0 ? string.Empty : CSerializacion.SerializarXML(parametros[0], Encoding.UTF8, false).Replace(CConstantes.Trazas.MAYORQUESERIALIZADO, CConstantes.Trazas.CARACTERMAYORQUE).Replace(CConstantes.Trazas.MENORQUESERIALIZADO, CConstantes.Trazas.CARACTERMENORQUE);
            string datosSalida = numeroParametros <= 1 ? string.Empty : CSerializacion.SerializarXML(parametros[1], Encoding.UTF8, false).Replace(CConstantes.Trazas.MAYORQUESERIALIZADO, CConstantes.Trazas.CARACTERMAYORQUE).Replace(CConstantes.Trazas.MENORQUESERIALIZADO, CConstantes.Trazas.CARACTERMENORQUE);

            logExcepcion.Auditoria = new EAuditoria
            {
                IdentificadorUnicoOperacional = auditoria.IdentificadorUnicoOperacional,
                IdentificadorServicioGUID = auditoria.IdentificadorServicioGUID,
                IdentificadorGUID = auditoria.IdentificadorGUID,
                Identificacion = auditoria.Identificacion,
                IpCliente = auditoria.IpCliente,
                CodigoCanal = auditoria.CodigoCanal,
                CodigoTransaccion = auditoria.CodigoTransaccion,
                CodigoMedioInvocacion = auditoria.CodigoMedioInvocacion
            };

            logExcepcion.Mensaje = ex.Message;
            logExcepcion.Metodo = nombreServicio + " - " + metodoInvocador.DeclaringType.FullName + "." + metodoInvocador.Name;
            logExcepcion.PiladeError = string.Join(Environment.NewLine[1].ToString(), pila);
            logExcepcion.DatosIngreso = datosEntrada;
            logExcepcion.Excepcion = ex.ToString();
            logExcepcion.DatosSalida = datosSalida;

            Excepcion(logExcepcion);
        }

        /// <summary>
        /// Metodo que permite guardar en la base de datos las excepciones producidas en el servicio
        /// </summary>
        /// <param name="logExcepcion">ELogsExcepcion</param>
        private static void Excepcion(ELogsExcepcion logExcepcion)
        {
            object[] parametros = new object[] 
            {
                logExcepcion.Auditoria.IdentificadorUnicoOperacional,
                logExcepcion.Auditoria.IdentificadorServicioGUID,
                logExcepcion.Auditoria.IdentificadorGUID,
                logExcepcion.Auditoria.Identificacion,
                logExcepcion.Auditoria.CodigoCanal,
                logExcepcion.Auditoria.CodigoTransaccion,
                logExcepcion.Auditoria.CodigoMedioInvocacion,
                logExcepcion.Mensaje,
                logExcepcion.Metodo,
                logExcepcion.PiladeError,
                logExcepcion.DatosIngreso,
                logExcepcion.Auditoria.IpCliente,
                CUtil.ObtenerIPServidor(),
                logExcepcion.Excepcion,
                logExcepcion.DatosSalida
            };

            try
            {
                SqlCommand comando = new SqlCommand
                {
                    CommandText = CConstantes.Sps.PRO_LOG_EXCEPCION
                };

                ExecuteNonQuery(
                    CadenaConexion[CConstantes.Base.BASE_DATOS_LOGS],
                    parametros,
                    comando);
            }
            catch (Exception ex)
            {
                AdLogsEventViewer.GuardarLogEventViewer(
                    CConstantes.Mensajes.ERROR_LOG_EXCEPCION
                    + Environment.NewLine + string.Join(Environment.NewLine, parametros)
                    + Environment.NewLine + ex.Message);
            }
        }
    }
}
