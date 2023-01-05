using MSSeguridadFraude.Comun.Constantes;
using MSSeguridadFraude.Comun.Enumeraciones;
using MSSeguridadFraude.Comun.Utilitarios;
using MSSeguridadFraude.Entidades.Mensajes;
using MSSeguridadFraude.Entidades.OperacionNegocio;
using MSSeguridadFraude.Entidades.OperacionNegocio.ProveedorSeguridad.AnalisisFraude;
using MSSeguridadFraude.Entidades.Respuesta;
using MSSeguridadFraude.Entidades.Respuesta.RespuestaProveedor.AnalisisFraude;
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
		public static ERespuesta ActivarTOTP(EOperacionActivarTOTP operacion)
		{


            var respuestaOperacion = new ERespuesta();
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
                    datoMensaje.Respuesta.Codigo = respuestaOperacion.Codigo;
                    datoMensaje.Respuesta.Mensaje = respuestaOperacion.Mensaje;
                    datoMensaje.Respuesta.OperacionProcesada = respuestaOperacion.OperacionProcesada;
                    datoMensaje.Respuesta.TipoMensaje = respuestaOperacion.TipoMensaje;
                    datoMensaje.Respuesta.CodigoEmpresaProveedor = respuestaOperacion.CodigoEmpresaProveedor;

                    respuestaMensaje = NeMensajes.NeMensajes.ConsultarMensaje(datoMensaje);
                    respuestaOperacion.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                    respuestaOperacion.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;

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

                respuestaOperacion.Codigo = respuestaMensaje.RespuestaMensaje.CodigoMensajeAplicacion;
                respuestaOperacion.Mensaje = respuestaMensaje.RespuestaMensaje.MensajeAplicacion;
                respuestaOperacion.FechaRespuesta = DateTime.Now;
                respuestaOperacion.ErrorConexion = objeto;
                respuestaOperacion.OperacionProcesada = false;
                //throw;
			}
            return respuestaOperacion;
        }


        public static ERespuesta SincronizarTiempoTOTP(EOperacionActivarTOTP operacion)
        {

            return null;
        }


        public static ERespuesta DesbloquearTOTP( EOperacionesTOTP operacion)
        {

            return null;
        }

        public static ERespuesta DesabilitarTOTP(EOperacionesTOTP operacion)
        {

            return null;
        }
    }
}
