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



        public static ERespuestaOperacionSoftToken ProcesarActivarUsuario(EOperacionATOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };


            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointMetodoA].ToString();
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

        public static ERespuestaOperacionSoftToken ProcesarSincronizarTiempoServidor(EOperacionATOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointMetodoA].ToString();
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

        public static ERespuestaOperacionSoftToken ProcesarDesbloquearUsuario(EOperacionTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointMetodoDesbloquear].ToString();
            try
            {
                IRestResponse responseData = GestorServiciosWeb<EOperacionUsuarioTOTP>.SendPostAsync(operacion.Operacion, recurso);

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
        public static ERespuestaOperacionSoftToken ProcesarInhabilitarUsuario(EOperacionTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointMetodoDesabilitar].ToString();
            try
            {
                
                IRestResponse responseData = GestorServiciosWeb<EOperacionUsuarioTOTP>.SendPostAsync(operacion.Operacion, recurso);

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

        public static ERespuestaOperacionSoftToken ProcesarLoginTotp(EOperacionLoginTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointLogin].ToString();
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

        /// <summary>
        /// Procesar Bloqueo Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarBloqueoUsuario(EOperacionTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointBloqueoUsuario].ToString();
            try
            {
                var request = operacion.Operacion;
                IRestResponse responseData = GestorServiciosWeb<EOperacionUsuarioTOTP>.SendPostAsync(request, recurso);

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
        /// <summary>
        /// Procesar Eliminar Totp
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarEliminarUsuario(EOperacionTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointEliminar].ToString();
            try
            {
                var request = operacion.Operacion;
                IRestResponse responseData = GestorServiciosWeb<EOperacionUsuarioTOTP>.SendPostAsync(request, recurso);

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
        /// <summary>
        /// Procesar Estado Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarEstadoUsuario(EOperacionTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointEstadoUsuario].ToString();
            try
            {
                var request = operacion.Operacion;
                IRestResponse responseData = GestorServiciosWeb<EOperacionUsuarioTOTP>.SendPostAsync(request, recurso);

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
        /// <summary>
        /// Procesar Registrar Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarRegistrarUsuario(EOperacionRegistrarTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointRegistrar].ToString();
            try
            {
                var request = operacion.Operacion;
                IRestResponse responseData = GestorServiciosWeb<ERegistroTOTP>.SendPostAsync(request, recurso);

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

        /// <summary>
        /// Procesar Login Totp
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>

        /// <summary>
        /// Procesar Habilitar Totp
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarHabilitarUsuario(EOperacionTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group(CConstantes.Configuraciones.ConfiguracionesServicioWeb)[CConstantes.EndPoints.EndPointHabilitarUsuario].ToString();
            try
            {
                var request = operacion.Operacion;
                IRestResponse responseData = GestorServiciosWeb<EOperacionUsuarioTOTP>.SendPostAsync(request, recurso);

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
