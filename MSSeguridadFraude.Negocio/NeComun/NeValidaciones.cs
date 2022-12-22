using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Negocio.NeLogs;
using System;

namespace MSSeguridadFraude.Negocio.NeComun
{
    /// <summary>
    /// NeValidaciones
    /// </summary>
    public class NeValidaciones
    {
        /// <summary>
        /// Metodo que valida campos obligatorios
        /// </summary>
        /// <typeparam name="T">Tipo de dato que el validador de campos obligatorios empleara.</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <returns>ERespuesta</returns>
        public static ERespuesta ValidarCamposObligatorios<T>(T entidad, EAuditoria auditoria)
        {
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, auditoria, () => entidad);

            ERespuesta respuestaCamposObligatorios = CValidacionDatos.ValidarCamposObligatorios(entidad);

            if (respuestaCamposObligatorios is null)
            {
                respuestaCamposObligatorios = new ERespuesta
                {
                    Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL,
                    OperacionProcesada = true
                };
            }

            respuestaCamposObligatorios.FechaRespuesta = DateTime.Now;
            respuestaCamposObligatorios.TipoMensaje = (int)CCampos.TipoMensaje.APP;

            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, auditoria, () => respuestaCamposObligatorios);

            return respuestaCamposObligatorios;
        }

        /// <summary>
        /// Metodo que valida el contenido de los campos
        /// </summary>
        /// <typeparam name="T">Tipo de dato que el validador de contenidos empleara.</typeparam>
        /// <param name="entidad">T</param>
        /// <param name="auditoria">EAuditoria</param>
        /// <returns>ERespuesta</returns>
        public static ERespuesta ValidarContenidoEntrada<T>(T entidad, EAuditoria auditoria)
        {
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, auditoria, () => entidad);

            ERespuesta respuestaContenidoCampos = CValidacionDatos.ValidarContenidoCampos(entidad);

            if (respuestaContenidoCampos is null)
            {
                respuestaContenidoCampos = new ERespuesta
                {
                    Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL,
                    OperacionProcesada = true
                };
            }

            respuestaContenidoCampos.FechaRespuesta = DateTime.Now;
            respuestaContenidoCampos.TipoMensaje = (int)CCampos.TipoMensaje.APP;

            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, auditoria, () => respuestaContenidoCampos);

            return respuestaContenidoCampos;
        }
    }
}