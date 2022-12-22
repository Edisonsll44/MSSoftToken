using System;

namespace MSSeguridadFraude.Entidades.Logs
{
    /// <summary>
    /// Entidad que permite enviar los datos para guardar en el journal transaccional 
    /// </summary>
    [Serializable]
    public class EJournalTransaccional
    {
        /// <summary>
        /// Codigo de canal
        /// </summary>
        public string CodigoCanal { get; set; }

        /// <summary>
        /// Codigo de transaccion
        /// </summary>
        public string CodigoTransaccion { get; set; }

        /// <summary>
        /// Codigo de medio de invocacion
        /// </summary>
        public string CodigoMedioInvocacion { get; set; }

        /// <summary>
        /// Udentificador unico de transaccion en el core
        /// </summary>
        public string IdTransaccionUnicoSiglo { get; set; }

        /// <summary>
        /// Numero de documento de siglo
        /// </summary>
        public string NumeroDocumentoSiglo { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de identificacion
        /// </summary>
        public string TipoIdentificacion { get; set; } = string.Empty;

        /// <summary>
        /// Identificacion del cliente
        /// </summary>
        public string IdentificacionCliente { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de producto de origen
        /// </summary>
        public string TipoProductoOrigen { get; set; } = string.Empty;

        /// <summary>
        /// Numero de producto de origen (Cuenta, tarjeta, prestamo, inversion)
        /// </summary>
        public string NumeroProductoOrigen { get; set; } = string.Empty;

        /// <summary>
        /// Alias de producto de origen
        /// </summary>
        public string AliasProductoOrigen { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de producto de destino
        /// </summary>
        public string TipoProductoDestino { get; set; } = string.Empty;

        /// <summary>
        /// Numero de producto de destino (Cuenta, tarjeta, prestamo, inversion)
        /// </summary>
        public string NumeroProductoDestino { get; set; } = string.Empty;

        /// <summary>
        /// Alias de producto de destino
        /// </summary>
        public string AliasProductoDestino { get; set; } = string.Empty;

        /// <summary>
        /// Tipo de identificacion del beneficiario
        /// </summary>
        public string TipoIdentificacionBeneficiario { get; set; } = string.Empty;

        /// <summary>
        /// Numero de identificacion del beneficiario
        /// </summary>
        public string IdentificacionBeneficiario { get; set; } = string.Empty;

        /// <summary>
        /// Codigo de la empresa de servicio
        /// </summary>
        public string IdEmpresa { get; set; } = string.Empty;

        /// <summary>
        /// Codigo de proveedor
        /// </summary>
        public string IdProveedor { get; set; } = string.Empty;

        /// <summary>
        /// Numero de documento del proveedor
        /// </summary>
        public string NumeroDocumentoProveedor { get; set; } = string.Empty;

        /// <summary>
        /// Numero de contrato
        /// </summary>
        public string NumeroContrato { get; set; } = string.Empty;

        /// <summary>
        /// Numero de cuota
        /// </summary>
        public int NumeroCuota { get; set; } = 0;

        /// <summary>
        /// Referencia o descripcion
        /// </summary>
        public string ReferenciaDescripcion { get; set; } = string.Empty;

        /// <summary>
        /// Codigo de concepto
        /// </summary>
        public string CodigoConcepto { get; set; } = string.Empty;

        /// <summary>
        /// Concepto de la transaccion
        /// </summary>
        public string Concepto { get; set; } = string.Empty;

        /// <summary>
        /// Monto en efectivo
        /// </summary>
        public decimal MontoEfectivo { get; set; } = 0;

        /// <summary>
        /// Monto de la comision
        /// </summary>
        public decimal Comision { get; set; } = 0;

        /// <summary>
        /// Monto en cheques
        /// </summary>
        public decimal MontoCheques { get; set; } = 0;

        /// <summary>
        /// Numero de libreta
        /// </summary>
        public string NumeroLibreta { get; set; } = string.Empty;

        /// <summary>
        /// Codigo de banco de origen
        /// </summary>
        public string CodBancoOrigen { get; set; } = string.Empty;

        /// <summary>
        /// Banco de origen
        /// </summary>
        public string BancoOrigen { get; set; } = string.Empty;

        /// <summary>
        /// Codigo de banco de destino
        /// </summary>
        public string CodBancoDestino { get; set; } = string.Empty;

        /// <summary>
        /// Banco de destino
        /// </summary>
        public string BancoDestino { get; set; } = string.Empty;

        /// <summary>
        /// Identificador de transaccion del cliente
        /// </summary>
        public string IdTransaccionalCliente { get; set; } = string.Empty;

        /// <summary>
        /// Ip de origen
        /// </summary>
        public string IpOrigen { get; set; } = string.Empty;

        /// <summary>
        /// Ip del servidor de procesamiento
        /// </summary>
        public string IpServidor { get; set; } = string.Empty;

        /// <summary>
        /// Usuario que ejecuta la transaccion
        /// </summary>
        public string Usuario { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de inicio de la transaccion en el core
        /// </summary>
        public DateTime? FechaHoraInicioCore { get; set; }

        /// <summary>
        /// Fecha de finalizacion de la transaccion en el core
        /// </summary>
        public DateTime? FechaHoraFinCore { get; set; }

        /// <summary>
        /// Fecha de inicio de la transaccion en el proveedor
        /// </summary>
        public DateTime? FechaHoraInicioProveedor { get; set; }

        /// <summary>
        /// Fecha de finalizacion de la transaccion en el core
        /// </summary>
        public DateTime? FechaHoraFinProveedor { get; set; }

        /// <summary>
        /// Fecha de operacion
        /// </summary>
        public DateTime? FechaOperacion { get; set; }

        /// <summary>
        /// GUI de la transaccion
        /// </summary>
        public string Guid { get; set; }

        /// <summary>
        /// Imei del dispositivo de origen
        /// </summary>
        public string HashImei { get; set; } = string.Empty;

        /// <summary>
        /// Trama de ingreso
        /// </summary>
        public string TramaIngreso { get; set; } = string.Empty;

        /// <summary>
        /// Trama de respuesta
        /// </summary>
        public string TramaSalida { get; set; } = string.Empty;

        /// <summary>
        /// Estado de la operacion
        /// </summary>
        public string EstadoOperacion { get; set; }

        /// <summary>
        /// Estado del flujo de la transaccion
        /// </summary>
        public string EstadoFlujoTransaccion { get; set; }

        /// <summary>
        /// Codigo de mensaje del core
        /// </summary>
        public string CodigoMensajeSiglo { get; set; } = string.Empty;

        /// <summary>
        /// Mensaje del core
        /// </summary>
        public string MensajeSiglo { get; set; } = string.Empty;

        /// <summary>
        /// Codigo de mensaje del proveedor
        /// </summary>
        public string CodigoMensajeProveedor { get; set; } = string.Empty;

        /// <summary>
        /// Mensaje del proveedor
        /// </summary>
        public string MensajeProveedor { get; set; } = string.Empty;

        /// <summary>
        /// Identificador unico de la transaccion de reverso
        /// </summary>
        public string IdUnicoTransaccionReverso { get; set; } = string.Empty;

        /// <summary>
        /// Codigo de la transaccion de reverso
        /// </summary>
        public string CodigoTransaccionReverso { get; set; } = string.Empty;

        /// <summary>
        /// Codido de la agencia
        /// </summary>
        public string CodigoAgencia { get; set; } = string.Empty;

        /// <summary>
        /// Codigo del centro 
        /// </summary>
        public string CodigoCentro { get; set; } = string.Empty;

        /// <summary>
        /// Accion de ingreso o actualización en el journal transaccional (false = ingreso; true = actualiza) 
        /// </summary>
        public bool Accion { get; set; }

        /// <summary>
        /// Valida si se actualiza fechas de core y proveedor
        /// </summary>
        public bool ValidaFechas { get; set; }
    }
}