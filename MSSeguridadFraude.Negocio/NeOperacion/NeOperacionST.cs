using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.AccesoDatos.AdOperacionServicio;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Entidades.Mensajes;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.ReglasOperacion;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using MSSeguridadFraude.Negocio.NeLogs;
using MSSeguridadFraude.Negocio.NeValidacion;
using System;

namespace MSSeguridadFraude.Negocio.NeOperacion
{
    public class NeOperacionST
    {
        public NeOperacionST() { }

        /// <summary>
        /// Procesar Activar Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarActivarUsuario(EOperacionATOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
			#region valida campos obligatorios
			respuesta = NeComun.NeValidaciones.ValidarCamposObligatorios(operacion, operacion.Auditoria);
            if (respuesta.Codigo.Equals(CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO))
            {
                respuestaOperacion.Respuesta = respuesta;
                return respuestaOperacion;
            }
			#endregion valida campos obligatorios

			#region valida contenido de campos
			respuesta = NeComun.NeValidaciones.ValidarContenidoEntrada(operacion, operacion.Auditoria);
            if (respuesta.Codigo.Equals(CConstantes.Excepcion.CODIGO_EXCEPCION_INYECCIONSQL))
            {
                respuestaOperacion.Respuesta = respuesta; ;
                return respuestaOperacion;
            }
            if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
            {
                respuestaOperacion.Respuesta = respuesta;
                return respuestaOperacion;
            }
			#endregion valida contenido de campos

			#region validacion de datos de entrada
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			#endregion

			#region reglas de negocio
			EReglaOperacion reglaOperacion = new EReglaOperacion()
            {
                Auditoria = operacion.Auditoria,
                Entorno = operacion.Entorno
            };
			#endregion reglas de negocio

