using MSSeguridadFraude.AccesoDatos.AdComun;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.Mensajes;
using System;
using System.Data;

namespace MSSeguridadFraude.AccesoDatos.AdMensajes
{
    /// <summary>
    /// Clase para manejo de mensajes Parametrizables
    /// </summary>
    public class AdMensajes : AdBase
    {
        /// <summary>
        /// Consulta mensajes para respuesta
        /// </summary>
        /// <param name="datosMensaje">EConsultaMensaje</param>
        /// <param name="tipoMensaje">CCampos.TipoMensaje</param>
        /// <returns>DataSet</returns>
        public static DataSet ConsultarMensaje(EConsultaMensaje datosMensaje)
        {
            DataSet resultadoDatos = null;
            string filtroConsulta = string.Empty;

            switch ((CCampos.TipoMensaje)datosMensaje.Respuesta.TipoMensaje)
            {
                case CCampos.TipoMensaje.SIGLO:
                    filtroConsulta = CConstantes.Textos.FILTRO_CONSULTA_MENSAJE_SIGLO;
                    break;
                case CCampos.TipoMensaje.APP:
                    filtroConsulta = CConstantes.Textos.FILTRO_CONSULTA_MENSAJE;
                    break;
                case CCampos.TipoMensaje.EMPRESA:
                    filtroConsulta = CConstantes.Textos.FILTRO_CONSULTA_MENSAJE_EMPRESA;
                    break;
                case CCampos.TipoMensaje.PROV:
                    filtroConsulta = CConstantes.Textos.FILTRO_CONSULTA_MENSAJE_PROVEEDOR;
                    break;
                default:
                    filtroConsulta = string.Empty;
                    break;
            }

            object[] parametros = new object[]
            {
                datosMensaje.Auditoria.CodigoCanal is null ? string.Empty: datosMensaje.Auditoria.CodigoCanal.Trim(),
                datosMensaje.Auditoria.CodigoTransaccion is null ? string.Empty: datosMensaje.Auditoria.CodigoTransaccion.Trim(),
                datosMensaje.Auditoria.CodigoMedioInvocacion is null ? string.Empty:datosMensaje.Auditoria.CodigoMedioInvocacion.Trim(),
                datosMensaje.Respuesta.Codigo is null ? string.Empty: datosMensaje.Respuesta.Codigo.Trim(),
                filtroConsulta,
                datosMensaje.Respuesta.CodigoEmpresaProveedor==null ? string.Empty:  datosMensaje.Respuesta.CodigoEmpresaProveedor.Trim(),
            };
            try
            {
                resultadoDatos = ExecuteDataset(CadenaConexion[CConstantes.Base.BASE_DATOS_CATALOGO_SERVICIOS_BGR],
                                                CConstantes.Sps.PRO_CAT_CONSULTA_MENSAJE_UNICO,
                                                parametros);
            }
            catch (Exception ex)
            {
                AdLogsExcepcion.GuardarLogExcepcion(ex, datosMensaje.Auditoria, () => datosMensaje, () => resultadoDatos);
            }

            return resultadoDatos;
        }
    }
}