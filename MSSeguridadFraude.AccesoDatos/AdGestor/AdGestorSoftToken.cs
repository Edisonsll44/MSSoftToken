using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
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



        public static ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion)
        {
            var respuestaAF = new ERespuesta();
            var recurso = SettingsManager.Group("ConfiguracionesServicioWeb")["EndPointAnalisisFraude"].ToString();
            try
            {
                var request = operacion.ActivarTOTP;
                IRestResponse responseData = GestorServiciosWeb<EActivarTOTP>.SendPostAsync(request, recurso);

                if (responseData.StatusCode == HttpStatusCode.OK)
                {
                    respuestaAF.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL;
                    respuestaAF.Mensaje = CConstantes.Mensajes.MENSAJE_CORRECTO;
                    respuestaAF.CodigoEmpresaProveedor = string.Empty;
                    var respuestaGenerica = JsonConvert.DeserializeObject<ERespuestaAF>(responseData.Content);
                    //respuestaAF.RespuestaAF = respuestaGenerica;
                    return respuestaAF;
                }
                else
                {
                    respuestaAF.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIOS;
                    respuestaAF.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_PROVEEDOR;
                    respuestaAF.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;
                    if (responseData.StatusCode == HttpStatusCode.RequestTimeout || responseData.StatusCode == HttpStatusCode.GatewayTimeout)
                    {
                        respuestaAF.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                        respuestaAF.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR;
                    }

                    Exception ex = responseData.ErrorException ?? new Exception(respuestaAF.Mensaje);
                    AdLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => recurso, () => operacion, () => respuestaAF);
                }
            }
            catch (Exception error)
            {
                AdLogsExcepcion.GuardarLogExcepcion(error, operacion.Auditoria, () => recurso, () => operacion, () => respuestaAF);
                respuestaAF.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuestaAF.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuestaAF.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA_VU;
            }
            return respuestaAF;
        }
    }
}
