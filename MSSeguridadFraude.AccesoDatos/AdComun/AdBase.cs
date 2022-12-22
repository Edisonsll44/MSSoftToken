using MSSeguridadFraude.Comun.Constantes;
using System;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using Tcs.Provider.Data.Base;

namespace MSSeguridadFraude.AccesoDatos.AdComun
{
    /// <summary>
    /// Clase Abstracta para Manejo de Base de datos Patron Singleton
    /// </summary>
    public abstract class AdBase
    {
        #region Declaracion de Variables
        /// <summary>
        /// Declaracion de Variables p_cadenas_conexion
        /// </summary>
        private static StringDictionary p_cadenas_conexion;

        /// <summary>
        /// Declaracion de Variables cadena_coneccion
        /// </summary>
        private static string cadena_coneccion;

        /// <summary>
        /// Declaracion de Variables parametrosIh
        /// </summary>
        private static IHelperParameterCache parametrosIh;

        /// <summary>
        /// Declaracion de Variables providerIh
        /// </summary>
        private static IHelper providerIh;
        #endregion Declaracion de Variables

        /// <summary>
        /// Constructor activa los drivers a utilizarse para comexiones a SQL y Oracle
        /// </summary>
        static AdBase()
        {
            providerIh = HelperFactory.GetHelper(DBProvider.SQL);
            parametrosIh = HelperFactory.GetHelperParameterCache(DBProvider.SQL);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        protected AdBase()
        {
        }

        /// <summary>
        /// Obtiene las Cadenas de Conexion ala aAbse dedtso configuradas en centralizada.
        /// </summary>
        protected static StringDictionary CadenaConexion
        {
            get
            {
                if (p_cadenas_conexion == null
                    || p_cadenas_conexion.ContainsValue(string.Empty)
                    || p_cadenas_conexion.ContainsValue(null))
                {
                    p_cadenas_conexion = new StringDictionary
                    {
                        { CConstantes.Base.BASE_DATOS_CATALOGO_SERVICIOS_BGR, AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.Base.BASE_DATOS_CATALOGO_SERVICIOS_BGR) },
                        { CConstantes.Base.BASE_DATOS_LOGS, AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.Base.BASE_DATOS_LOGS) },
                        { CConstantes.Base.BASE_DATOS_SIGLO_XXI, AdLlamarConfiguracionCentralizada.ConsultarTagConfiguracion(CConstantes.Base.BASE_DATOS_SIGLO_XXI) }
                    };
                }

                return p_cadenas_conexion;
            }
        }

        /// <summary>
        /// Metodo Sobrecargado que permite ejecutar un Dataset con parametros
        /// </summary>
        /// <param name="cadena">String cadena de concexion</param>
        /// <param name="strSpName">string nombre del Procedimeinto almacenado</param>
        /// <param name="paramValores">Array de Object valores</param>
        /// <param name="sqltrTransaccion">SqlTransaction Objeto</param>
        /// <returns>DataSet de respuesta</returns>
        public static DataSet ExecuteDataset(string cadena, string strSpName, object[] paramValores, SqlTransaction sqltrTransaccion = null)
        {
            IDataParameter[] idpParametros = parametrosIh.GetSpParameterSet(cadena, strSpName);
            int indice = 0;
            foreach (var objValor in paramValores)
            {
                idpParametros[indice].Value = objValor;
                indice++;
            }

            if (sqltrTransaccion != null)
            {
                return providerIh.ExecuteDataset(sqltrTransaccion, strSpName, paramValores);
            }

            return providerIh.ExecuteDataset(cadena, strSpName, paramValores);
        }

        /// <summary>
        /// Metodo Sobrecargado que permite ejecutar un Dataset con parametros
        /// </summary>
        /// <param name="cadena">String cadena de concexion</param>
        /// <param name="strSpName">string nombre del Procedimeinto almacenado</param>
        /// <param name="paramValores">Array de Object valores</param>
        /// <param name="respuestaSp">String respuesta retunr SP</param>
        /// <param name="sqltrTransaccion">SqlTransaction Objeto</param>
        /// <returns>DataSet de respuesta</returns>
        public static DataSet ExecuteDataset(string cadena, string strSpName, object[] paramValores, out string respuestaSp, SqlTransaction sqltrTransaccion = null)
        {
            DataSet dataset;
            IDataParameter[] parametros = parametrosIh.GetSpParameterSet(cadena, strSpName);
            int indice = 0;

            IDataParameter[] idpParametros = new IDataParameter[parametros.Length + 1];

            for (int i = 0; i < parametros.Length; i++)
            {
                idpParametros[i] = parametros[i];
            }

            idpParametros[parametros.Length] = new SqlParameter("@ReturnValue", SqlDbType.Char)
            {
                Direction = ParameterDirection.ReturnValue
            };

            foreach (var objValor in paramValores)
            {
                try
                {
                    idpParametros[indice].Value = objValor;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentException(string.Format(
                        CConstantes.Mensajes.PARAMETROS_INCOSISTENTES_SP,
                        strSpName,
                        idpParametros.Length,
                        paramValores.Length));
                }

                indice++;
            }

            if (sqltrTransaccion != null)
            {
                dataset = providerIh.ExecuteDataset(sqltrTransaccion, CommandType.StoredProcedure, strSpName, idpParametros);
                respuestaSp = idpParametros[parametros.Length].Value.ToString();
                return dataset;
            }

            dataset = providerIh.ExecuteDataset(cadena, CommandType.StoredProcedure, strSpName, idpParametros);
            respuestaSp = idpParametros[parametros.Length].Value.ToString();
            return dataset;
        }

