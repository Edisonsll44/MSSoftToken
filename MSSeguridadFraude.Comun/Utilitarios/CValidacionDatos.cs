using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.Respuesta;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace MSSeguridadFraude.Comun.Utilitarios
{
    /// <summary>
    /// Clase para validar los campos de las entidades se puede usar diferentes tipos de expresiones, como email, telefonos etc.
    /// </summary>
    public  class CValidacionDatos
    {
        /// <summary>
        /// ISREQUIRED
        /// </summary>
        private const string ISREQUIRED = "IsRequired";

        /// <summary>
        /// InyeccionSql
        /// </summary>
        private static readonly Regex InyeccionSql = new Regex(@"('(''|[^']) * ')|(;)|(\b(ALTER|CREATE|DELETE|DROP|EXEC(UTE){0,1}|INSERT( +INTO){0,1}|MERGE|SELECT|UPDATE|UNION( +ALL){0,1})\b)", RegexOptions.Compiled);

        /// <summary>
        /// Permite validar los datos de las propiedades de la entidad enviada, por ejemplo validar inyeccion SQL. 
        /// Funcion recursiva
        /// </summary>
        /// <typeparam name="T">Tipo de dato que empleara la validación</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="respuesta">ERespuesta opcional</param>
        /// <returns>ERespuesta</returns>
        public static ERespuesta ValidarContenidoCampos<T>(T entidad, ERespuesta respuesta = null)
        {
            Type type = entidad.GetType();
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (PropertyInfo info in propertyInfo)
            {
                if (info.GetValue(entidad) != null)
                {
                    switch (Type.GetTypeCode(info.PropertyType))
                    {
                        case TypeCode.Boolean:
                            break;
                        case TypeCode.DateTime:
                            // validar fecha
                            break;
                        case TypeCode.Decimal:
                            break;
                        case TypeCode.Double:
                            break;
                        case TypeCode.String:
                            respuesta = ValidarContenidoCamposString(entidad, info, respuesta);
                            break;
                        case TypeCode.Int16:
                            break;
                        case TypeCode.Int32:
                            break;
                        case TypeCode.Int64:
                            break;
                        default:
                            respuesta = ValidarContenidoCamposDefault(entidad, info, respuesta);

                            break;
                    }
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Permite validar los datos de las propiedades de la entidad enviada, valida campos obligatorios
        /// </summary>
        /// Funcion recursiva
        /// <typeparam name="T">Tipo de dato que empleara la validación</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="respuesta">ERespuesta opcional</param>
        /// <returns>ERespuesta</returns>
        public static ERespuesta ValidarCamposObligatorios<T>(T entidad, ERespuesta respuesta = null)
        {
            Type type = entidad.GetType();
            PropertyInfo[] propertyInfo = type.GetProperties();
            foreach (PropertyInfo info in propertyInfo)
            {
                if (info.GetValue(entidad) != null)
                {
                    switch (Type.GetTypeCode(info.PropertyType))
                    {
                        case TypeCode.Boolean:
                            break;
                        case TypeCode.DateTime:
                            break;
                        case TypeCode.Decimal:
                            break;
                        case TypeCode.Double:
                            break;
                        case TypeCode.String:
                            respuesta = ValidarCamposObligatoriosString(entidad, info, respuesta);
                            break;
                        case TypeCode.Int16:
                            respuesta = ValidarCamposObligatoriosInt16(entidad, info, respuesta);
                            break;
                        case TypeCode.Int32:
                            break;
                        case TypeCode.Int64:
                            break;
                        default:
                            respuesta = ValidarCamposObligatoriosDefault(entidad, info, respuesta);

                            break;
                    }
                }
            }
            return respuesta;
        }

        /// <summary>
        /// Verifica las propiedades requeridas
        /// </summary>
        /// <param name="info">PropertyInfo</param>
        /// <returns>bool</returns>
        private static bool VerificarEsRequerido(PropertyInfo info)
        {
            bool respuesta = false;
            IList<CustomAttributeData> attributes = CustomAttributeData.GetCustomAttributes(info);
            foreach (CustomAttributeData cad in attributes)
            {
                foreach (CustomAttributeNamedArgument cana in cad.NamedArguments)
                {
                    if (cana.MemberName.Equals(ISREQUIRED) &&
                        bool.Parse(cana.TypedValue.Value.ToString()))
                    {
                        return true;
                    }
                }
            }
            return respuesta;
        }
        /// <summary>
        /// Permite validar los datos de las propiedades de la entidad enviada, por ejemplo validar inyeccion SQL. (string)
        /// </summary>
        /// <typeparam name="T">Tipo de dato que empleara la validación</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="info">PropertyInfo</param>
        /// <param name="respuesta">ERespuesta</param>
        /// <returns>Respuesta</returns>
        private static ERespuesta ValidarContenidoCamposString<T>(T entidad, PropertyInfo info, ERespuesta respuesta = null)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(info.GetValue(entidad))) &&
                InyeccionSql.IsMatch(Convert.ToString(info.GetValue(entidad)).ToUpper()))
            {
                respuesta = new ERespuesta
                {
                    Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_INYECCIONSQL,
                    Mensaje = string.Format(CConstantes.Mensajes.MENSAJE_ERROR_VALIDACION_INYECCION, info.Name)
                };
            }
            return respuesta;
        }
        /// <summary>
        /// Permite validar los datos de las propiedades de la entidad enviada, por ejemplo validar inyeccion SQL. (Default)
        /// </summary>
        /// <typeparam name="T">Tipo de dato que empleara la validación</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="info">PropertyInfo</param>
        /// <param name="respuesta">ERespuesta</param>
        /// <returns>Respuesta</returns>
        private static ERespuesta ValidarContenidoCamposDefault<T>(T entidad, PropertyInfo info, ERespuesta respuesta = null)
        {
            var elementos = info.GetValue(entidad);
            // si existe alguna propiedad que tenga varios elementos como lista o array
            if (elementos is IEnumerable)
            {
                foreach (var elemento in elementos as IEnumerable)
                {
                    respuesta = ValidarContenidoCampos(elemento, respuesta);
                }
            }
            else
            {
                respuesta = ValidarContenidoCampos(info.GetValue(entidad), respuesta);
            }
            return respuesta;
        }
        /// <summary>
        /// Permite validar los datos de las propiedades de la entidad enviada, valida campos obligatorios (String)
        /// </summary>
        /// <typeparam name="T">Tipo de dato que empleara la validación</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="info">PropertyInfo</param>
        /// <param name="respuesta">ERespuesta</param>
        /// <returns>Respuesta</returns>
        private static ERespuesta ValidarCamposObligatoriosString<T>(T entidad, PropertyInfo info, ERespuesta respuesta = null)
        {
            if (string.IsNullOrEmpty(Convert.ToString(info.GetValue(entidad))) &&
                VerificarEsRequerido(info))
            {
                respuesta = new ERespuesta
                {
                    Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO,
                    Mensaje = string.Format(CConstantes.Mensajes.MENSAJE_ERROR_CAMPO_OBLIGATORIO, info.Name)
                };
            }
            return respuesta;
        }
        /// <summary>
        /// Permite validar los datos de las propiedades de la entidad enviada, valida campos obligatorios (Int16)
        /// </summary>
        /// <typeparam name="T">Tipo de dato que empleara la validación</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="info">PropertyInfo</param>
        /// <param name="respuesta">ERespuesta</param>
        /// <returns>Respuesta</returns>
        private static ERespuesta ValidarCamposObligatoriosInt16<T>(T entidad, PropertyInfo info, ERespuesta respuesta = null)
        {
            if (Convert.ToInt16(info.GetValue(entidad)) <= 0 &&
                VerificarEsRequerido(info))
            {
                respuesta = new ERespuesta
                {
                    Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO,
                    Mensaje = string.Format(CConstantes.Mensajes.MENSAJE_ERROR_CAMPO_OBLIGATORIO, info.Name)
                };
            }
            return respuesta;
        }
        /// <summary>
        /// Permite validar los datos de las propiedades de la entidad enviada, valida campos obligatorios (Default)
        /// </summary>
        /// <typeparam name="T">Tipo de dato que empleara la validación</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="info">PropertyInfo</param>
        /// <param name="respuesta">ERespuesta</param>
        /// <returns>Respuesta</returns>
        private static ERespuesta ValidarCamposObligatoriosDefault<T>(T entidad, PropertyInfo info, ERespuesta respuesta = null)
        {
            var elementos = info.GetValue(entidad);
            // si existe alguna propiedad que tenga varios elementos como lista o array
            if (elementos is IEnumerable)
            {
                foreach (var elemento in elementos as IEnumerable)
                {
                    respuesta = ValidarCamposObligatorios(elemento, respuesta);
                }
            }
            else
            {
                respuesta = ValidarCamposObligatorios(info.GetValue(entidad), respuesta);
            }
            return respuesta;
        }
    }
}