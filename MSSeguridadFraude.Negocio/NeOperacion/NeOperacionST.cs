using MSSeguridadFraude.AccesoDatos.AdOperacionServicio;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.ReglasOperacion;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
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
        public static ERespuestaOperacionSoftToken ActivarTOTP(EOperacionATOTP operacion)
        {
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);

            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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


        public static ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion)
        {
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);

            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
            respuestaOperacion = AdProcesosSofToken.SincronizarTiempoTOTP(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }


        public static ERespuestaOperacionSoftToken DesbloquearTOTP(EOperacionesTOTP operacion)
        {

            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);

            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
            respuestaOperacion = AdProcesosSofToken.DesbloquearTOTP(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken DesabilitarTOTP(EOperacionesTOTP operacion)
        {

            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);

            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
            respuestaOperacion = AdProcesosSofToken.DesabilitarTOTP(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }
    }
}
