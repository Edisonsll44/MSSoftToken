using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.Comun;
using System;
using System.Data;

namespace MSSeguridadFraude.AccesoDatos.AdLogs
{
    /// <summary>
    /// Permite gestionar los parametros de los logs
    /// </summary>
    public class AdParametrosLogs : AdBase
    {
        /// <summary>
        /// Obtiene los Parametros de Log
        /// </summary>
        /// <param name="consultaParametro">EParametroLogs consultaParametro</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <returns>EParametroLogs</returns>
        public static EParametroLogs ConsultaParametrosLogs(EParametroLogs consultaParametro, EAuditoria auditoria)
        {
            EParametroLogs respuesta = new EParametroLogs();

            try
            {
                object[] parametros = new object[] 
                {
                    consultaParametro.CodigoCanal,
                    consultaParametro.CodigoMedioInvocacion,
                    consultaParametro.CodigoTransaccion,
                    consultaParametro.CodigoCabeceraTipoLog
                };

                DataSet resultado = ExecuteDataset(
                    CadenaConexion[CConstantes.Base.BASE_DATOS_LOGS],
                    CConstantes.Sps.PRO_CONSULTAR_PARAMETROS_LOGS,
                    parametros);

                if (resultado.Tables.Count > 0 && resultado.Tables[0].Rows.Count > 0)
                {
                    respuesta.IdParametro = Convert.ToInt32(resultado.Tables[0].Rows[0]["ID_PARAMETRO"].ToString());
                    respuesta.CodigoCanal = resultado.Tables[0].Rows[0]["CODIGO_CANAL"].ToString();
                    respuesta.CodigoMedioInvocacion = resultado.Tables[0].Rows[0]["CODIGO_MEDIO_INVOCACION"].ToString();
                    respuesta.CodigoTransaccion = resultado.Tables[0].Rows[0]["CODIGO_TRANSACCION"].ToString();
                    respuesta.CodigoCabeceraTipoLog = resultado.Tables[0].Rows[0]["CODIGO_TIPO_LOG"].ToString();
                    respuesta.Activo = Convert.ToBoolean(resultado.Tables[0].Rows[0]["ACTIVO"]);
                }

                if (respuesta.IdParametro == 0)
                {
                    respuesta.Activo = false;
                }
            }
            catch (Exception ex)
            {
                AdLogsExcepcion.GuardarLogExcepcion(ex, auditoria, () => consultaParametro, () => respuesta);

                // Construye la entidad de respuesta
                respuesta.Activo = false;
            }

            return respuesta;
        }
    }
}
