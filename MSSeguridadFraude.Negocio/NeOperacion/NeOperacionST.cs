using MSSeguridadFraude.AccesoDatos.AdOperacionServicio;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.ReglasOperacion;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using MSSeguridadFraude.Negocio.NeLogs;
using MSSeguridadFraude.Negocio.NeValidacion;

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
        public static ERespuestaOperacionSoftToken ProcesarActivarUsuario(EOperacionATOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarActivarUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarSincronizarTiempoServidor(EOperacionATOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarSincronizarTiempoServidor(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarDesbloquearUsuario(EOperacionTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarDesbloquearUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarInhabilitarUsuario(EOperacionTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarInhabilitarUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarLoginTotp(EOperacionLoginTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarLoginTotp(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarBloqueoUsuario(EOperacionTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarBloqueoUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        internal static ERespuestaOperacionSoftToken ProcesarEliminarUsuario(EOperacionTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarEliminarUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarHabilitarUsuario(EOperacionTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarHabilitarUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarRegistrarUsuario(EOperacionRegistrarTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarRegistrarUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

        public static ERespuestaOperacionSoftToken ProcesarEstadoUsuario(EOperacionTOTP operacion)
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
            respuestaOperacion = AdProcesosSofToken.ProcesarEstadoUsuario(operacion);
            //FIN CAMBIO PLANTILLA
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

            return respuestaOperacion;
        }

		public static ERespuestaOperacionSoftToken ProcesarBloqueoUsuario(EOperacionesTOTP operacion)
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
			respuestaOperacion = AdProcesosSofToken.ProcesarBloqueoUsuario(operacion);
			//FIN CAMBIO PLANTILLA
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

			return respuestaOperacion;
		}

		internal static ERespuestaOperacionSoftToken ProcesarEliminarTotp(EOperacionesTOTP operacion)
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
			respuestaOperacion = AdProcesosSofToken.ProcesarEliminarTotp(operacion);
			//FIN CAMBIO PLANTILLA
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

			return respuestaOperacion;
		}

		internal static ERespuestaOperacionSoftToken ProcesarHabilitarTotp(EOperacionesTOTP operacion)
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
			respuestaOperacion = AdProcesosSofToken.ProcesarHabilitarTotp(operacion);
			//FIN CAMBIO PLANTILLA
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

			return respuestaOperacion;
		}

		internal static ERespuestaOperacionSoftToken ProcesarLoginTotp(EOperacionesLoginTOTP operacion)
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
			respuestaOperacion = AdProcesosSofToken.ProcesarLoginTotp(operacion);
			//FIN CAMBIO PLANTILLA
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

			return respuestaOperacion;
		}

		internal static ERespuestaOperacionSoftToken ProcesarRegistrarUsuario(EOperacionesRegistrarTOTP operacion)
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
			respuestaOperacion = AdProcesosSofToken.ProcesarRegistrarUsuario(operacion);
			//FIN CAMBIO PLANTILLA
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

			return respuestaOperacion;
		}

		internal static ERespuestaOperacionSoftToken ProcesarEstadoUsuario(EOperacionesTOTP operacion)
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
			respuestaOperacion = AdProcesosSofToken.ProcesarEstadoUsuario(operacion);
			//FIN CAMBIO PLANTILLA
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);

			return respuestaOperacion;
		}
	}
}
