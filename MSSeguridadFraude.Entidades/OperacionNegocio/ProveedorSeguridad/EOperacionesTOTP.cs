using MSSeguridadFraude.Entidades.Comun;
using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MSSeguridadFraude.Entidades.OperacionNegocio
{
    /// <summary>
    /// Datos para procesar operaciones (Bloqueo,Desbloqueo,Habilitación, Deshabilitación,Eliminación) con el proveedor VU
    /// </summary>
    [DataContract]
    [Serializable]
    public class EOperacionesTOTP
    {
        /// <summary>
        /// Datos de auditoria
        /// </summary>
        [DataMember]
        public EAuditoria Auditoria { get; set; }

        /// <summary>
        /// Datos de Entorno
        /// </summary>
        [DataMember]
        public EEntorno Entorno { get; set; }

        /// <summary>
        /// Usuario registrado en el proveedor VU => Softoken TOTP
        /// </summary>
        [DataMember]
        public EOperacionTOTP Operacion { get; set; }
    }

	/// <summary>
	/// Datos para procesar operaciones (Bloqueo,Desbloqueo,Habilitación, Deshabilitación,Eliminación) con el proveedor VU
	/// </summary>
	[DataContract]
	[Serializable]
	public class EOperacionesLoginTOTP
	{
		/// <summary>
		/// Datos de auditoria
		/// </summary>
		[DataMember]
		public EAuditoria Auditoria { get; set; }

		/// <summary>
		/// Datos de Entorno
		/// </summary>
		[DataMember]
		public EEntorno Entorno { get; set; }

		/// <summary>
		/// Usuario registrado en el proveedor VU => Softoken TOTP
		/// </summary>
		[DataMember]
		public ELoginTOTP Operacion { get; set; }
	}

	/// <summary>
	/// Datos para procesar operaciones (Bloqueo,Desbloqueo,Habilitación, Deshabilitación,Eliminación) con el proveedor VU
	/// </summary>
	[DataContract]
	[Serializable]
	public class EOperacionesRegistrarTOTP
	{
		/// <summary>
		/// Datos de auditoria
		/// </summary>
		[DataMember]
		public EAuditoria Auditoria { get; set; }

		/// <summary>
		/// Datos de Entorno
		/// </summary>
		[DataMember]
		public EEntorno Entorno { get; set; }

		/// <summary>
		/// Usuario registrado en el proveedor VU => Softoken TOTP
		/// </summary>
		[DataMember]
		public ERegistroTOTP Operacion { get; set; }
	}
}
