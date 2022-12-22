using MSSeguridadFraude.AccesoDatos.AdGestor;
using MSSeguridadFraude.AccesoDatos.AdLogs;
using MSSeguridadFraude.AccesoDatos.MSReglasNegocio;
using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.ReglasOperacion;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;

using ERespuesta = MSSeguridadFraude.Entidades.Respuesta.ERespuesta;

namespace MSSeguridadFraude.AccesoDatos.AdReglas
{
    public class AdReglasNegocio:AdComun.AdBase
    {
        private static Hashtable tablaReglasNegocio = null;

        /// <summary>
        /// Metodo que valida si la operacion esta permitida para el canal, medio de invocacion y codigo de transaccion
        /// </summary>
        /// <param name="reglaOperacion">EReglaOperacion</param>
        /// <returns>ERespuestaRegla</returns>
        private static ERespuestaRegla VerificarOperacionPermitida(EReglaOperacion reglaOperacion)
        {
            ERespuestaRegla respuesta = new ERespuestaRegla()
            {
                Permitido = false,
                Encriptado = false,
                Respuesta = new ERespuesta()
                {
                    Codigo = CConstantes.Excepcion.CODIGO_ERROR_REGLA_NO_ACTIVA,
                    ErrorConexion = true,
                    ExcepcionAplicacion = false,
                    FechaRespuesta = DateTime.Now,
                   
                    Mensaje = CConstantes.Mensajes.MENSAJE_ERROR_NO_CUMPLE_REGLAS_NEGOCIO,
                   
                    OperacionProcesada = false
                },
                Clave = reglaOperacion.Auditoria.CodigoCanal + reglaOperacion.Auditoria.CodigoTransaccion + reglaOperacion.Auditoria.CodigoMedioInvocacion 
            };
            respuesta.Respuesta = new ERespuesta();

            try
            {

                using (ServicioReglasNegocio servicio = AdGestorReglasNegocio.ConectarServicioReglasNegocio())
                {
                    Verificar regla = new Verificar
                    {
                        Auditoria = new Auditoria
                        {
                            Canal = new Canal
                            {
                                CodigoCanal = reglaOperacion.Auditoria.CodigoCanal
                            },
                            MediosInvocacion = new MedioInvocacion
                            {
                                CodigoMedioInvocacion = reglaOperacion.Auditoria.CodigoMedioInvocacion
                            },
                            TransaccionesFinancieras = new TransaccionFinanciera
                            {
                                CodigoTransaccion = reglaOperacion.Auditoria.CodigoTransaccion
                            }
                        }
                    };

                    RespuestaRegla respuestaRegla = servicio.VerificarRegla(regla);

                    if (respuestaRegla != null)
                    {
                        respuesta.Permitido = respuestaRegla.OperacionPermitida;
                        respuesta.Encriptado = respuestaRegla.OperacionEncriptacion;
                        respuesta.Respuesta.Codigo = respuestaRegla.Respuesta.Codigo;
                        respuesta.Respuesta.ErrorConexion = respuestaRegla.Respuesta.ErrorConexion;
                        respuesta.Respuesta.ExcepcionAplicacion = respuestaRegla.Respuesta.ExcepcionAplicacion;
                        respuesta.Respuesta.FechaRespuesta = respuestaRegla.Respuesta.FechaRespuesta;
                       
                        respuesta.Respuesta.Mensaje = respuestaRegla.Respuesta.Mensaje;
                        
                        respuesta.Respuesta.OperacionProcesada = respuestaRegla.Respuesta.OperacionProcesada;
                    }
                }
            }
            catch (WebException ex)
            {
                #region respuesta por excepcion web
                respuesta.Respuesta.ExcepcionAplicacion = true;
                respuesta.Respuesta.ErrorConexion = true;
                respuesta.Respuesta.FechaRespuesta = DateTime.Now;
                respuesta.Respuesta.OperacionProcesada = false;

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
                #endregion

                #region Guarda los logs de excepcion
                
                AdLogsExcepcion.GuardarLogExcepcion(ex, reglaOperacion.Auditoria);
                #endregion
            }
            catch (Exception ex)
            {
                #region Guarda los logs de excepcion
               

                AdLogsExcepcion.GuardarLogExcepcion(ex, reglaOperacion.Auditoria);
                #endregion

                #region  Construye la entidad de respuesta
                respuesta.Respuesta.Codigo = CConstantes.Excepcion.CODIGO_EXCEPCION_PRODUCIDA;
                respuesta.Respuesta.Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA;
                respuesta.Respuesta.FechaRespuesta = DateTime.Now;
                respuesta.Respuesta.ExcepcionAplicacion = true;
               
                #endregion
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
                
                    Mensaje = CConstantes.Mensajes.MENSAJE_EXCEPCION_PRODUCIDA,
                   
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
                ERespuestaRegla respuestaServicio = (ERespuestaRegla)tablaReglasNegocio[clave];
                if (respuestaServicio == null)
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
        

        /// <summary>
        /// Metodo de Consulta de filtros para las cuentas.
        /// </summary>
        /// <param name="auditoria"></param>
        /// <returns>dataset con los filtros de las cuentas</returns>
        public static DataSet ConsultarFiltrosCuenta(EAuditoria auditoria)
        {
            #region Variables Locales
            DataSet resultadoDatos = null;
            #endregion

            object[] parametros = new object[]
            {
                auditoria.CodigoCanal,
                auditoria.CodigoTransaccion,
                auditoria.CodigoMedioInvocacion,
            };
            try
            {
                #region Envio y recepcion de informacion desde sql
                resultadoDatos = ExecuteDataset(CadenaConexion[CConstantes.Base.BASE_DATOS_CATALOGO_SERVICIOS_BGR], CConstantes.Sps.PRO_CAT_CONSULTA_FILTRO_CUENTA, parametros);
                #endregion
            }
            catch (Exception ex)
            {
                #region Guarda los logs de excepcion
               

                AdLogsExcepcion.GuardarLogExcepcion(ex, auditoria);
                #endregion
            }
            return resultadoDatos;
        }

        /// <summary>
        /// Verifica la operacion obteniendo el resultado de la BD
        /// </summary>
        /// <param name="reglaVerificar"></param>
        /// <returns></returns>
        public static DataSet VerificarRegla(EReglaOperacion reglaVerificar, string tipoRegla)
        {
            #region Variables Locales
            DataSet resultadoDatos = null;
            string procedimiento;
            #endregion
            List<object> parametros = new List<object>
            {
                tipoRegla,
                reglaVerificar.Auditoria.CodigoCanal,
                reglaVerificar.Auditoria.CodigoMedioInvocacion,
                reglaVerificar.Auditoria.CodigoTransaccion
            };
            switch (tipoRegla)
            {
                case CConstantes.Server.ID_REGLA_VALIDAR_MONTO:
                    procedimiento = CConstantes.Sps.PRO_VALIDA_REGLA_MONTOS;
                    parametros.Add(reglaVerificar.Monto);
                    break;
                default:
                    procedimiento = CConstantes.Sps.PRO_VALIDA_REGLA_OPERACION;
                    break;
            }
            try
            {
                #region Envio y recepcion de informacion desde sql
                resultadoDatos = ExecuteDataset(CadenaConexion[CConstantes.Base.BASE_DATOS_CATALOGO_SERVICIOS_BGR], procedimiento, parametros.ToArray());
                #endregion
            }
            catch (Exception ex)
            {
                #region Guarda los logs de excepcion
               

                AdLogsExcepcion.GuardarLogExcepcion(ex, reglaVerificar.Auditoria);
                #endregion

                
            }
            return resultadoDatos;
        }

        /// <summary>
        /// Verifica la operacion obteniendo el resultado de la BD
        /// </summary>
        /// <param name="reglaVerificar"></param>
        /// <returns></returns>
        public static DataSet ConsultarReglas(EReglaOperacion reglaVerificar)
        {
            #region Variables Locales
            DataSet resultadoDatos = null;
          
            #endregion
            List<object> parametros = new List<object>
            {
                reglaVerificar.Auditoria.CodigoCanal,
                reglaVerificar.Auditoria.CodigoMedioInvocacion,
                reglaVerificar.Auditoria.CodigoTransaccion
            };
            try
            {
                #region Envio y recepcion de informacion desde sql
                resultadoDatos = ExecuteDataset(CadenaConexion[CConstantes.Base.BASE_DATOS_CATALOGO_SERVICIOS_BGR], CConstantes.Sps.PRO_CONSULTA_REGLAS, parametros.ToArray());
                #endregion
            }
            catch (SqlException sqlEx)
            {
                #region Guarda los logs de excepcion
               

                AdLogsExcepcion.GuardarLogExcepcion(sqlEx, reglaVerificar.Auditoria);
                #endregion
            }
            return resultadoDatos;
        }

    }
}

