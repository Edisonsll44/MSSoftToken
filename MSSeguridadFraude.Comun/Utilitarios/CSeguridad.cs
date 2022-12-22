using System.Collections.Specialized;
using TCS.Provider.AES;

namespace MSSeguridadFraude.Comun.Utilitarios
{
    /// <summary>
    /// CSeguridad
    /// </summary>
    public class CSeguridad
    {
        /// <summary>
        /// parametros
        /// </summary>
        private readonly NameValueCollection parametros;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="llave">string llave</param>
        /// <param name="vector">string vector</param>
        /// <param name="salt">string salt</param>
        public CSeguridad(string llave, string vector, string salt)
        {
            parametros = new NameValueCollection
            {
                { "Llave", llave },
                { "Vector", vector },
                { "Salt", salt }
            };
        }

        /// <summary>
        /// Encripta texto en AES256 
        /// </summary>
        /// <param name="texto">string texto a emcriptar</param>
        /// <returns>string</returns>
        public string Encriptar(string texto)
        {
            AESSeguridad pbjseguridad = new AESSeguridad(parametros);
            return pbjseguridad.Cifrar(texto);
        }

        /// <summary>
        /// Desencripta texto en AES256
        /// </summary>
        /// <param name="texto">string texto a desencriptar</param>
        /// <returns>string</returns>
        public string Desencriptar(string texto)
        {
            AESSeguridad pbjseguridad = new AESSeguridad(parametros);
            return pbjseguridad.Decifrar(texto);
        }
    }
}