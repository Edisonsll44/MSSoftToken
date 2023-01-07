using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading;
using Tcs.Provider.Settings.Base;

namespace MSSeguridadFraude.AccesoDatos.AdGestor
{
    public class AdGestorBloqueoUsuario
    {


        protected AdGestorBloqueoUsuario()
        {

        }
        /// <summary>
        /// Permite gestionar la conexion con el servicio de reglas de negocio
        /// </summary>
        /// <returns>ServicioReglasNegocio</returns>
        public static ERespuestaOperacionSoftToken InvocarServicioRest(EOperacionesTOTP entrada)
        {
            var respuestaST = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new Entidades.Respuesta.ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            var url = AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.TagsCentralizada.URL_SERVICIO_PROVEEDOR_FRAUDE);
            var timeout = Convert.ToInt32(SettingsManager.Group("ConfiguracionesServicioWeb")["TimeOutServicioProveedorSecurity"].ToString());
            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointBloqueoUSuario"].ToString();
            var client = new RestClient(url)
            {
                Timeout = timeout
            };

            var request = new RestRequest(recurso, Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            string jsonToSend = JsonConvert.SerializeObject(entrada);

            IRestResponse responseData = null;
            var resetEvent = new ManualResetEvent(false);

            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;
            try
            {
                client.ExecuteAsync(request, response => { responseData = response; resetEvent.Set(); });

                resetEvent.WaitOne();

                if (responseData.StatusCode == HttpStatusCode.OK)
                {
					respuestaST.Respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
					respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
					respuestaST.Respuesta.CodigoEmpresaProveedor = string.Empty;
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
                    AdLogsExcepcion.GuardarLogExcepcion(ex, entrada.Auditoria, () => recurso, () => entrada, () => respuestaST);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, entrada.Auditoria, () => recurso, () => entrada, () => respuestaST);
				respuestaST.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
				respuestaST.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
				respuestaST.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaST;

        }
    }

}

