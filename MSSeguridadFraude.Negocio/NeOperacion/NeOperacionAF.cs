using MSSeguridadFraude.AccesoDatos.AdOperacionServicio;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad.AnalisisFraude;
using MSSeguridadFraude.Entidades.ReglasOperacion;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
using MSSeguridadFraude.Negocio.NeLogs;
using MSSeguridadFraude.Negocio.NeValidacion;

namespace MSSeguridadFraude.Negocio.NeOperacion
{
    /// <summary>
    /// NeOperacion
    /// </summary>
    public  class NeOperacionAF
    {
        protected NeOperacionAF()
        {

        }


        /// <summary>
        /// Metodo de Procesamiento de analisis de fraude
        /// </summary>
        /// <param name="operacion">EOperacionConsulta</param>
        /// <returns>ERespuestaOperacion</returns>
        public static ERespuestaOperacionAF ProcesarAnalisisFraude(EOperacionRegistroAF operacion)
        {
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);

            ERespuestaOperacionAF respuestaOperacion = new ERespuestaOperacionAF
            {
                RespuestaAF = new ERespuestaAF(),
                Respuesta = new ERespuesta()
            };

            ERespuesta respuesta = null;
          

            respuesta = NeComun.NeValidaciones.ValidarCamposObligatorios(operacion, operacion.Auditoria);

            if (respuesta.Codigo.Equals(CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO))
            {
                respuestaOperacion.Respuesta = respuesta;
                return respuestaOperacion;
            }

            respuesta = NeComun.NeValidaciones.ValidarContenidoEntrada(operacion, operacion.Auditoria);

            if (respuesta.Codigo.Equals(CConstantes.Excepcion.CODIGO_EXCEPCION_INYECCIONSQL))
            {
                respuestaOperacion.Respuesta = respuesta;
                return respuestaOperacion;
            }

         
            if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
            {
                respuestaOperacion.Respuesta = respuesta;
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
                respuestaOperacion.Respuesta = respuestaRegla.Respuesta;                
                return respuestaOperacion;
            }

           

            if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
            {
                return respuestaOperacion;
            }
            //INICIO CAMBIO PLANTILLA
            respuestaOperacion = AdProcesamientoFraude.AnalizarOperacionFraude(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }


        /// <summary>
        /// /
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuesta ActivarTOTP(EOperacionATOTP operacion)
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
           // respuestaOperacion = AdProcesamientoFraude.AnalizarOperacionFraude(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

    }
}
