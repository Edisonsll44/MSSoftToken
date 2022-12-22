using System;
using System.Runtime.Serialization;

namespace MSSeguridadFraude.Entidades.Comun
{
    /// <summary>
    /// Entidad que representa los datos del entorno de siglo 21
    /// </summary>
    [DataContract]
    [Serializable]
    public class EEntorno
    {
        /// <summary>
        /// Version
        /// </summary>
        [DataMember]
        public string Version { get; set; }

        /// <summary>
        /// Usuario de entorno
        /// </summary>
        [DataMember]
        public string Usuario { get; set; }

        /// <summary>
        /// Dominio del usuario de entorno
        /// </summary>
        [DataMember]
        public int Dominio { get; set; }

        /// <summary>
        /// Nodo del usuario de entorno
        /// </summary>
        [DataMember]
        public int Nodo { get; set; }

        /// <summary>
        /// Programa Cobol llamado
        /// </summary>
        [DataMember]
        public string Programa { get; set; }

        /// <summary>
        /// Longitud de los datos de entrada
        /// </summary>
        [DataMember]
        public int LongitudEntrada { get; set; }

        /// <summary>
        /// Longitud de los datos de salida
        /// </summary>
        [DataMember]
        public int LongitudSalida { get; set; }

        /// <summary>
        /// Código de empresa
        /// </summary>
        [DataMember]
        public string CodigoEmpresa { get; set; }

        /// <summary>
        /// Código de Centro
        /// </summary>
        [DataMember]
        public string CodigoCentro { get; set; }

        /// <summary>
        /// Código de entorno
        /// </summary>
        [DataMember]
        public string CodigoEntorno { get; set; }

        /// <summary>
        /// Código de idioma
        /// </summary>
        [DataMember]
        public string CodigoIdioma { get; set; }

        /// <summary>
        /// Código de Versión
        /// </summary>
        [DataMember]
        public string CodigoVersion { get; set; }

        /// <summary>
        /// Indicador de autorización
        /// </summary>
        [DataMember]
        public string IndicadorAutoriza { get; set; }
        
        /// <summary>
        /// Identificador unico de transaccion
        /// </summary>
        [DataMember]
        public string IdUnicoTransaccion { get; set; }

        /// <summary>
        /// Tipo de transaccion (C Consulta, F Financiera)
        /// </summary>
        [DataMember]
        public string TipoTransaccion { get; set; }
    }
}