			#region Llamada al método de consulta
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }
			#endregion Llamada al método de consulta
			#region trazabilidad metodo principal
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarActivarUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
			#endregion trazabilidad metodo principal
			return respuestaOperacion;
        }
		/// <summary>
		/// Procesar Sincronizar Tiempo Servidor
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		public static ERespuestaOperacionSoftToken ProcesarSincronizarTiempoServidor(EOperacionATOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
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
                return respuestaOperacion;
            }
            EReglaOperacion reglaOperacion = new EReglaOperacion()
            {
                Auditoria = operacion.Auditoria,
                Entorno = operacion.Entorno
            };
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                return respuestaOperacion;
            }
            if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarSincronizarTiempoServidor(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
        /// <summary>
        /// Procesar Desbloquear Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarDesbloquearUsuario(EOperacionTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
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
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }

            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarDesbloquearUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
		/// <summary>
		/// Procesar Inhabilitar Usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		public static ERespuestaOperacionSoftToken ProcesarInhabilitarUsuario(EOperacionTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
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

			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarInhabilitarUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
        /// <summary>
        /// Procesar Login Totp
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarLoginTotp(EOperacionLoginTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
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
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarLoginTotp(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
		/// <summary>
		/// Procesar Bloqueo Usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		public static ERespuestaOperacionSoftToken ProcesarBloqueoUsuario(EOperacionTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            respuesta = NeComun.NeValidaciones.ValidarCamposObligatorios(operacion, operacion.Auditoria);
            if (respuesta.Codigo.Equals(CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO))
            {
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
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }

            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarBloqueoUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
        /// <summary>
        /// Procesar Eliminar Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarEliminarUsuario(EOperacionTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
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
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarEliminarUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
        /// <summary>
        /// Procesar Habilitar Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarHabilitarUsuario(EOperacionTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
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
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarHabilitarUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
        /// <summary>
        /// Procesar Registrar Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarRegistrarUsuario(EOperacionRegistrarTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
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
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarRegistrarUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;
        }
		/// <summary>
		/// Procesar Estado Usuario
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		public static ERespuestaOperacionSoftToken ProcesarEstadoUsuario(EOperacionTOTP operacion)
        {
            ERespuesta respuesta = new ERespuesta();
            EConsultaMensaje datoMensaje = new EConsultaMensaje
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                Auditoria = operacion.Auditoria
            };
            ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
			respuesta = ValidaDatosBasicos(operacion);
			if (!respuesta.Codigo.Equals(CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString()))
			{
				respuestaOperacion.Respuesta = respuesta;
				return respuestaOperacion;
			}
			ERespuestaRegla respuestaRegla = NeValidacionReglas.ValidarReglas(reglaOperacion);
            if (!respuestaRegla.Permitido)
            {
                respuestaOperacion.Respuesta = ObtenerErrorReglas();
                return respuestaOperacion;
            }

            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
            respuestaOperacion = AdProcesosSofToken.ProcesarEstadoUsuario(operacion);
            NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
            return respuestaOperacion;

        }

		#region Métodos privados
		static ERespuesta ObtenerErrorReglas()
        {
            return new ERespuesta()
            {
                Codigo = CConstantes.Excepcion.CODIGO_ERROR_REGLA_NO_ACTIVA,
                Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_NO_CUMPLE_REGLAS_NEGOCIO,
                CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA,
                FechaRespuesta = DateTime.Now,
                OperacionProcesada = false,
            };
        }
		static ERespuesta ValidaDatosBasicos(EOperacionATOTP operacion)
		{
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);

			ERespuesta respuesta = new ERespuesta();
			if (operacion.Sincronizacion.timesyncauto.Trim() == "" && operacion.Sincronizacion.timesyncmanual.Trim() == "")
			{
				respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO.ToString();
				respuesta.Mensaje = string.Format(CConstantes.Mensajes.MENSAJE_ERROR_CAMPO_OBLIGATORIO, "timesyncauto/timesyncmanual");
				respuesta.FechaRespuesta = DateTime.Now;
				respuesta.OperacionProcesada = respuesta.OperacionProcesada;
			}
			else
			{
				respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString();
			}
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuesta);

			return respuesta;
		}
		static ERespuesta ValidaDatosBasicos(EOperacionTOTP operacion)
		{
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
			ERespuesta respuesta = new ERespuesta();
			if (operacion.Operacion.username.Trim() == "")
			{
				respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO.ToString();
				respuesta.Mensaje = string.Format(CConstantes.Mensajes.MENSAJE_ERROR_CAMPO_OBLIGATORIO, "username");
				respuesta.FechaRespuesta = DateTime.Now;
				respuesta.OperacionProcesada = respuesta.OperacionProcesada;
			}
			else
			{
				respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString();
			}
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuesta);
			return respuesta;
		}
		static ERespuesta ValidaDatosBasicos(EOperacionLoginTOTP operacion)
		{
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
			ERespuesta respuesta = new ERespuesta();
			if (operacion.Login.username.Trim() == "" && operacion.Login.otp.Trim() == "")
			{
				respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO.ToString();
				respuesta.Mensaje = string.Format(CConstantes.Mensajes.MENSAJE_ERROR_CAMPO_OBLIGATORIO, "username/otp");
				respuesta.FechaRespuesta = DateTime.Now;
				respuesta.OperacionProcesada = respuesta.OperacionProcesada;
			}
			else
			{
				respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString();
			}
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuesta);
			return respuesta;
		}
		static ERespuesta ValidaDatosBasicos(EOperacionRegistrarTOTP operacion)
		{
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
			ERespuesta respuesta = new ERespuesta();
			if (operacion.Operacion.username.Trim() == "" && operacion.Operacion.phoneNumber.Trim() == "" && operacion.Operacion.passcode.Trim() == "" && operacion.Operacion.deploymentMechanism.Trim() == "")
			{
				respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_CAMPO_OBLIGATORIO.ToString();
				respuesta.Mensaje = string.Format(CConstantes.Mensajes.MENSAJE_ERROR_CAMPO_OBLIGATORIO, "username/phoneNumber/passcode/deploymentMechanism");
				respuesta.FechaRespuesta = DateTime.Now;
				respuesta.OperacionProcesada = respuesta.OperacionProcesada;
			}
			else
			{
				respuesta.Codigo = CConstantes.Server.CODIGO_CORRECTO_GENERAL.ToString();
			}
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuesta);
			return respuesta;
		}
		#endregion
	}
}