using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using RestSharp;
using System;
using System.Net;
using Tcs.Provider.Settings.Base;

namespace MSSeguridadFraude.AccesoDatos.AdGestor
{
    public class AdGestorSoftToken
    {

        public AdGestorSoftToken()
        {

        }



        public static ERespuestaOperacionSoftToken ActivarTOTP(EOperacionATOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };


            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.Configuraciones.EndPointMetodoA].ToString();
            try
            {
                
                IRestResponse responseData = GestorServiciosWeb<EActivarTOTP>.SendPostAsync(operacion.Activar, recurso,true);

                if (responseData.StatusCode == HttpStatusCode.OK)
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = string.Empty;
                    respuestaST.Respuesta.OperacionProcesada = true;
                    var respuestaGenerica = CUtil.MapearRespuesta(responseData.Content, CConstantes.Caracteres.DOSPUNTOS);
                    respuestaST.RespuestaSoftToken = respuestaGenerica; 
                    return respuestaST;
                }
                else
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIOS;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_PROVEEDOR;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;
                    if (responseData.StatusCode == HttpStatusCode.RequestTimeout || responseData.StatusCode == HttpStatusCode.GatewayTimeout)
                    {
                        respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                        respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                    }

                    Exception ex = responseData.ErrorException ?? new Exception(respuestaST.Respuesta.Mensaje);
                    AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaST;
        }

      

        public static ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.Configuraciones.EndPointMetodoA].ToString();
            try
            {
                IRestResponse responseData = GestorServiciosWeb<ESincronizacionTOTP>.SendPostAsync(operacion.Sincronizacion, recurso,true);

                if (responseData.StatusCode == HttpStatusCode.OK)
                {   
                    respuestaST.Respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = string.Empty;
                    respuestaST.Respuesta.OperacionProcesada = true;
                    var respuestaGenerica = CUtil.MapearRespuesta(responseData.Content, CConstantes.Caracteres.DOSPUNTOS);
                    respuestaST.RespuestaSoftToken = respuestaGenerica;
                    return respuestaST;
                }
                else
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIOS;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_PROVEEDOR;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;
                    if (responseData.StatusCode == HttpStatusCode.RequestTimeout || responseData.StatusCode == HttpStatusCode.GatewayTimeout)
                    {
                        respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                        respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                    }

                    Exception ex = responseData.ErrorException ?? new Exception(respuestaST.Respuesta.Mensaje);
                    AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaST;
        }

        public static ERespuestaOperacionSoftToken DesbloquearTOTP(EOperacionesTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.Configuraciones.EndPointMetodoDesbloquear].ToString();
            try
            {
                IRestResponse responseData = GestorServiciosWeb<EOperacionTOTP>.SendPostAsync(operacion.Operacion, recurso);

                if (responseData.StatusCode == HttpStatusCode.OK)
                {

                    respuestaST.Respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = string.Empty;
                    respuestaST.Respuesta.OperacionProcesada = true;
                    var respuestaGenerica = CUtil.MapearRespuesta(responseData.Content, CConstantes.Caracteres.DOSPUNTOS);
                    respuestaST.RespuestaSoftToken = respuestaGenerica;
                    return respuestaST;
                }
                else
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIOS;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_PROVEEDOR;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;
                    if (responseData.StatusCode == HttpStatusCode.RequestTimeout || responseData.StatusCode == HttpStatusCode.GatewayTimeout)
                    {
                        respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                        respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                    }

                    Exception ex = responseData.ErrorException ?? new Exception(respuestaST.Respuesta.Mensaje);
                    AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaST;
        }
        public static ERespuestaOperacionSoftToken DesabilitarTOTP(EOperacionesTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.Configuraciones.EndPointMetodoDesabilitar].ToString();
            try
            {
                
                IRestResponse responseData = GestorServiciosWeb<EOperacionTOTP>.SendPostAsync(operacion.Operacion, recurso);

                if (responseData.StatusCode == HttpStatusCode.OK)
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = string.Empty;
                    respuestaST.Respuesta.OperacionProcesada = true;
                    var respuestaGenerica = CUtil.MapearRespuesta(responseData.Content, CConstantes.Caracteres.DOSPUNTOS);
                    respuestaST.RespuestaSoftToken = respuestaGenerica;
                    return respuestaST;
                }
                else
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIOS;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_PROVEEDOR;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;
                    if (responseData.StatusCode == HttpStatusCode.RequestTimeout || responseData.StatusCode == HttpStatusCode.GatewayTimeout)
                    {
                        respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                        respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                    }

                    Exception ex = responseData.ErrorException ?? new Exception(respuestaST.Respuesta.Mensaje);
                    AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaST;
        }

        public static ERespuestaOperacionSoftToken LoginTOTP(EOperacionLoginTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.Configuraciones.EndPointMetodoDesabilitar].ToString();
            try
            {
                IRestResponse responseData = GestorServiciosWeb<ELoginTOTP>.SendPostAsync(operacion.Login, recurso);

                if (responseData.StatusCode == HttpStatusCode.OK)
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = string.Empty;
                    respuestaST.Respuesta.OperacionProcesada = true;
                    var respuestaGenerica = CUtil.MapearRespuesta(responseData.Content, CConstantes.Caracteres.DOSPUNTOS);
                    respuestaST.RespuestaSoftToken = respuestaGenerica;
                    return respuestaST;
                }
                else
                {
                    respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIOS;
                    respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_PROVEEDOR;
                    respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;
                    if (responseData.StatusCode == HttpStatusCode.RequestTimeout || responseData.StatusCode == HttpStatusCode.GatewayTimeout)
                    {
                        respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                        respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                    }

                    Exception ex = responseData.ErrorException ?? new Exception(respuestaST.Respuesta.Mensaje);
                    AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, operacion.Auditoria, () => recurso, () => operacion, () => respuestaST);
                respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaST;
        }
    }
}
