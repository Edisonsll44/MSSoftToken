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
			ERespuesta respuesta = null;
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
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
			respuestaOperacion = AdProcesosSofToken.ProcesarActivarUsuario(operacion);
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
			return respuestaOperacion;
		}
		/// <summary>
		/// Procesar Sincronizar Tiempo Servidor
		/// </summary>
		/// <param name="operacion"></param>
		/// <returns></returns>
		public static ERespuestaOperacionSoftToken ProcesarSincronizarTiempoServidor(EOperacionATOTP operacion)
		{
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			ERespuesta respuesta = null;
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
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_INICIO, operacion.Auditoria, () => operacion);
			respuestaOperacion = AdProcesosSofToken.ProcesarEstadoUsuario(operacion);
			NeLogsTrazabilidad.GuardarLogsTrazabilidad(CConstantes.Textos.TIPO_EVENTO_FIN, operacion.Auditoria, () => respuestaOperacion);
			return respuestaOperacion;
		}
	}
}
