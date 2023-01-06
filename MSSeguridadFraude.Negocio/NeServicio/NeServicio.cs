using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.Mensajes;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad.AnalisisFraude;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.Softoken;
using MSSeguridadFraude.Negocio.NeLogs;
using MSSeguridadFraude.Negocio.NeOperacion;
using System;
using System.Net;

namespace MSSeguridadFraude.Negocio.NeServicio
{
	/// <summary>
	/// Clase de 
	/// </summary>
	public class NeServicio
	{

		protected NeServicio()
		{

		}
		

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operacion"></param>
        /// <returns></returns>
		public static ERespuestaOperacionSoftToken ActivarTOTP(EOperacionATOTP operacion)
		{


            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            string ip = operacion.Auditoria.IdAplicacionCliente;
            operacion.Auditoria.IdentificadorServicioGUID = CUtil.ObtenerGUID();
            ERespuestaMensaje respuestaMensaje;
            EConsultaMensaje datoMensaje = new EConsultaMensaje
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                Auditoria = operacion.Auditoria
            };
            try
			{

				
                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
					var respuesta = new ERespuesta {
						Codigo= CConstantes.Excepcion.CODIGO_AUTORIZACION,
						Mensaje= CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO,
						FechaRespuesta= DateTime.Now
                    };
                
                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);
                }
                else
                {
					//TODO CAMBIO LLAMADA METODO 
					respuestaOperacion = NeOperacionST.ActivarTOTP(operacion);
                    //FIN CAMBIO
                    datoMensaje.Respuesta.Codigo = respuestaOperacion.Respuesta.Codigo;
                    datoMensaje.Respuesta.Mensaje = respuestaOperacion.Respuesta.Mensaje;
                    datoMensaje.Respuesta.OperacionProcesada = respuestaOperacion.Respuesta.OperacionProcesada;
                    datoMensaje.Respuesta.TipoMensaje = respuestaOperacion.Respuesta.TipoMensaje;
                    datoMensaje.Respuesta.CodigoEmpresaProveedor = respuestaOperacion.Respuesta.CodigoEmpresaProveedor;

                    respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);
                    respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                    respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;

                }
            }
			catch (Exception ex)
			{
                NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);

                bool objeto = ex.GetType().Name.Equals(CUtil.ObtenerNombreObjeto(new WebException()));
                datoMensaje.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_COMUN;
                datoMensaje.Respuesta.Mensaje = string.Empty;
                datoMensaje.Respuesta.OperacionProcesada = false;

                respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);

                respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;
                respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;
                respuestaOperacion.Respuesta.ErrorConexion = objeto;
                respuestaOperacion.Respuesta.OperacionProcesada = false;
                //throw;
			}
            return respuestaOperacion;
        }


        public static ERespuestaOperacionSoftToken SincronizarTiempoTOTP(EOperacionATOTP operacion)
        {
            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            string ip = operacion.Auditoria.IdAplicacionCliente;
            operacion.Auditoria.IdentificadorServicioGUID = CUtil.ObtenerGUID();
            ERespuestaMensaje respuestaMensaje;
            EConsultaMensaje datoMensaje = new EConsultaMensaje
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                Auditoria = operacion.Auditoria
            };
            try
            {


                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    var respuesta = new ERespuesta
                    {
                        Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION,
                        Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO,
                        FechaRespuesta = DateTime.Now
                    };

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);
                }
                else
                {
                    //TODO CAMBIO LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.SincronizarTiempoTOTP(operacion);
                    //FIN CAMBIO
                    datoMensaje.Respuesta.Codigo = respuestaOperacion.Respuesta.Codigo;
                    datoMensaje.Respuesta.Mensaje = respuestaOperacion.Respuesta.Mensaje;
                    datoMensaje.Respuesta.OperacionProcesada = respuestaOperacion.Respuesta.OperacionProcesada;
                    datoMensaje.Respuesta.TipoMensaje = respuestaOperacion.Respuesta.TipoMensaje;
                    datoMensaje.Respuesta.CodigoEmpresaProveedor = respuestaOperacion.Respuesta.CodigoEmpresaProveedor;

                    respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);
                    respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                    respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;
		/// <summary>
		/// Proceso para valdiar analisis de Fraude tarnsaccional
		/// </summary>
		/// <param name="operacion">EOperacionConsulta</param>
		/// <param name="ip">string</param>
		/// <returns>ERespuestaPagoContrapartida</returns>
		public static ERespuestaOperacionSoftToken ProcesarBloqueoUsuario(EOperacionesTOTP operacion, string ip)
		{
			ERespuestaOperacionSoftToken respuestaOperacion = new ERespuestaOperacionSoftToken
			{
				Respuesta = new ERespuesta(),
				RespuestaSoftToken = new ERespuestaST()
			};
			EConsultaMensaje datoMensaje = new EConsultaMensaje
			{
				Respuesta = new ERespuesta()
				{
					TipoMensaje = (int)CCampos.TipoMensaje.APP
				},
				Auditoria = operacion.Auditoria
			};
			operacion.Auditoria.IdentificadorServicioGUID = CUtil.ObtenerGUID();
			ERespuestaMensaje respuestaMensaje;

                }
            }
            catch (Exception ex)
            {
                NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);

                bool objeto = ex.GetType().Name.Equals(CUtil.ObtenerNombreObjeto(new WebException()));
                datoMensaje.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_COMUN;
                datoMensaje.Respuesta.Mensaje = string.Empty;
                datoMensaje.Respuesta.OperacionProcesada = false;

                respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);

                respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;
                respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;
                respuestaOperacion.Respuesta.ErrorConexion = objeto;
                respuestaOperacion.Respuesta.OperacionProcesada = false;
                //throw;
            }
            return respuestaOperacion;
        }


        public static ERespuestaOperacionSoftToken DesbloquearTOTP( EOperacionesTOTP operacion)
        {
            
            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            string ip = operacion.Auditoria.IdAplicacionCliente;
            operacion.Auditoria.IdentificadorServicioGUID = CUtil.ObtenerGUID();
            ERespuestaMensaje respuestaMensaje;
            EConsultaMensaje datoMensaje = new EConsultaMensaje
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                Auditoria = operacion.Auditoria
            };
            try
            {


                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    var respuesta = new ERespuesta
                    {
                        Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION,
                        Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO,
                        FechaRespuesta = DateTime.Now
                    };

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);
                }
                else
                {
                    //TODO CAMBIO LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.DesbloquearTOTP(operacion);
                    //FIN CAMBIO
                    datoMensaje.Respuesta.Codigo = respuestaOperacion.Respuesta.Codigo;
                    datoMensaje.Respuesta.Mensaje = respuestaOperacion.Respuesta.Mensaje;
                    datoMensaje.Respuesta.OperacionProcesada = respuestaOperacion.Respuesta.OperacionProcesada;
                    datoMensaje.Respuesta.TipoMensaje = respuestaOperacion.Respuesta.TipoMensaje;
                    datoMensaje.Respuesta.CodigoEmpresaProveedor = respuestaOperacion.Respuesta.CodigoEmpresaProveedor;

                    respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);
                    respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                    respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;

                }
            }
            catch (Exception ex)
            {
                NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);

                bool objeto = ex.GetType().Name.Equals(CUtil.ObtenerNombreObjeto(new WebException()));
                datoMensaje.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_COMUN;
                datoMensaje.Respuesta.Mensaje = string.Empty;
                datoMensaje.Respuesta.OperacionProcesada = false;

                respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);

                respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;
                respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;
                respuestaOperacion.Respuesta.ErrorConexion = objeto;
                respuestaOperacion.Respuesta.OperacionProcesada = false;
                //throw;
            }
            return respuestaOperacion;

        }

        public static ERespuestaOperacionSoftToken DesabilitarTOTP(EOperacionesTOTP operacion)
        {

            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };
            string ip = operacion.Auditoria.IdAplicacionCliente;
            operacion.Auditoria.IdentificadorServicioGUID = CUtil.ObtenerGUID();
            ERespuestaMensaje respuestaMensaje;
            EConsultaMensaje datoMensaje = new EConsultaMensaje
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                Auditoria = operacion.Auditoria
            };
            try
            {


                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    var respuesta = new ERespuesta
                    {
                        Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION,
                        Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO,
                        FechaRespuesta = DateTime.Now
                    };

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuesta);
                }
                else
                {
                    //TODO CAMBIO LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.DesabilitarTOTP(operacion);
                    //FIN CAMBIO
                    datoMensaje.Respuesta.Codigo = respuestaOperacion.Respuesta.Codigo;
                    datoMensaje.Respuesta.Mensaje = respuestaOperacion.Respuesta.Mensaje;
                    datoMensaje.Respuesta.OperacionProcesada = respuestaOperacion.Respuesta.OperacionProcesada;
                    datoMensaje.Respuesta.TipoMensaje = respuestaOperacion.Respuesta.TipoMensaje;
                    datoMensaje.Respuesta.CodigoEmpresaProveedor = respuestaOperacion.Respuesta.CodigoEmpresaProveedor;
					Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
					NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);
				}
				else
				{
					//TODO CAMBIO LLAMADA METODO 
					respuestaOperacion = NeOperacion.NeOperacionBloqueoUsuario.ProcesarBloqueoUsuario(operacion);
					//FIN CAMBIO
					datoMensaje.Respuesta.Codigo = respuestaOperacion.Respuesta.Codigo;
					datoMensaje.Respuesta.Mensaje = respuestaOperacion.Respuesta.Mensaje;
					datoMensaje.Respuesta.OperacionProcesada = respuestaOperacion.Respuesta.OperacionProcesada;
					datoMensaje.Respuesta.TipoMensaje = respuestaOperacion.Respuesta.TipoMensaje;
					datoMensaje.Respuesta.CodigoEmpresaProveedor = respuestaOperacion.Respuesta.CodigoEmpresaProveedor;

                    respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);
                    respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                    respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;

                }
            }
            catch (Exception ex)
            {
                NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);

                bool objeto = ex.GetType().Name.Equals(CUtil.ObtenerNombreObjeto(new WebException()));
                datoMensaje.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_COMUN;
                datoMensaje.Respuesta.Mensaje = string.Empty;
                datoMensaje.Respuesta.OperacionProcesada = false;

                respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);

                respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;
                respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;
                respuestaOperacion.Respuesta.ErrorConexion = objeto;
                respuestaOperacion.Respuesta.OperacionProcesada = false;
                //throw;
            }
            return respuestaOperacion;
        }
    }
}
