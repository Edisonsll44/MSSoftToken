using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.Mensajes;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.Respuesta;
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
        /// Activar TOTP
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarActivarUsuario(EOperacionATOTP operacion, string ip)
        {
            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
                    respuestaOperacion = NeOperacionST.ProcesarActivarUsuario(operacion);
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

        /// <summary>
        /// Sincronizar tiempo del servidor TOTP
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarSincronizarTiempoServidor(EOperacionATOTP operacion, string ip)
        {
            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
                    respuestaOperacion = NeOperacionST.ProcesarSincronizarTiempoServidor(operacion);
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

        /// <summary>
        /// Desbloquear Usuario
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarDesbloquearUsuario(EOperacionTOTP operacion, string ip)
        {

            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
                    respuestaOperacion = NeOperacionST.ProcesarDesbloquearUsuario(operacion);
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

        /// <summary>
        /// Inhabilitar Usuario TOTP
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarInhabilitarUsuario(EOperacionTOTP operacion, string ip)
        {

            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
                    respuestaOperacion = NeOperacionST.ProcesarInhabilitarUsuario(operacion);
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

        /// <summary>
        /// Procesar Login (Autorizar la transaccion )
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarLoginTotp(EOperacionLoginTOTP operacion, string ip)
        {

            var respuestaOperacion = new ERespuestaOperacionSoftToken()
            {
                Respuesta = new ERespuesta()
                {
                    TipoMensaje = (int)CCampos.TipoMensaje.APP
                },
                RespuestaSoftToken = new ERespuestaST()
            };

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
                    respuestaOperacion = NeOperacionST.ProcesarLoginTotp(operacion);
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
        /// <summary>
		/// Proceso para valdiar analisis de Fraude tarnsaccional
		/// </summary>
		/// <param name="operacion">EOperacionConsulta</param>
		/// <param name="ip">string</param>
		/// <returns>ERespuestaPagoContrapartida</returns>
		public static ERespuestaOperacionSoftToken ProcesarBloqueoUsuario(EOperacionTOTP operacion, string ip)
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

            try
            {
                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    respuestaOperacion.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO;
                    respuestaOperacion.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION;
                    respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);
                }
                else
                {
                    //TODO CAMBIO LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.ProcesarBloqueoUsuario(operacion);
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
            }
            return respuestaOperacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarEliminarUsuario(EOperacionTOTP operacion, string ip)
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

            try
            {
                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    respuestaOperacion.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO;
                    respuestaOperacion.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION;
                    respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);
                }
                else
                {
                    //TODO CAMBIO LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.ProcesarEliminarUsuario(operacion);
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
            }
            return respuestaOperacion;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarHabilitarUsuario(EOperacionTOTP operacion, string ip)
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

            try
            {
                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    respuestaOperacion.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO;
                    respuestaOperacion.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION;
                    respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);
                }
                else
                {
                    //TODO CAMBIO LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.ProcesarHabilitarUsuario(operacion);
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
            }
            return respuestaOperacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarRegistrarUsuario(EOperacionRegistrarTOTP operacion, string ip)
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

            try
            {
                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    respuestaOperacion.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO;
                    respuestaOperacion.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION;
                    respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);
                }
                else
                {
                    //TODO CAMBIO LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.ProcesarRegistrarUsuario(operacion);
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
            }
            return respuestaOperacion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operacion"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static ERespuestaOperacionSoftToken ProcesarEstadoUsuario(EOperacionTOTP operacion, string ip)
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

            try
            {
                if (!NeLlamarConfiguracionCentralizada.NeLlamarConfiguracionCentralizada.ConsultarServidorAutorizado(ip))
                {
                    respuestaOperacion.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_AUTORIZACION_PERSONALIZADO;
                    respuestaOperacion.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_AUTORIZACION;
                    respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;

                    Exception ex = new Exception(string.Format(CConstantes.Mensajes.MENSAJE_AUTORIZACION, ip));
                    NeLogsExcepcion.GuardarLogExcepcion(ex, operacion.Auditoria, () => operacion, () => respuestaOperacion);
                }
                else
                {
                   
                    // LLAMADA METODO 
                    respuestaOperacion = NeOperacionST.ProcesarEstadoUsuario(operacion);
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
                datoMensaje.Respuesta.CodigoEmpresaProveedor = CConstantes.Server.CODIGO_EMPRESA;

                respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);

                respuestaOperacion.Respuesta.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                respuestaOperacion.Respuesta.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;
                respuestaOperacion.Respuesta.FechaRespuesta = DateTime.Now;
                respuestaOperacion.Respuesta.ErrorConexion = objeto;
                respuestaOperacion.Respuesta.OperacionProcesada = false;
            }
            return respuestaOperacion;
        }
    }
}
