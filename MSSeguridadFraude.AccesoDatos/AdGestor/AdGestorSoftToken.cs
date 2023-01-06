using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tcs.Provider.Settings.Base;

namespace MSSeguridadFraude.AccesoDatos.AdGestor
{
    public class AdGestorSoftToken
    {

        public AdGestorSoftToken()
        {

        }



        public static ERespuestaOperacionSoftToken ActivarTOTP(EOperacionActivarTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };


            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointA"].ToString();
            try
            {
                var request = operacion.ActivarTOTP;
                IRestResponse responseData = GestorServiciosWeb<EActivarTOTP>.SendPostAsync(request, recurso);

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

      

        public static ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionActivarTOTP operacion)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointA"].ToString();
            try
            {
                var request = operacion.ActivarTOTP;
                IRestResponse responseData = GestorServiciosWeb<EActivarTOTP>.SendPostAsync(request, recurso);

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
            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointDesbloquear"].ToString();
            try
            {
                var request = operacion.Operacion;
                IRestResponse responseData = GestorServiciosWeb<EOperacionTOTP>.SendPostAsync(request, recurso);

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
            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointDesabilitar"].ToString();
            try
            {
                var request = operacion.Operacion;
                IRestResponse responseData = GestorServiciosWeb<EOperacionTOTP>.SendPostAsync(request, recurso);

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
