using MSSeguridadFraude.Entidades.Logs;
using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace MSSeguridadFraude.Comun.Serializacion
{
    /// <summary>
    /// Clase común que implementa métodos de serialización binaria, json y XML.
    /// </summary>
    public  class CSerializacion
    {
        /// <summary>
        /// Deserializa una cadena XML en un objeto.
        /// </summary>
        /// <typeparam name="T">Tipo de dato que el deserializador empleara.</typeparam>
        /// <param name="cadenaXML">Cadena XML con la serialización del objeto.</param>
        /// <returns>
        /// Un objeto con la deserialización de la cadena XML.
        /// </returns>
        public static T DeserializarXML<T>(string cadenaXML)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(T));
            MemoryStream flujo = new MemoryStream(StringToUTF8ByteArray(cadenaXML));
            return (T)serializador.Deserialize(flujo);
        }

        /// <summary>
        /// Deserializa un array de bytes en un objeto.
        /// </summary>
        /// <typeparam name="T">Tipo de dato que el deserializador empleara.</typeparam>
        /// <param name="bytes">Array de bytes que representan binariamente al objeto.</param>
        /// <returns>
        /// Un objeto con la deserialización del array de bytes.
        /// </returns>
        public static T DeserializarBinario<T>(byte[] bytes)
        {
            BinaryFormatter serializador = new BinaryFormatter();
            MemoryStream flujo = new MemoryStream(bytes);
            return (T)serializador.Deserialize(flujo);
        }

        /// <summary>
        /// Deseraliza una cadena JSON en una entidad, usando un DataContractJsonSerializaer.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto al cual deserializar.</typeparam>
        /// <param name="cadenaJSON">Cadena que representa el objeto en JSON.</param>
        /// <returns>Un objeto correspondiente al tipo T.</returns>
        public static T DeserializarJSON<T>(string cadenaJSON)
        {
            DataContractJsonSerializer serializador = new DataContractJsonSerializer(typeof(T));
            MemoryStream mstream = new MemoryStream(StringToUTF8ByteArray(cadenaJSON));
            return (T)serializador.ReadObject(mstream);
        }

        /// <summary>
        /// Serializa en formato XML un objeto.
        /// </summary>
        /// <param name="objeto">Objeto a ser serializado en formato XML.</param>
        /// <typeparam name="T">Tipo del objeto.</typeparam>
        /// <returns>
        /// Cadena XML con la serialización del objeto.
        /// </returns>
        public static string SerializarXMLSVP<T>(T objeto)
        {
            var serializer = new XmlSerializer(objeto.GetType());
            string utf8;
            using (StringWriter writer = new Utf8StringWriter())
            {
                serializer.Serialize(writer, objeto);
                utf8 = writer.ToString();
            }

            return utf8;
        }

        /// <summary>
        /// SerializarXML
        /// </summary>
        /// <typeparam name="T">Tipo de dato que el serializador empleara</typeparam>
        /// <param name="objeto">T</param>
        /// <returns>string</returns>
        public static string SerializarXML<T>(T objeto)
        {
            if (objeto != null)
            {
                XmlSerializer serializador = new XmlSerializer(objeto.GetType());

                MemoryStream flujo = new MemoryStream();

                XmlWriterSettings configuracion = new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8 };

                XmlWriter writer = XmlWriter.Create(flujo, configuracion);

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                serializador.Serialize(writer, objeto, ns);

                return UTF8ByteArrayToString(flujo.ToArray());
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// SerializarXML
        /// </summary>
        /// <typeparam name="T">Tipo de dato que el deserializador empleara.</typeparam>
        /// <param name="objeto">T</param>
        /// <param name="codificacion">Encoding</param>
        /// <param name="cabecera">bool</param>
        /// <returns>string</returns>
        public static string SerializarXML<T>(T objeto, Encoding codificacion, bool cabecera)
        {
            if (objeto == null)
            {
                objeto = (T)(object)"null";
            }

            XmlSerializer serializador = new XmlSerializer(objeto.GetType());
            MemoryStream flujo = new MemoryStream();
            XmlWriterSettings configuracion = new XmlWriterSettings { Indent = true, Encoding = codificacion, OmitXmlDeclaration = !cabecera };
            XmlWriter writer = XmlWriter.Create(flujo, configuracion);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);
            serializador.Serialize(writer, objeto, ns);
            return codificacion.GetString(flujo.ToArray()).Replace(codificacion.GetString(codificacion.GetPreamble()), string.Empty);
        }

        /// <summary>
        /// Genera entidad con la informacion de un parametro
        /// </summary>
        /// <param name="expresionParametro">Expression</param>
        /// <returns>EParametros</returns>
        public static EParametros CargarParametros(Expression<Func<object>> expresionParametro)
        {
            EParametros parametro = new EParametros();
            MemberExpression expresion;
            if (!(expresionParametro.Body as MemberExpression is null))
            {
                expresion = (MemberExpression)expresionParametro.Body;
            }
            else
            {
                if (!(expresionParametro.Body as UnaryExpression is null))
                {
                    expresion = (MemberExpression)((UnaryExpression)expresionParametro.Body).Operand;
                }
                else
                {
                    expresion = Expression.Field(Expression.Constant(expresionParametro), "expresionParametro");
                }
            }

            parametro.NombreParametro = expresion.Member.Name;
            parametro.TipoParametro = expresion.Type.Name;
            XmlDocument xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.LoadXml(SerializarXML(expresionParametro.Compile()(), Encoding.UTF8, false));
            }
            catch (NullReferenceException)
            {
                xmlDoc.LoadXml(SerializarXML((object)null, Encoding.UTF8, false));
            }

            parametro.ValorParametro = xmlDoc.FirstChild.InnerXml.ToString();
            return parametro;
        }

        /// <summary>
        /// Serializa un objeto en JSON.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto a serializar.</typeparam>
        /// <param name="objeto">Objeto a serializar.</param>
        /// <returns>
        /// Una representacion string del objeto en formato JSON.
        /// </returns>
        public static string SerializarJson<T>(T objeto)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream stream = new MemoryStream();
            serializer.WriteObject(stream, objeto);
            return Encoding.UTF8.GetString(stream.ToArray());
        }

        /// <summary>
        /// Serializa un objeto en Binario.
        /// </summary>        
        /// <param name="objeto">Objeto a serializar.</param>
        /// <returns>
        /// Una array de bytes con la representacion del objeto.
        /// </returns>
        public static byte[] SerializarBinario(object objeto)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            serializer.Serialize(stream, objeto);
            return stream.ToArray();
        }

        /// <summary>
        /// Serializa un valor escalar a JSON.
        /// </summary>
        /// <param name="valor">Valor a serializar.</param>
        /// <param name="tipo">Tipo de tratamiento a darle al valor: decimal, int, string, date.</param>
        /// <returns>
        /// El dato serializado en su formato JSON.
        /// </returns>
        public static string SerializarJson(string valor, string tipo)
        {
            switch (tipo)
            {
                case "decimal":
                case "int":
                case "bool":
                    if (string.IsNullOrEmpty(valor))
                    {
                        return "null";
                    }

                    return valor;
                case "date":
                    if (string.IsNullOrEmpty(valor))
                    {
                        return "null";
                    }

                    return SerializarJson(DateTime.Parse(valor));
                default:
                    // Por defecto se trata como cadena.
                    break;
            }

            return "\"" + valor + "\"";
        }

        /// <summary>
        /// deserializa de un type y un string a object
        /// </summary>
        /// <param name="tipoDeserializar">Type</param>
        /// <param name="strXml">string</param>
        /// <returns>object</returns>
        public static object Deserializar(Type tipoDeserializar, string strXml)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(tipoDeserializar);
                return ser.Deserialize(new StringReader(strXml));
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// deserializacion de un type y stream a object
        /// </summary>
        /// <param name="tipoDeserializar">Type</param>
        /// <param name="stream">Stream</param>
        /// <returns>object</returns>
        public static object Deserializar(Type tipoDeserializar, Stream stream)
        {
            try
            {
                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(tipoDeserializar);
                return ser.Deserialize(stream);
            }
            catch
            {
                return null;
            }
            finally
            {
                stream.Close();
            }
        }

        /// <summary>
        /// Serializarion de un objeto a un string
        /// </summary>
        /// <param name="obj">object</param>
        /// <returns>string</returns>
        public static string Serializar(object obj)
        {
            MemoryStream ms = null;
            try
            {
                ms = new MemoryStream();
                new XmlSerializer(obj.GetType()).Serialize(ms, obj);
                ms.Position = 0;
                return new StreamReader(ms).ReadToEnd().Replace("\r\n", string.Empty).Replace("\\", string.Empty).Trim();
            }
            finally
            {
                ms.Close();
            }
        }

        /// <summary>
        /// Convierte una cadena a un arreglo de bytes UTF8.
        /// </summary>
        /// <param name="cadenaXML">Cadena XML a ser convertida en arreglo de bytes Unicode.</param>
        /// <returns>
        /// Arreglo de bytes convertido desde una cadena XML.
        /// </returns>
        private static byte[] StringToUTF8ByteArray(string cadenaXML)
        {
            return Encoding.UTF8.GetBytes(cadenaXML);
        }

        /// <summary>
        /// Convierte un arreglo de bytes de valores Unicode (UTF-8) a una cadena.
        /// </summary>
        /// <param name="caracteres">Arreglo de bytes Unicode a ser convertido a cadena.</param>
        /// <returns>
        /// Cadena convertida desde un arreglo de bytes Unicode.
        /// </returns>
        private static string UTF8ByteArrayToString(byte[] caracteres)
        {
            return Encoding.UTF8.GetString(caracteres);
        }

        /// <summary>
        /// Utf8StringWriter
        /// </summary>
        public class Utf8StringWriter : StringWriter
        {
            /// <summary>
            /// Encoding
            /// </summary>
            public override Encoding Encoding
            {
                get { return Encoding.UTF8; }
            }
        }
    }
}
