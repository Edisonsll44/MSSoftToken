﻿using MSSeguridadFraude.Entidades.OperacionNegocio.Softoken;
using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.OperacionNegocio
{
	/// <summary>
	/// Datos para procesar operaciones (Bloqueo,Desbloqueo,Habilitación, Deshabilitación,Eliminación) con el proveedor VU
	/// </summary>
	[DataContract]
	[Serializable]
	public class EOperacionTOTP : EOperacionBase
	{


		/// <summary>
		/// Usuario registrado en el proveedor VU => Softoken TOTP
		/// </summary>
		[DataMember]
		public EOperacionUsuarioTOTP Operacion { get; set; }
	}
}
