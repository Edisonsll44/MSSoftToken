using MSSeguridadFraude.Negocio.NeLlamarConfiguracionCentralizada;
using System;
using System.Globalization;
using System.Threading;
using System.Web;
using Tcs.Provider;
using Tcs.Provider.Configuration;

namespace MSSoftToken.MSSoftToken
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Configurator config = new Configurator();
            ProviderConfiguration.Configure(config);
            NeLlamarConfiguracionCentralizada.CargarConfiguraciones();
        }
        /// <summary>
        /// Inicializar Cultura
        /// </summary>
        private void InicializarCultura()
        {
            CultureInfo newCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            newCulture.NumberFormat.NumberDecimalSeparator = ".";
            newCulture.NumberFormat.CurrencyDecimalSeparator = ".";
            newCulture.NumberFormat.NumberGroupSeparator = ",";
            newCulture.NumberFormat.CurrencyGroupSeparator = ",";
            Thread.CurrentThread.CurrentCulture = newCulture;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            ValidarAutorizacionSeguridad();
            Seguridadcache();
            InicializarCultura();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Método que permite Validar Autorizacion Seguridad
        /// </summary>
        private void ValidarAutorizacionSeguridad()
        {
            if (!NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(HttpContext.Current.Request.UserHostAddress.ToString()))
            {
                MensajeSeguridad();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exep = Server.GetLastError();
            string mensaje = exep.Message;
            if (mensaje.IndexOf("SERVICIO CENTRALIZADO") != -1)
            {
                MensajeSeguridad();
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Método que permite presentar el mensaje de "no Autorizado"
        /// </summary>
        private void MensajeSeguridad()
        {
            string ip = HttpContext.Current.Request.UserHostAddress.ToString();
            string url = HttpContext.Current.Request.Url.ToString();

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<html><head>");
            HttpContext.Current.Response.Write("</head><body>");

            string codigoHtml = "<center><div><table><th bgcolor=\"blue\"><h1 style=\"color:white\">Control de Seguridad BGR</h1> </th>" +
                                "<tr><td><h3 style=\"color:red\">Acceso no Autorizado Host IP: {0}</h3></td></tr>" +
                                "<tr><td><h3 style=\"color:red\">Servicio URL: {1}</h3></td></tr>" +
                                "<tr><td bgcolor=\"blue\" style=\"color:white\"><h4>Por favor contactese con el Administrador del Sistema</h4></td></tr>";

            HttpContext.Current.Response.Write(string.Format(codigoHtml, ip, url));
            HttpContext.Current.Response.Write("</table>TCS</div></center>");
            HttpContext.Current.Response.Write("</body></html>");
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Método que permite el manejo del cache
        /// </summary>
        private void Seguridadcache()
        {
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Expires = -1;
            HttpContext.Current.Response.ExpiresAbsolute = new DateTime(1900, 1, 1);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.Cache.SetNoStore();
            HttpContext.Current.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
        }
    }
}