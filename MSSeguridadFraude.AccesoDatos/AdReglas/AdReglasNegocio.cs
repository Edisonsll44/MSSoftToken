using System;
using System.Net;
using System.Collections;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.AccesoDatos.AdGestor;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.ReglasOperacion;

namespace MSSeguridadFraude.AccesoDatos.AdReglas
{
	public class AdReglasNegocio
	{
		private static Hashtable tablaReglasNegocio = null;

		/// <summary>
		/// Metodo que valida si la operacion esta permitida para el canal, medio de invocacion y codigo de transaccion
		/// </summary>
		/// <param name="reglaOperacion">EReglaOperacion</param>
		/// <returns>ERespuestaRegla</returns>
		public static ERespuestaRegla VerificarOperacionPermitida(EReglaOperacion reglaOperacion)
		{
			ERespuestaRegla respuesta = new ERespuestaRegla
			{
				Respuesta = new ERespuesta()
			};
			try
			{
				using (MSReglasNegocio.ServicioReglasNegocio servicio = AdGestorReglasNegocio.ConectarServicioReglasNegocio())
				{
					MSReglasNegocio.Verificar regla = new MSReglasNegocio.Verificar
					{
						Auditoria = new MSReglasNegocio.Auditoria
						{
							Canal = new MSReglasNegocio.Canal
							{
								CodigoCanal = reglaOperacion.Auditoria.CodigoCanal
							},
							MediosInvocacion = new MSReglasNegocio.MedioInvocacion
							{
								CodigoMedioInvocacion = reglaOperacion.Auditoria.CodigoMedioInvocacion
							},
							TransaccionesFinancieras = new MSReglasNegocio.TransaccionFinanciera
							{
								CodigoTransaccion = reglaOperacion.Auditoria.CodigoTransaccion
							}
						}
					};
					MSReglasNegocio.RespuestaRegla respuestaRegla = servicio.VerificarRegla(regla);
					respuesta.Clave = reglaOperacion.Auditoria.CodigoCanal + reglaOperacion.Auditoria.CodigoTransaccion + reglaOperacion.Auditoria.CodigoMedioInvocacion;
					respuesta.Permitido = respuestaRegla.OperacionPermitida;
					respuesta.Respuesta = new ERespuesta()
					{
						Codigo = respuestaRegla.Respuesta.Codigo,
						ErrorConexion = respuestaRegla.Respuesta.ErrorConexion,
						ExcepcionAplicacion = respuestaRegla.Respuesta.ExcepcionAplicacion,
						FechaRespuesta = respuestaRegla.Respuesta.FechaRespuesta,
						IdentificadorUnicoTransaccion = respuestaRegla.Respuesta.IdentificadorUnicoTransaccion,
						Mensaje = respuestaRegla.Respuesta.Mensaje,
						NumeroDocumentoOperacion = respuestaRegla.Respuesta.NumeroDocumentoOperacion,
						OperacionProcesada = respuestaRegla.Respuesta.OperacionProcesada
					};
				}
			}
			catch (WebException ex)
			{
				respuesta.Respuesta = new ERespuesta
				{
					ExcepcionAplicacion = true,
					ErrorConexion = true,
					FechaRespuesta = DateTime.Now,
					OperacionProcesada = false
				};
				if (ex.Status == WebExceptionStatus.Timeout)
				{
					respuesta.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_TIME_OUT_SERVICIO;
					respuesta.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_TIME_OUT_SERVICIO;
				}
				else
				{
					respuesta.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_ERROR_CONEXION_SERVICIO;
					respuesta.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_CONEXION_SERVICIO;
				}
				AdLogsExcepcion.GuardarLogExcepcion(ex, reglaOperacion.Auditoria, () => reglaOperacion, () => respuesta);
			}
			catch (Exception ex)
			{
				AdLogsExcepcion.GuardarLogExcepcion(ex, reglaOperacion.Auditoria, () => reglaOperacion, () => respuesta);

				respuesta.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
				respuesta.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
				respuesta.Respuesta.FechaRespuesta = DateTime.Now;
				respuesta.Respuesta.ExcepcionAplicacion = true;
				respuesta.Respuesta.IdentificadorUnicoTransaccion = string.Empty;
				respuesta.Respuesta.NumeroDocumentoOperacion = string.Empty;
			}
			return respuesta;
		}

		/// <summary>
		/// Metodo que permite almacenar las reglas de negocio en cache
		/// </summary>
		/// <param name="reglaOperacion"></param>
		/// <returns></returns>
		public static ERespuestaRegla VerificarOperacionPermitidaCache(EReglaOperacion reglaOperacion)
		{
			ERespuestaRegla respuesta = new ERespuestaRegla()
			{
				Permitido = false,
				Encriptado = false,
				Respuesta = new ERespuesta()
				{
					Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA,
					ErrorConexion = true,
					ExcepcionAplicacion = false,
					FechaRespuesta = DateTime.Now,
					IdentificadorUnicoTransaccion = reglaOperacion.Auditoria.IdentificadorUnicoOperacional,
					Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA,
					NumeroDocumentoOperacion = string.Empty,
					OperacionProcesada = false
				}
			};

			if (tablaReglasNegocio == null)
			{
				tablaReglasNegocio = new Hashtable();
				ERespuestaRegla respuestaServicio = VerificarOperacionPermitida(reglaOperacion);
				if (respuestaServicio != null)
				{
					if (!respuestaServicio.Respuesta.ExcepcionAplicacion)
					{
						tablaReglasNegocio.Add(respuestaServicio.Clave, respuestaServicio);
					}
					respuesta = respuestaServicio;
				}
			}
			else
			{
				string clave = reglaOperacion.Auditoria.CodigoCanal + reglaOperacion.Auditoria.CodigoTransaccion + reglaOperacion.Auditoria.CodigoMedioInvocacion;
				ERespuestaRegla respuestaServicio = null;
				bool consultarInformacion = false;
				if (tablaReglasNegocio.ContainsKey(clave))
				{
					respuestaServicio = (ERespuestaRegla)tablaReglasNegocio[clave];

				}
				else
				{
					consultarInformacion = true;
				}

				if (consultarInformacion)
				{
					respuestaServicio = VerificarOperacionPermitida(reglaOperacion);
					if (respuestaServicio != null)
					{
						if (!respuestaServicio.Respuesta.ExcepcionAplicacion)
						{
							tablaReglasNegocio.Add(respuestaServicio.Clave, respuestaServicio);
						}
						respuesta = respuestaServicio;
					}
				}
				else
				{
					respuesta = respuestaServicio;
				}
			}
			return respuesta;
		}
	}
}

