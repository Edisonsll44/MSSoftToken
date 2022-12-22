using MSSeguridadFraude.AccesoDatos.AdMensajes;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.Mensajes;
using System;
using System.Data;
using System.Linq;

namespace MSSeguridadFraude.Negocio.NeMensajes
{
    /// <summary>
    /// Clase de Negocio para manejo de mensajes parametrizables
    /// </summary>
    public  class NeMensajes
    {
        /// <summary>
        /// Metodo de Negocio para consulta de Informacion de Mensajes parametrizables
        /// </summary>
        /// <param name="datosMensaje">Entidad con los parametros de negocio para la consulta de mensajes</param>
        /// <param name="tipoMensaje">Tipo de Mensaje</param>
        /// <returns>(ERespuestaMensajes) entidad de respuesta de la informacion consultada</returns>
        public static ERespuestaMensaje ConsultarMensaje(EConsultaMensaje datosMensaje)
        {
            ERespuestaMensaje respuestaMensaje = new ERespuestaMensaje
            {
                Respuesta = new Entidades.Respuesta.ERespuesta()
            };

            DataSet dataResultados = AdMensajes.ConsultarMensaje(datosMensaje);

            if (dataResultados != null && dataResultados.Tables.Count > 0)
            {
                if (dataResultados.Tables[0].Rows.Count > 0)
                {
                    EMensaje mensaje = ObtenerMensaje(dataResultados.Tables[0]);
                    if (!mensaje.CodigoMensajeAplicacion.Equals(CConstantes.Excepcion.CODIGO_INCORRECTO_PRO))
                    {
                        respuestaMensaje.RespuestaMensaje = new EMensaje
                        {
                            CodigoMensajeAplicacion = mensaje.CodigoMensajeAplicacion,
                            MensajeAplicacion = mensaje.MensajeAplicacion
                        };
                    }
                    else
                    {
                        if (datosMensaje.Respuesta.OperacionProcesada)
                        {
                            respuestaMensaje.RespuestaMensaje = ObtenerMensajePorDefectoOK();
                        }
                        else
                        {
                            respuestaMensaje.RespuestaMensaje = ObtenerMensajePorDefectoError(datosMensaje.Respuesta.Mensaje);
                        }
                    }

                    respuestaMensaje.Respuesta.FechaRespuesta = DateTime.Now;
                    respuestaMensaje.Respuesta.ErrorConexion = false;
                    respuestaMensaje.Respuesta.ExcepcionAplicacion = false;
                    respuestaMensaje.Respuesta.OperacionProcesada = true;
                }
                else
                {
                    respuestaMensaje.RespuestaMensaje = ObtenerMensajePorDefectoOK();
                    respuestaMensaje.Respuesta.FechaRespuesta = DateTime.Now;
                    respuestaMensaje.Respuesta.ErrorConexion = false;
                    respuestaMensaje.Respuesta.ExcepcionAplicacion = true;
                    respuestaMensaje.Respuesta.OperacionProcesada = true;
                }
            }
            else
            {
                respuestaMensaje.RespuestaMensaje = ObtenerMensajePorDefectoError(datosMensaje.Respuesta.Mensaje);
                respuestaMensaje.Respuesta.FechaRespuesta = DateTime.Now;
                respuestaMensaje.Respuesta.ErrorConexion = false;
                respuestaMensaje.Respuesta.ExcepcionAplicacion = false;
                respuestaMensaje.Respuesta.OperacionProcesada = datosMensaje.Respuesta.OperacionProcesada;
            }

            return respuestaMensaje;
        }

        /// <summary>
        /// Busca el mensaje especifico del codigo dado
        /// </summary>
        /// <param name="tablaError">DataTable</param>
        /// <returns>EMensaje</returns>
        private static EMensaje ObtenerMensaje(DataTable tablaError)
        {
            EMensaje mensaje = tablaError.AsEnumerable().Select(row => new EMensaje
            {
                CodigoMensajeAplicacion = row.Field<string>(CCampos.TablaMensajes.CODIGO_MENSAJE.ToString()),
                CodigoMensajeSiglo = row.Field<string>(CCampos.TablaMensajes.CODIGO_MENSAJE_SIGLO.ToString()),
                MensajeAplicacion = row.Field<string>(CCampos.TablaMensajes.MENSAJE.ToString())
            }).Single();

            return mensaje ?? ObtenerMensajePorDefectoOK();
        }

        /// <summary>
        /// Obtiene el mensaje por defecto
        /// </summary>
        /// <param name="mensaje">string</param>
        /// <returns>EMensaje</returns>
        private static EMensaje ObtenerMensajePorDefectoError(string mensaje)
        {
            return new EMensaje
            {
                CodigoMensajeAplicacion = CConstantes.Server.CODIGO_ERROR_POR_DEFECTO_OPERACION.ToString(),
                MensajeAplicacion = string.IsNullOrEmpty(mensaje) ? CConstantes.Mensajes.MENSAJE_ERROR_POR_DEFECTO : mensaje
            };
        }

        /// <summary>
        /// Obtiene el mensaje por defecto 
        /// </summary>
        /// <returns>EMensaje</returns>
        private static EMensaje ObtenerMensajePorDefectoOK()
        {
            return new EMensaje
            {
                CodigoMensajeAplicacion = CConstantes.Server.CODIGO_CORRECTO_GENERAL,
                MensajeAplicacion = CConstantes.Mensajes.MENSAJE_CORRECTO
            };
        }
    }
}