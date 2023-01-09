
using MSSeguridadFraude.Comun.Constantes;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading;
using Tcs.Provider.Settings.Base;
using System.Reflection;
using MSSeguridadFraude.AccesoDatos.AdComun;

namespace MSSeguridadFraude.AccesoDatos.AdGestor
{
    public class GestorServiciosWeb<TRequest> where TRequest : class
    {

        public GestorServiciosWeb()
        {

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="metodo"></param>
        /// <returns></returns>
        public static IRestResponse SendPostAsync(TRequest entrada, string recurso, bool a = false)
        {
          //  var url = "https://auth1.bgr.ec";
            var url = AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.TagsCentralizada.URL_SERVICIO_PROVEEDOR_FRAUDE);
            var timeout = Convert.ToInt32(SettingsManager.Group("ConfiguracionesServicioWeb")["TimeOutServicioProveedorSecurity"].ToString());
            var client = new RestClient(url)
            {
                Timeout = timeout
            };
           

            var request = new RestRequest(recurso, Method.POST)
            {
                RequestFormat = DataFormat.Json
            };

            IRestResponse responseData = null;
            var resetEvent = new ManualResetEvent(false);
            if (a)
            {
                request.AddHeader(CConstantes.Formatos.ContentType, CConstantes.Formatos.WwwFormUrlEncodeHeader);
                Type tModelType = entrada.GetType();
                PropertyInfo[] arrayPropertyInfos = tModelType.GetProperties();
                foreach (PropertyInfo property in arrayPropertyInfos)
                {
                    var valor = property.GetValue(entrada)==null? string.Empty: property.GetValue(entrada).ToString().Trim();
                    if (!string.IsNullOrEmpty(valor))
                    {
                        request.AddQueryParameter(property.Name, property.GetValue(entrada).ToString());
                    }
                }
            }
            else
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
                string jsonToSend = JsonConvert.SerializeObject(entrada, jsonSerializerSettings);
                request.AddParameter(CConstantes.Formatos.JsonFormatHeader, jsonToSend, ParameterType.RequestBody);
            }

            request.RequestFormat = DataFormat.Json;
            client.ExecuteAsync(request, response => { responseData = response; resetEvent.Set(); });
            resetEvent.WaitOne();
            return responseData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="metodo"></param>
        /// <returns></returns>
        public static IRestResponse SendGetAsync(TRequest entrada, string metodo)
        {
            IRestResponse responseData = null;

            return responseData;
        }

    }
}
