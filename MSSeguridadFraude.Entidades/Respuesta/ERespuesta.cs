using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.Respuesta
{
	/// <summary>
	/// Clase de Respuesta de Operaciones Financieras
	/// </summary>
	[Serializable]
	[DataContract]
	public class ERespuesta
	{
		/// <summary>
		/// Codigo de la Respuesta
		/// </summary>
		[DataMember]
		public string Codigo { get; set; }

		/// <summary>
		/// Mensaje de la Respuesta
		/// </summary>
		[DataMember]
		public string Mensaje { get; set; }

		/// <summary>
		/// Fecha y hora de la respuesta Obtenida
		/// </summary>
		[DataMember]
		public DateTime FechaRespuesta { get; set; }

		/// <summary>
		/// Si la respuesta se obtiene por error de conexion a algun servicio
		/// </summary>
		public bool ErrorConexion { get; set; }

		/// <summary>
		/// Si la respuesta se la obtiene por excepcion de Aplicacion
		/// </summary>
		public bool ExcepcionAplicacion { get; set; }

		/// <summary>
		/// Si la respuesta fue procesada por el servidor o proveedor sin inconvenientes
		/// </summary>
		[DataMember]
		public bool OperacionProcesada { get; set; }

		/// <summary>
		/// Si la respuesta fue procesada por el servidor o proveedor sin inconvenientes
		/// </summary>
		[DataMember]
		public string CodigoEmpresaProveedor { get; set; }

		/// <summary>
		/// Tipo Mensaje tomar de "CCampos.TipoMensaje"
		/// </summary>
		public int TipoMensaje { get; set; }
		/// <summary>
		/// Identificador Unico Transaccion
		/// </summary>
		public string IdentificadorUnicoTransaccion { get; set; }
		/// <summary>
		/// Numero Documento Operacion
		/// </summary>
		public string NumeroDocumentoOperacion { get; set; }
	}
}
