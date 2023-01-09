namespace MSSeguridadFraude.Comun.Constantes
{
	/// <summary>
	/// CConstantes
	/// </summary>
	public class CConstantes
	{

		protected CConstantes()
		{

		}
		/// <summary>
		/// Constantes para variables generales del servicio
		/// </summary>
		public static class Server
		{
			/// <summary>
			/// Codigo de procesamiento correcto
			/// </summary>
			public const int CODIGO_CORRECTO = 0;


			/// <summary>
			/// Codigo de procesamiento correcto
			/// </summary>
			public const int CODIGO_CORRECTO_PROVEEDOR_FRAUDE = 1;

			/// <summary>
			/// Codigo de procesamiento correcto
			/// </summary>
			public const int CODIGO_INCORRECTO_PROVEEDOR_FRAUDE = 0;

			/// <summary>
			/// Codigo de procesamiento correcto siglo 21
			/// </summary>
			public const int CODIGO_CORRECTO_SIGLO = 0;

			/// <summary>
			/// Codigo de procesamiento correcto
			/// </summary>
			public const string CODIGO_CORRECTO_INTERFACES_MS = "0";

			/// <summary>
			/// Codigo de procesamiento correcto
			/// </summary>
			public const int CODIGO_ERROR_INFORMACION = 2;

			/// <summary>
			/// Indica el valor del parametro para consultar la bandera de log de trazabilidad
			/// </summary>
			public const string PARAMETRO_CONSULTA_LOG_TRAZABILIDAD = "ACT_LOG_TRAZA_MS";

			/// <summary>
			/// Codigo para el log de trazabilidad en la tabla LG_PARAMETROS_LOGS 
			/// </summary>
			public const string CODIGO_TIPO_LOG_TRAZABILIDAD = "LOG_TRAZABILIDAD";

			/// <summary>
			/// Indentificador Unico de MSSeguridadFraudes por defecto
			/// </summary>
			public const string INDENTIFICADOR_UNICO_MS = "00000000";

			/// <summary>
			/// Codigo de procesamiento correcto
			/// </summary>
			public const string CODIGO_CORRECTO_GENERAL = "00000";

			/// <summary>
			/// Codigo por defecto en caso de no responder informacion el catalogo de errores
			/// </summary>
			public const string CODIGO_ERROR_POR_DEFECTO = "9999";

			/// <summary>
			/// Codigo por defecto en caso de no responder informacion el catalogo de errores
			/// </summary>
			public const string CODIGO_ERROR_POR_DEFECTO_PROVEEDOR = "1000";

			/// <summary>
			/// Codigo por defecto en caso de no responder informacion el catalogo de errores
			/// </summary>
			public const string ACCION_ANALISIS_FRAUDE_TRANSACCION = "1";

			/// <summary>
			/// Codigo por defecto en caso de no responder informacion el catalogo de errores
			/// </summary>
			public const string CODIGO_ERROR_POR_DEFECTO_OPERACION = "8888";

			/// <summary>
			/// Valor por defecto para campos numericos
			/// </summary>
			public const string CODIGO_EMPRESA = "0042";

			/// <summary>
			/// Valor por defecto para campos numericos
			/// </summary>
			public const string CODIGO_EMPRESA_VU = "30014";

			#region Reglas Negocio
			/// <summary>
			/// ID UNICO DE LA REGLA EN LA BD
			/// </summary>
			public const string ID_REGLA_VALIDAR_OPERACION = "REG1";

			/// <summary>
			/// ID UNICO DE LA REGLA EN LA BD
			/// </summary>
			public const string ID_REGLA_VALIDAR_MONTO = "REG2";

			/// <summary>
			/// ID UNICO DE LA REGLA EN LA BD PARA VALIDACION DE TEXTO CLARO EN INFORMACION SENSIBLE
			/// </summary>
			public const string ID_REGLA_VALIDAR_TEXTO_CLARO = "REG3";
			#endregion
		}

		/// <summary>
		/// Constantes de los mensajes genericos en el servicio
		/// </summary>
		public static class Mensajes
		{
			/// <summary>
			/// Mensaje generico de excepcion producida
			/// </summary>
			public const string MENSAJE_EXCEPCION_PRODUCIDA = "Se ha producido una excepcion en el servicio";

			/// <summary>
			/// Mensaje de error cuando se produce time out con el servicio
			/// </summary>
			public const string MENSAJE_ERROR_CONEXION_TIME_OUT_SERVICIO = "Se agoto el tiempo de espera para la conexión con el servicio";

			/// <summary>
			/// Mensaje de error cuando se produce un error de conexion con el servicio
			/// </summary>
			public const string MENSAJE_ERROR_CONEXION_SERVICIO = "Se produjo un error de conexión con el servicio";

			/// <summary>
			/// Mensaje de error cuando se produce time out con el proveedor
			/// </summary>
			public const string MENSAJE_ERROR_CONEXION_TIME_OUT_PROVEEDOR = "Se agoto el tiempo de espera para la conexión con el proveedor";

			/// <summary>
			/// Mensaje de error cuando se produce un error de conexion con el proveedor
			/// </summary>
			public const string MENSAJE_ERROR_CONEXION_PROVEEDOR = "Se produjo un error de conexión con el proveedor";

			/// <summary>
			/// Mensaje de error por defecto
			/// </summary>
			public const string MENSAJE_ERROR_POR_DEFECTO = "EL SISTEMA NO ESTA DISPONIBLE";

			/// <summary>
			/// Mensaje de error por defecto
			/// </summary>
			public const string MENSAJE_ERROR_POR_DEFECTO_OPERACION = "OPERACION NO PERMITIDA";

			/// <summary>
			/// mensaje de procesamiento correcto
			/// </summary>
			public const string MENSAJE_CORRECTO = "INFORMACION SE PROCESO CORRECTAMENTE";

			/// <summary>
			/// mensaje de procesamiento Incorrecto
			/// </summary>
			public const string MENSAJE_INCORRECTO = "ERROR SQL: INFORMACION NO SE PROCESO CORRECTAMENTE";

			/// <summary>
			/// Mensaje generico para error en sql
			/// </summary>
			public const string MENSAJE_SQL_CONECCION = "Error en la conexion con el SQL, Mensaje : {0}, Metodo: {1}";

			/// <summary>
			/// mensaje de Encontrado
			/// </summary>
			public const string MENSAJE_ERROR_INFORMACION = "DATOS NO ENCONTRADOS";

			/// <summary>
			/// Mensaje de excepcion cuando existe alguna expresion de injeccion sql.
			/// </summary>
			public const string MENSAJE_ERROR_VALIDACION_INYECCION = "El campo {0} no es legitimo se encontro una o varias expresiones de Injeccion SQL.";

			/// <summary>
			/// Mensaje de excepcion cuando algun campo es obligatorio
			/// </summary>
			public const string MENSAJE_ERROR_CAMPO_OBLIGATORIO = "El campo {0} es obligatorio.";

			/// <summary>
			/// Mensaje para cuando el servidor no está autorizado a usar el servicio
			/// </summary>
			public const string MENSAJE_AUTORIZACION = "Servidor {0} no autorizado para usar el servicio";

			/// <summary>
			/// Mensaje para cuando el servidor no está autorizado a usar el servicio
			/// </summary>
			public const string MENSAJE_AUTORIZACION_PERSONALIZADO = "Lo Sentimos el servicio solicitado requiere activar Autorizaciones centralizadas";

			/// <summary>
			/// Mensaje de error cuando no cumple las reglas de negocio
			/// </summary>
			public const string MENSAJE_ERROR_NO_CUMPLE_REGLAS_NEGOCIO = "Operacion No Permitida de acuerdo a reglas";

			/// <summary>
			/// Error al guardar LOG de Excepción, parametros
			/// </summary>
			public const string ERROR_LOG_EXCEPCION = "Error al guardar LOG de Excepción, parametros: ";

			/// <summary>
			/// La cantidad de parámetros del SP
			/// </summary>
			public const string PARAMETROS_INCOSISTENTES_SP = "La cantidad de parámetros del SP '{0}' ({1}) no coinciden con la cantidad de valores a enviar ({2}).";

			/// <summary>
			/// Mensaje de excepcion cuando no existe informacion en Consulta
			/// </summary>
			public const string MENSAJE_ERROR_PROCESADOR_MS = "Error de conexion con el Procesador de Mensajes MS";
		}

		/// <summary>
		/// Textos Generales.
		/// </summary>
		public static class Textos
		{
			/// <summary>
			/// Catacter para filtro de consulta de mensaje
			/// </summary>
			public const string FILTRO_CONSULTA_MENSAJE = "C";

			/// <summary>
			/// Catacter para filtro de consulta de mensaje siglo
			/// </summary>
			public const string FILTRO_CONSULTA_MENSAJE_SIGLO = "S";

			/// <summary>
			/// Consulta tipo E: consulta por codigo mensaje empresa   
			/// </summary>
			public const string FILTRO_CONSULTA_MENSAJE_EMPRESA = "E";

			/// <summary>
			/// Consulta tipo P: consulta por codigo proveedor 
			/// </summary>
			public const string FILTRO_CONSULTA_MENSAJE_PROVEEDOR = "P";

			/// <summary>
			/// Tipo de evento INICIO
			/// </summary>
			public const string TIPO_EVENTO_INICIO = "INICIO";

			/// <summary>
			/// Tipo evento FIN
			/// </summary>
			public const string TIPO_EVENTO_FIN = "FIN";

			/// <summary>
			/// Codigo del tipo de evento
			/// </summary>
			public const string CODIGO_TIPO_EVENTO = "";

			/// <summary>
			/// Nombre del Log de Evento
			/// </summary>
			public const string EVENT_VIEWER = "LogMicroservicio";


		}

		/// <summary>
		/// Constantes de los tags utilizados en centralizada
		/// </summary>
		public static class TagsCentralizada
		{
			/// <summary>
			/// Tag de configuracion centralizada para consultar la url del listener Interfaces Siglo MS
			/// </summary>
			public const string URL_LISTENER_INTERFACES_SIGLO_MS = "URL_WS_INTERFACES_SIGLO_MS";

			/// <summary>
			/// Tag de configuracion centralizada para consultar la url del servicio de reglas de negocio
			/// </summary>
			public const string URL_SERVICIO_REGLAS_NEGOCIO = "URL_MS_REGLAS_NEGOCIO";


			/// <summary>
			/// Tag de configuracion centralizada para consultar la url del servicio de reglas de negocio
			/// </summary>
			public const string URL_SERVICIO_PROVEEDOR_FRAUDE = "URL_SERVICIO_PROVEEDOR_FRAUDE";


			/// <summary>
			/// Tag de configuracion centralizada para consultar la url del servicio de identificador unico de transaccion
			/// </summary>
			public const string URL_SERVICIO_IDENTIFICADOR_UNICO = "URL_SERVICIO_IDENTIFICADOR_UNICO";

			/// <summary>
			/// Tag de configuracion centralizada para consultar el token del servicio VU 
			/// para finger print
			/// </summary>
			public const string TOKEN_FINGERPRINT_PROVEEDOR = "TOKEN_FINGERPRINT_PROVEEDOR";

			/// <summary>
			/// Tag de configuracion centralizada para consultar el token del servicio VU
			/// para control de fraude
			/// </summary>
			public const string TOKEN_CONTROL_FRAUDE_PROVEEDOR = "TOKEN_CONTROL_FRAUDE_PROVEEDOR";
			/// <summary>
			/// Tag de configuracion centralizada para consultar el api key que va en la cabecera 
			/// de la peticion
			/// </summary>
			public const string TOKEN_SMS_PROVEEDOR = "TOKEN_SMS_PROVEEDOR";

			/// <summary>
			/// token acceso a softoken 
			/// </summary>
            public const string TOKEN_SOFT_TOKEN = "TOKEN_SOFT_TOKEN";
        }

		/// <summary>
		/// Nombre de Bases de datos que serán llamadas por el servicio.
		/// </summary>
		public static class Base
		{
			/// <summary>
			/// Base de Datos BGR_LOGS
			/// </summary>
			public const string BASE_DATOS_LOGS = "BDDLOGS";

			/// <summary>
			/// Base de datos Catalogos
			/// </summary>
			public const string BASE_DATOS_CATALOGO_SERVICIOS_BGR = "BDD_CATALOGOSERVICIOSBGR";

			/// <summary>
			/// Base de datos Oracle Siglo21
			/// </summary>
			public const string BASE_DATOS_SIGLO_XXI = "BDDORACLE";
		}

		/// <summary>
		/// Constantes de los store procedures de base de datos.
		/// </summary>
		public static class Sps
		{

			/// <summary>
			/// Procedimiento alamacenado que permite consultar los filtros de una cuenta antes de visualizarla
			/// </summary>
			public const string PRO_CAT_CONSULTA_FILTRO_CUENTA = "PRO_CAT_CONSULTA_FILTRO_CUENTA";


			#region Reglas Negocio
			/// <summary>
			/// Nombre del Procedimiento que valida si una operacion es permitida
			/// </summary>
			public const string PRO_VALIDA_REGLA_OPERACION = "PRC_CAT_VALIDA_REGLA_OPERACION";

			/// <summary>
			/// Nombre del Procedimiento que valida si el monto es permitido o no
			/// </summary>
			public const string PRO_VALIDA_REGLA_MONTOS = "PRC_CAT_VALIDA_REGLA_MONTOS";

			/// <summary>
			/// Nombre del Procedimiento para consulta de reglas
			/// </summary>
			public const string PRO_CONSULTA_REGLAS = "PRC_CAT_CONSULTA_REGLAS";
			#endregion

			/// <summary>
			/// Procedimiento almacenado que guarda el log de trazabilidad
			/// </summary>
			public const string PRO_LOG_TRAZABILIDAD = "PRO_LOG_TRAZABILIDAD";

			/// <summary>
			/// Procedimiento almacenado que guarda el log de excepciones
			/// </summary>
			public const string PRO_LOG_EXCEPCION = "PRO_LOG_EXCEPCION";

			/// <summary>
			/// Procedimiento almacenado que permite consultar un unico mensaje en la tabla de mensajes homologados
			/// </summary>
			public const string PRO_CAT_CONSULTA_MENSAJE_UNICO = "PRO_CAT_CONSULTA_MENSAJE_UNICO";

			/// <summary>
			/// Procedimiento almacenado que permite gurardar en el journal transaccional
			/// </summary>
			public const string PRO_LOG_JOURNAL_TRANSACCIONAL = "PRO_LOG_JOURNAL_TRANSACCIONAL";

			/// <summary>
			/// Procedimiento alamacenado que permite consultar los parametros para guardar los logs
			/// </summary>
			public const string PRO_CONSULTAR_PARAMETROS_LOGS = "PRO_CONSULTAR_PARAMETROS_LOGS";
		}

		/// <summary>
		/// Constantes de Excepciones
		/// </summary>
		public static class Excepcion
		{
			/// <summary>
			/// Codigo de error generico
			/// </summary>
			public const string CODIGO_EXCEPCION_PRODUCIDA = "-1";

			/// <summary>
			/// Codigo de error fatal generico
			/// </summary>
			public const int CODIGO_FATAL = -1;

			/// <summary>
			/// Codigo de autorizacion
			/// </summary>
			public const string CODIGO_AUTORIZACION = "999";

			/// <summary>
			/// Codigo de procesamiento Incorrecto de procedimiento
			/// </summary>
			public const string CODIGO_INCORRECTO_PRO = "-1";

			/// <summary>
			/// Codigo de exito homologado
			/// </summary>
			public const string CODIGO_EXITOSO_HOMOLOGADO = "00000";

			/// <summary>
			/// Codigo de error para indicar que el monto no esta permitido
			/// </summary>
			public const string CODIGO_ERROR_REGLA_NO_ACTIVA = "00001";

			/// <summary>
			/// Codigo de error para indicar que se produjo un error de conexion con el servicio
			/// </summary>
			public const string CODIGO_ERROR_CONEXION_SERVICIO = "00016";

			/// <summary>
			/// Codigo de error para indicar que se produjo un time out con el servicio
			/// </summary>
			public const string CODIGO_ERROR_TIME_OUT_SERVICIO = "00017";

			/// <summary>
			/// Codigo de error para indicar que no hay datos para mostrar
			/// </summary>
			public const string CODIGO_ERROR_SIN_DATOS = "00018";

			/// <summary>
			/// Codigo de error para indicar que la entidad de auditoria esta incompleta o nula
			/// </summary>
			public const string CODIGO_ERROR_AUDITORIA_INCOMPLETA = "00900";

			/// <summary>
			/// Codigo de error para indicar que la identificacion ingresada no es válida
			/// </summary>
			public const string CODIGO_ERROR_IDENTIFICACION_INVALIDA = "00901";

			/// <summary>
			/// Codigo de error para indicar que el codigo de canal ingresado no es válido
			/// </summary>
			public const string CODIGO_ERROR_CANAL_INVALIDO = "00902";

			/// <summary>
			/// Codigo de error para indicar que el codigo de transaccion no es valido
			/// </summary>
			public const string CODIGO_ERROR_TRANSACCION_INVALIDO = "00903";

			/// <summary>
			/// Codigo de error para indicar que el medio de invocacion no es valido
			/// </summary>
			public const string CODIGO_ERROR_MEDIO_INVOCACION_INVALIDO = "00904";

			/// <summary>
			/// Codigo de error para indicar que el entorno no es valido
			/// </summary>
			public const string CODIGO_ERROR_ENTORNO_INVALIDO = "00905";

			/// <summary>
			/// Codigo de error para indicar que el indicador de accion no es valido
			/// </summary>
			public const string CODIGO_ERROR_INDICADOR_ACCION_INVALIDO = "00906";

			/// <summary>
			/// Codigo de error para indicar que el tipo de identificacion no es valido
			/// </summary>
			public const string CODIGO_ERROR_TIPO_IDENTIFICACION_INVALIDO = "00908";

			/// <summary>
			/// Codigo de error para indicar que el tipo de transaccion es vacia en el entorno
			/// </summary>
			public const string CODIGO_ERROR_TIPO_TRANSACCION_VACIA = "00914";

			/// <summary>
			/// Codigo para el error producido por time out con el proveedor
			/// </summary>
			public const string CODIGO_ERROR_CONEXION_TIME_OUT_PROVEEDOR = "00915";

			/// <summary>
			/// Codigo de error de conexion con el proveedor
			/// </summary>
			public const string CODIGO_ERROR_CONEXION_PROVEEDOR = "00916";

			/// <summary>
			/// Codigo de excepcion por defecto
			/// </summary>
			public const string CODIGO_EXCEPCION_COMUN = "00999";

			/// <summary>
			/// Codigo para consultar el mensaje de campo obligatorio
			/// </summary>
			public const string CODIGO_EXCEPCION_CAMPO_OBLIGATORIO = "01000";

			/// <summary>
			/// Codigo de error generico inyeccion SQL
			/// </summary>
			public const string CODIGO_EXCEPCION_INYECCIONSQL = "01001";

			/// <summary>
			/// Codigo de error general para conexion con servicios
			/// </summary>
			public const string CODIGO_ERROR_CONEXION_SERVICIOS = "03000";

			/// <summary>
			/// Codigo de error para interfaces siglo
			/// </summary>
			public const string CODIGO_ERROR_INTERFACES_SIGLO = "03001";



		}

		/// <summary>
		/// Constantes de parametros para el procesador de mensajes
		/// </summary>
		public static class ComunicacionSiglo
		{
			/// <summary>
			/// Nombre de la aplicacion en BGR_INTERFACES_SIGLO
			/// </summary>
			public const string NOMBRE_APLICACION_MICROSERVICIOS = "MICROSERV";

			/// <summary>
			/// Codigo del canal para BGR_INTERFACES_SIGLO
			/// </summary>
			public const string CODIGO_CANAL_INTERFACES_SIGLO = "MICROSERV";
		}

		/// <summary>
		/// Constantes para encriptar y desencriptar
		/// </summary>
		public static class Seguridad
		{
			/// <summary>
			/// VECTOR
			/// </summary>
			public const string VECTOR = "SECRETOMS";

			/// <summary>
			/// LLAVE
			/// </summary>
			public const string LLAVE = "LLAVEMS";

			/// <summary>
			/// SALT
			/// </summary>
			public const string SALT = "SALTMS";
		}

		/// <summary>
		/// Constantes para Trazas
		/// </summary>
		public static class Trazas
		{
			/// <summary>
			/// INICIOMETODO
			/// </summary>
			public const string INICIOMETODO = "Inicio";

			/// <summary>
			/// FINMETODO
			/// </summary>
			public const string FINMETODO = "Fin";

			/// <summary>
			/// CARACTERMAYORQUE
			/// </summary>
			public const string CARACTERMAYORQUE = ">";

			/// <summary>
			/// CARACTERMENORQUE
			/// </summary>
			public const string CARACTERMENORQUE = "<";

			/// <summary>
			/// MAYORQUESERIALIZADO
			/// </summary>
			public const string MAYORQUESERIALIZADO = "&gt;";

			/// <summary>
			/// MENORQUESERIALIZADO
			/// </summary>
			public const string MENORQUESERIALIZADO = "&lt;";
		}

		/// <summary>
		/// Constantes comunes para la llamada a Siglo
		/// </summary>
		public static class Siglo
		{
			#region cabecera
			/// <summary>
			/// Nombre del programa Siglo a invocar
			/// </summary>
			public const string PROGRAMA_XXX8888 = "XXX8888";

			/// <summary>
			/// Identificador de tipo de transacción en Siglo21 (C: No financieros; F: Financieros)
			/// </summary>
			public const string TIPO_TRANSACCION = "C";

			/// <summary>
			/// transaccion para logueo de aplicacion
			/// </summary>
			public const string COM_SC88_S21_BGR = "SC88";
			#endregion
		}

		public static class Caracteres
		{
			public const char DOSPUNTOS = ':';
		}

		public static class Formatos
		{
			public const string JsonFormatHeader = "application/json; charset=utf-8";
			public const string ContentType = "Content-Type";
			public const string WwwFormUrlEncodeHeader = "plication/x-www-form-urlencoded";

        }

		public static class Configuraciones
		{
			public const string ConfiguracionesServicioWeb = "ConfiguracionesServicioWeb";
			public const string TimeOutSertvicio = "TimeOutServicioProveedorSecurity";
			

        }

		public static class EndPoints
		{
			public const string EndPointEliminar = "EndPointEliminar";
            public const string EndPointMetodoA = "EndPointA";
            public const string EndPointMetodoDesbloquear = "EndPointDesbloquear";
            public const string EndPointMetodoDesabilitar = "EndPointDesabilitar";
            public const string EndPointBloqueoUsuario = "EndPointBloqueoUsuario";
			public const string EndPointEstadoUsuario = "EndPointEstadoUsuario";
			public const string EndPointRegistrar = "EndPointRegistrar";
			public const string EndPointHabilitarUsuario = "EndPointHabilitarUsuario";
			public const string EndPointLogin= "EndPointLogin";

        }
	}
}
