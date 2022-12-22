using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.AccesoDatos.WsAnalisisFraude;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad.AnalisisFraude;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization.Json;
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
    public class AdGestorAnalisisFraude
    {


        protected AdGestorAnalisisFraude()
        {

        }
        /// <summary>
        /// Permite gestionar la conexion con el servicio de reglas de negocio
        /// </summary>
        /// <returns>ServicioReglasNegocio</returns>
        public static ERespuestaOperacionAF InvocarServicioRest(EOperacionRegistroAF entrada)
        {
            var respuestaAF = new ERespuestaOperacionAF()
            {
                Respuesta = new Entidades.Respuesta.ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaAF = new ERespuestaAF()
            };
            var url = AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.TagsCentralizada.URL_SERVICIO_PROVEEDOR_FRAUDE);
            var timeout = Convert.ToInt32(SettingsManager.Group("ConfiguracionesServicioWeb")["TimeOutServicioProveedorSecurity"].ToString());
            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointAnalisisFraude"].ToString();
            var client = new RestClient(url)
            {
                Timeout = timeout
            };

            var request = new RestRequest(recurso, Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            string jsonToSend = JsonConvert.SerializeObject(entrada.OperacionAnalisisAF);

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
                    respuestaAF.Respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
                    respuestaAF.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                    respuestaAF.Respuesta.CodigoEmpresaProveedor = string.Empty;
                    var respuestaGenerica = JsonConvert.DeserializeObject<ERespuestaAF>(responseData.Content);
                    respuestaAF.RespuestaAF = respuestaGenerica;
                    return respuestaAF;
                }
                else
                {
                    respuestaAF.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIOS;
                    respuestaAF.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_PROVEEDOR;
                    respuestaAF.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;
                    if (responseData.StatusCode == HttpStatusCode.RequestTimeout || responseData.StatusCode == HttpStatusCode.GatewayTimeout)
                    {
                        respuestaAF.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                        respuestaAF.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                    }

                    Exception ex = responseData.ErrorException ?? new Exception(respuestaAF.Respuesta.Mensaje);
                    AdLogsExcepcion.GuardarLogExcepcion(ex, entrada.Auditoria, () => recurso, () => entrada.OperacionAnalisisAF, () => respuestaAF);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, entrada.Auditoria, () => recurso, () => entrada.OperacionAnalisisAF, () => respuestaAF);
                respuestaAF.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuestaAF.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuestaAF.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaAF;

        }
    }

}