        /// <summary>
        /// Metodo Sobrecargado que permite ejecutar un Dataset sin parametros
        /// </summary>
        /// <param name="cadena">String cadaena de conexion</param>
        /// <param name="strSpName">string Procedimiento Almacenado</param>
        /// <param name="sqltrTransaccion">SqlTransaction</param>
        /// <returns>DataSet de respuesta</returns>
        public static DataSet ExecuteDataset(string cadena, string strSpName, SqlTransaction sqltrTransaccion = null)
        {
            if (sqltrTransaccion != null)
            {
                return providerIh.ExecuteDataset(sqltrTransaccion, strSpName);
            }

            return providerIh.ExecuteDataset(cadena, strSpName);
        }

        /// <summary>
        /// Metodo Sobrecargado que permite ejecutar un NonQuery sin parametros
        /// </summary>
        /// <param name="cadena">String cadena conexion</param>
        /// <param name="strSpName">string Procedimeinto Almacenado</param>
        /// <param name="sqltrTransaccion">SqlTransaction transaccion</param>
        /// <returns>bool</returns>
        public static bool ExecuteNonQuery(string cadena, string strSpName, SqlTransaction sqltrTransaccion = null)
        {
            if (sqltrTransaccion != null)
            {
                providerIh.ExecuteNonQuery(sqltrTransaccion, strSpName);
            }
            else
            {
                providerIh.ExecuteNonQuery(cadena, strSpName);
            }

            return true;
        }

        /// <summary>
        /// Metodo Sobrecargado que permite ejecutar un NonQuery con parametros
        /// </summary>
        /// <param name="cadena">string cadena</param>
        /// <param name="paramValores">object Array valores</param>
        /// <param name="comando">SqlCommand</param>
        /// <param name="sqltrTransaccion">SqlTransaction</param>
        /// <returns>int</returns>
        public static int ExecuteNonQuery(string cadena, object[] paramValores, SqlCommand comando, SqlTransaction sqltrTransaccion = null)
        {
            IDataParameter[] parametros = parametrosIh.GetSpParameterSet(cadena, comando.CommandText);
            int indice = 0;

            IDataParameter[] idpParametros = new IDataParameter[parametros.Length + 1];

            for (int i = 0; i < parametros.Length; i++)
            {
                idpParametros[i] = parametros[i];
            }

            idpParametros[parametros.Length] = new SqlParameter("@ReturnValue", SqlDbType.Char)
            {
                Direction = ParameterDirection.ReturnValue
            };

            foreach (var objValor in paramValores)
            {
                try
                {
                    idpParametros[indice].Value = objValor;
                }
                catch (IndexOutOfRangeException)
                {
                    throw new ArgumentException(string.Format(
                        CConstantes.Mensajes.PARAMETROS_INCOSISTENTES_SP,
                        comando,
                        idpParametros.Length,
                        paramValores.Length));
                }

                indice++;
            }

            if (sqltrTransaccion != null)
            {
                providerIh.ExecuteDataset(sqltrTransaccion, CommandType.StoredProcedure, comando.CommandText, idpParametros);
            }
            else
            {
                providerIh.ExecuteDataset(cadena, CommandType.StoredProcedure, comando.CommandText, idpParametros);
            }

            indice = 0;
            foreach (object parametro in paramValores)
            {
                paramValores[indice] = idpParametros[indice].Value;
                indice++;
            }

            return (int)idpParametros[indice].Value;
        }

        #region transaccionalidadSQL

        /// <summary>
        /// Inicia las Transacciones
        /// </summary>
        /// <param name="cadena">String cadena de conexion</param>
        /// <returns>SqlTransaction</returns>
        public static SqlTransaction IniciarTransaccion(string cadena)
        {
            SqlConnection sqlcnConexion;
            SqlTransaction sqltrTransaccion = null;

            cadena_coneccion = cadena;

            sqlcnConexion = Conectar();

            if (sqlcnConexion != null)
            {
                sqltrTransaccion = sqlcnConexion.BeginTransaction();
            }

            return sqltrTransaccion;
        }

        /// <summary>
        /// Terminar las Transacciones SQL Server
        /// </summary>
        /// <param name="sqltrTransaccion">SqlTransaction</param>
        /// <param name="conexion">SqlConnection</param>
        /// <returns>bool</returns>
        public static bool GrabarTransaccion(SqlTransaction sqltrTransaccion)
        {
            if (sqltrTransaccion != null)
            {
                sqltrTransaccion.Commit();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Obtiene las Conexion a la Base de datos SqlServer.
        /// </summary>
        /// <returns>SqlConnection</returns>
        private static SqlConnection Conectar()
        {
            SqlConnection sqlcnConexion = new SqlConnection
            {
                ConnectionString = cadena_coneccion
            };
            sqlcnConexion.Open();
            return sqlcnConexion;
        }
        #endregion
    }
}