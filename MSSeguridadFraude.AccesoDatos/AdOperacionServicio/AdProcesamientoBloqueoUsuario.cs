using MSSeguridadFraude.AccesoDatos.AdGestor;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using System;
using System.Net;

namespace MSSeguridadFraude.AccesoDatos.AdOperacionServicio
{
    public class AdProcesamientoBloqueoUsuario
    {

        protected AdProcesamientoBloqueoUsuario()
        {

        }

        /// <summary>
        /// Metodo que valida si la operacion esta permitida para el canal, medio de invocacion y codigo de transaccion el analisis de fraude
        /// </summary>
        /// <param name="reglaOperacion">EReglaOperacion</param>
        /// <returns>ERespuestaRegla</returns>
        public static ERespuestaOperacionSoftToken AnalizarOperacionFraude(EOperacionesTOTP operacion)
        {
			ERespuestaOperacionSoftToken respuesta = new ERespuestaOperacionSoftToken
			{
                Respuesta = new ERespuesta(),
                RespuestaSoftToken = new ERespuestaST()
            };

            try
            {
                //Invocacion al servicio del proveedor
                respuesta = AdGestorBloqueoUsuario.InvocarServicioRest(operacion);
            }
            catch (WebException ex)
            {
                respuesta.Respuesta = new ERespuesta
                {
                    ExcepcionAplicacion = true,
                    ErrorConexion = true,
                    FechaRespuesta = DateTime.Now,
                    OperacionProcesada = false,

                };

                if (ex.Status == WebExceptionStatus.Timeout)
                {
                    respuesta.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_TIME_OUT_SERVICIO;
                    respuesta.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_SERVICIO;
                }
                else
                {
                    respuesta.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIO;
                    respuesta.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_SERVICIO;
                }

                AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);
            }
            catch (Exception ex)
            {
                AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);

                respuesta.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuesta.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuesta.Respuesta.FechaRespuesta = DateTime.Now;
                respuesta.Respuesta.ExcepcionAplicacion = true;

            }

            return respuesta;
        }


    }
}
