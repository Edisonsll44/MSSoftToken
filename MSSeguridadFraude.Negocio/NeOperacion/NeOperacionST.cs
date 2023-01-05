using MSSeguridadFraude.AccesoDatos.AdOperacionServicio;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.ReglasOperacion;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Negocio.NeLogs;
using MSSeguridadFraude.Negocio.NeValidacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguridadFraude.Negocio.NeOperacion
{
    public  class NeOperacionST
    {

        public NeOperacionST()
        {

        }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion)
        {
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);

            ERespuesta respuestaOperacion = new ERespuesta();

            ERespuesta respuesta = null;


            respuesta = NeComun.NeValidaciones.ValidarCamposObligatorios(operacion, operacion.Auditoria);

            if (respuesta.Codigo.Equals(CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO))
            {
                return respuestaOperacion;
            }

            respuesta = NeComun.NeValidaciones.ValidarContenidoEntrada(operacion, operacion.Auditoria);

            if (respuesta.Codigo.Equals(CConstantes.Excepcion.CODIGO_EXCEPCION_INYECCIONSQL))
            {

                return respuestaOperacion;
            }


            if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
            {

                return respuestaOperacion;
            }

            EReglaOperacion reglaOperacion = new EReglaOperacion()
            {
                Auditoria = operacion.Auditoria,
                Entorno = operacion.Entorno
            };

            ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);

            if (!respuestaRegla.Permitido)
            {
                return respuestaOperacion;
            }



            if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
            {
                return respuestaOperacion;
            }
            //INICIO CAMBIO PLANTILLA
            respuestaOperacion = AdProcesosSofToken.ActivarTOTP(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }


        public static ERespuesta SincronizarTiempoTOTP(EOperacionActivarTOTP operacion)
        {

            return null;
        }


        public static ERespuesta DesbloquearTOTP(EOperacionesTOTP operacion)
        {

            return null;
        }

        public static ERespuesta DesabilitarTOTP(EOperacionesTOTP operacion)
        {

            return null;
        }
    }
}
