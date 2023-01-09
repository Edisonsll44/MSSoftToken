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
		/// <summary>
		/// Activar TOTP
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
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


            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointA"].ToString();
            try
            {
                var request = operacion.ActivarTOTP;
                IRestResponse responseData = GestorServiciosWeb<EActivarTOTP>.SendPostAsync(request, recurso,true);

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
		/// Sincronizar Tiempo TOTP
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
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
            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointA"].ToString();
            try
            {
                var request = operacion.Sincronizacion;
                IRestResponse responseData = GestorServiciosWeb<ESincronizacionTOTP>.SendPostAsync(request, recurso,true);

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
		/// Desbloquear TOTP
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
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
		/// <summary>
		/// Desabilitar TOTP
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
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
		/// <summary>
		/// Procesar Bloqueo Usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		internal static ERespuestaOperacionSoftToken ProcesarBloqueoUsuario(EOperacionesTOTP operacion)
		{
			var respuestaST = new ERespuestaOperacionSoftToken()
			{
				Respuesta = new ERespuesta()
				{
					TipoMensaje = (int)CCampos.TipoMensaje.APP
				},
				RespuestaSoftToken = new ERespuestaST()
			};
			var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointBloqueoUsuario"].ToString();
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
		/// <summary>
		/// Procesar Eliminar Totp
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		internal static ERespuestaOperacionSoftToken ProcesarEliminarTotp(EOperacionesTOTP operacion)
		{
			var respuestaST = new ERespuestaOperacionSoftToken()
			{
				Respuesta = new ERespuesta()
				{
					TipoMensaje = (int)CCampos.TipoMensaje.APP
				},
				RespuestaSoftToken = new ERespuestaST()
			};
			var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointEliminar"].ToString();
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
		/// <summary>
		/// Procesar Estado Usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		internal static ERespuestaOperacionSoftToken ProcesarEstadoUsuario(EOperacionesTOTP operacion)
		{
			var respuestaST = new ERespuestaOperacionSoftToken()
			{
				Respuesta = new ERespuesta()
				{
					TipoMensaje = (int)CCampos.TipoMensaje.APP
				},
				RespuestaSoftToken = new ERespuestaST()
			};
			var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointEstadoUsuario"].ToString();
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
		/// <summary>
		/// Procesar Registrar Usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		internal static ERespuestaOperacionSoftToken ProcesarRegistrarUsuario(EOperacionesRegistrarTOTP operacion)
		{
			var respuestaST = new ERespuestaOperacionSoftToken()
			{
				Respuesta = new ERespuesta()
				{
					TipoMensaje = (int)CCampos.TipoMensaje.APP
				},
				RespuestaSoftToken = new ERespuestaST()
			};
			var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointRegistrar"].ToString();
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
		internal static ERespuestaOperacionSoftToken ProcesarLoginTotp(EOperacionesLoginTOTP operacion)
		{
			var respuestaST = new ERespuestaOperacionSoftToken()
			{
				Respuesta = new ERespuesta()
				{
					TipoMensaje = (int)CCampos.TipoMensaje.APP
				},
				RespuestaSoftToken = new ERespuestaST()
			};
			var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointLogin"].ToString();
			try
			{
				var request = operacion.Operacion;
				IRestResponse responseData = GestorServiciosWeb<ELoginTOTP>.SendPostAsync(request, recurso);

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
		/// Procesar Habilitar Totp
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		internal static ERespuestaOperacionSoftToken ProcesarHabilitarTotp(EOperacionesTOTP operacion)
		{
			var respuestaST = new ERespuestaOperacionSoftToken()
			{
				Respuesta = new ERespuesta()
				{
					TipoMensaje = (int)CCampos.TipoMensaje.APP
				},
				RespuestaSoftToken = new ERespuestaST()
			};
			var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointHabilitarUsuario"].ToString();
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
