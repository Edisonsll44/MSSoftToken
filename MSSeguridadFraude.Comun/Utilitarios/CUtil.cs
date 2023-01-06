using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace MSSeguridadFraude.Comun.Utilitarios
{
    /// <summary>
    /// Contiene metodos metodos utilitarios 
    /// </summary>
    public class CUtil
    {
        /// <summary>
        /// FORMATO FECHA TIMESSTAMP SIGLO
        /// </summary>
        private const string FORMATO_FECHA_TIMESSTAMP_SIGLO = "yyyy-MM-dd-HH.mm.ss.ffffff";

        /// <summary>
        /// Constructor
        /// </summary>
        protected CUtil()
        {
        }

        /// <summary>
        /// Obtiene el Nombre del Aplictivo
        /// </summary>
        /// <returns>string</returns>
        public static string ObtenerNombreAplicacion()
        {
            try
            {
                return AppDomain.CurrentDomain.BaseDirectory.Split('\\')[AppDomain.CurrentDomain.BaseDirectory.Split('\\').Length - 2];
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Obtiene la direccion IPV4 del servidor
        /// </summary>
        /// <returns>string</returns>
        public static string ObtenerIPServidor()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            return "No dispone de direcciones IPv4";
        }

        /// <summary>
        /// Obtiene el nombre del servidor
        /// </summary>
        /// <returns>string</returns>
        public static string ObtenerNombreServidor()
        {
            
            string strHostName = Dns.GetHostName();
          
            return strHostName;
        }

        /// <summary>
        /// Obtiene el nombre del Metodo
        /// </summary>
        /// <returns>string</returns>
        public static string ObtenerNombreMetodo()
        {
            var st = new StackTrace(new StackFrame(1));
            return st.GetFrame(0).GetMethod().Name;
        }

        /// <summary>
        /// Devuelve el nombre especifico de un objeto sirve para comparar nombres y no tener quemado
        /// </summary>
        /// <param name="objeto">Cualquier entidad o nombre reservado del entorno ejemplo: WebException</param>
        /// <returns>string</returns>
        public static string ObtenerNombreObjeto(object objeto)
        {
            Type type = objeto.GetType();
            return type.Name;
        }

        /// <summary>
        /// Obtiene el Identificador Unico Global de la aplicacion
        /// </summary>
        /// <returns>string</returns>
        public static string ObtenerGUID()
        {
            return Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Convierte una fecha formato timesStamp en DateTime 
        /// </summary>
        /// <param name="fecha">Fecha en formato TimesStamp, el tamaño fijo es de 26 con un formato unico de fecha</param>
        /// <returns>DateTime</returns>
        public static DateTime ConvertirTimesStamp(string fecha)
        {
            return DateTime.ParseExact(fecha.Length > 26 ? fecha.Substring(0, 26) : fecha, FORMATO_FECHA_TIMESSTAMP_SIGLO, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Devuelve la fecha 1900-01-01 para los campos que no son seteados
        /// </summary>
        /// <returns>DateTime</returns>
        public static DateTime ObtenerFechaMinima()
        {
            return DateTime.ParseExact("1900-01-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Método que enmascaraá de de que posición se requiere y con cuál caractér por ejemplo el caractér "X"
        /// </summary>
        /// <param name="texto">string texto a enmascarar</param>
        /// <param name="numeroCaracterInicio">int inicio</param>
        /// <param name="numeroCaracterFin">int fin</param>
        /// <param name="caracterMascara">char</param>
        /// <returns>string</returns>
        public static string EnmascararTexto(string texto, int numeroCaracterInicio, int numeroCaracterFin, char caracterMascara)
        {
            string mascara;
            if (texto.Length > (numeroCaracterInicio + numeroCaracterFin))
            {
                string textoinicio = texto.Substring(0, numeroCaracterInicio);
                string textofin = texto.Substring(texto.Length - numeroCaracterFin, numeroCaracterFin);
                StringBuilder texto_mask = new StringBuilder();
                int num_mask = texto.Length - (numeroCaracterInicio + numeroCaracterFin);
                for (int i = 0; i < num_mask; i++)
                {
                    texto_mask.Append(caracterMascara);
                }

                mascara = textoinicio + texto_mask + textofin;
            }
            else
            {
                mascara = texto;
            }

            return mascara;
        }
        /// <summary>
		/// Metodo que separa la respuesta enviada por el proveedor, a un objeto
		/// </summary>
		/// <param name="respuesta"></param>
		/// <param name="caracter"></param>
		/// <returns></returns>
		public static ERespuestaST MapearRespuesta(string respuesta, char caracter)
        {
            var arregloCadena = respuesta.Split(caracter);
            var concatenacion = ConcatenarArreglo(arregloCadena);
            return new ERespuestaST()
            {
                Codigo = arregloCadena[0],
                Mensaje = concatenacion,
               
            };
        }
        /// <summary>
		/// Concatena multiples indices de un arrego
		/// </summary>
		/// <param name="arreglo"></param>
		/// <returns></returns>
		static string ConcatenarArreglo(string[] arreglo)
        {
            string cadena = string.Empty;
            for (int i = 1; i <= arreglo.Length - 1; i++)
            {
                cadena += arreglo[i];
            }
            return cadena;
        }
    }
}
