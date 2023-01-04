using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.AdGestor;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.AccesoDatos.MSIdentificadorUnico;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad.AnalisisFraude;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ERespuesta = MSSeguridadFraude.Entidades.Respuesta.ERespuesta;

namespace MSSeguridadFraude.AccesoDatos.AdOperacionServicio
{
    public class AdProcesosSofToken
    {

        protected AdProcesosSofToken()
        {

        }


        public static ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion) {

            var respuesta = new ERespuesta();
            try
            {
                //Invocacion al servicio del proveedor

                respuesta = AdGestorSoftToken.ActivarTOTP(operacion);
            }
            catch (WebException ex)
            {
                respuesta = new ERespuesta
                {
                    ExcepcionAplicacion = true,
                    ErrorConexion = true,
                    FechaRespuesta = DateTime.Now,
                    OperacionProcesada = false,

                };

                if (ex.Status == WebExceptionStatus.Timeout)
                {
                    respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_TIME_OUT_SERVICIO;
                    respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_SERVICIO;
                }
                else
                {
                    respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIO;
                    respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_SERVICIO;
                }

                AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);
            }
            catch (Exception ex)
            {
                AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);

                respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuesta.FechaRespuesta = DateTime.Now;
                respuesta.ExcepcionAplicacion = true;

            }

            return respuesta;

        }

        

    }
}
