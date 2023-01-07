﻿using MSSeguridadFraude.AccesoDatos.AdGestor;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using System;
using System.Net;
using ERespuesta = MSSeguridadFraude.Entidades.Respuesta.ERespuesta;

namespace MSSeguridadFraude.AccesoDatos.AdOperacionServicio
{
    public class AdProcesosSofToken
    {

        protected AdProcesosSofToken()
        {

        }


        public static ERespuestaOperacionSoftToken ActivarTOTP(EOperacionATOTP operacion) {

            
            var  respuesta = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            try
            {
                //Invocacion al servicio del proveedor

                respuesta = AdGestorSoftToken.ActivarTOTP(operacion);
            }
            catch (WebException ex)
            {
                respuesta = new ERespuestaOperacionSoftToken
                {
                    Respuesta = new ERespuesta
                    {
                        ExcepcionAplicacion = true,
                        ErrorConexion = true,
                        FechaRespuesta = DateTime.Now,
                        OperacionProcesada = false,
                    }
                    

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


        public static ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion)
        {
            var respuesta = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            try
            {
                //Invocacion al servicio del proveedor

                respuesta = AdGestorSoftToken.SincronizarTiempoTOTP(operacion);
            }
            catch (WebException ex)
            {
                respuesta = new ERespuestaOperacionSoftToken
                {
                    Respuesta = new ERespuesta
                    {
                        ExcepcionAplicacion = true,
                        ErrorConexion = true,
                        FechaRespuesta = DateTime.Now,
                        OperacionProcesada = false,
                    }


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


        public static ERespuestaOperacionSoftToken DesbloquearTOTP(EOperacionesTOTP operacion)
        {

            var respuesta = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            try
            {
                //Invocacion al servicio del proveedor

                respuesta = AdGestorSoftToken.DesbloquearTOTP(operacion);
            }
            catch (WebException ex)
            {
                respuesta = new ERespuestaOperacionSoftToken
                {
                    Respuesta = new ERespuesta
                    {
                        ExcepcionAplicacion = true,
                        ErrorConexion = true,
                        FechaRespuesta = DateTime.Now,
                        OperacionProcesada = false,
                    }
                    

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

        public static ERespuestaOperacionSoftToken DesabilitarTOTP(EOperacionesTOTP operacion)        {

            var respuesta = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            try
            {
                //Invocacion al servicio del proveedor

                respuesta = AdGestorSoftToken.DesabilitarTOTP(operacion);
            }
            catch (WebException ex)
            {
                respuesta = new ERespuestaOperacionSoftToken
                {
                    Respuesta= new ERespuesta
                    {
                        ExcepcionAplicacion = true,
                        ErrorConexion = true,
                        FechaRespuesta = DateTime.Now,
                        OperacionProcesada = false,
                    }
                    

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
