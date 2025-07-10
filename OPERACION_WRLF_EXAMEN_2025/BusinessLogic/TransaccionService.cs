using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using OPERACION_WRLF_EXAMEN_2025.DataAccess;
using OPERACION_WRLF_EXAMEN_2025.Models;

namespace OPERACION_WRLF_EXAMEN_2025.BusinessLogic
{
    public class TransaccionService
    {
        private CuentaRepository _cuentaRepository;
        private MovimientoRepository _movimientoRepository;

        public TransaccionService()
        {
            _cuentaRepository = new CuentaRepository();
            _movimientoRepository = new MovimientoRepository();
        }

        public bool RealizarTransaccion(string nroCuenta, decimal importe, string tipoTransaccion, out string errorMessage)
        {
            errorMessage = string.Empty;

            // 1. Validaciones de entrada
            if (string.IsNullOrWhiteSpace(nroCuenta))
            {
                errorMessage = "El número de cuenta no puede estar vacío.";
                return false;
            }
            if (importe <= 0)
            {
                errorMessage = "El importe debe ser mayor a cero.";
                return false;
            }
            if (tipoTransaccion != "Deposito" && tipoTransaccion != "Retiro")
            {
                errorMessage = "Tipo de transacción inválido. Debe ser 'Deposito' o 'Retiro'.";
                return false;
            }

            // 2. Obtener la cuenta
            Cuenta cuenta = _cuentaRepository.GetCuentaByNroCuenta(nroCuenta);
            if (cuenta == null)
            {
                errorMessage = "La cuenta no existe.";
                return false;
            }

            // 3. Lógica de negocio específica para Retiro
            if (tipoTransaccion == "Retiro" && cuenta.Saldo < importe)
            {
                errorMessage = "Saldo insuficiente para realizar el retiro.";
                return false;
            }

            // 4. Iniciar la transacción de base de datos para asegurar atomicidad
            // Esto es crucial: si una parte falla, todo se revierte.
            using (SqlConnection connection = DbHelper.GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    decimal nuevoSaldo = cuenta.Saldo;
                    string tipoMovimiento = ""; // D-Debito, A-Abono

                    if (tipoTransaccion == "Deposito")
                    {
                        nuevoSaldo += importe;
                        tipoMovimiento = "A"; // Abono
                    }
                    else if (tipoTransaccion == "Retiro")
                    {
                        nuevoSaldo -= importe;
                        tipoMovimiento = "D"; // Debito
                    }

                    // Actualizar saldo de la cuenta
                    // Usamos un comando con la transacción
                    string updateQuery = "UPDATE CUENTA SET SALDO = @NuevoSaldo WHERE NRO_CUENTA = @NroCuenta";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                    {
                        updateCommand.Parameters.AddWithValue("@NuevoSaldo", nuevoSaldo);
                        updateCommand.Parameters.AddWithValue("@NroCuenta", nroCuenta);
                        updateCommand.ExecuteNonQuery();
                    }

                    // Registrar movimiento
                    Movimiento movimiento = new Movimiento
                    {
                        NroCuenta = nroCuenta,
                        Fecha = DateTime.Now,
                        Tipo = tipoMovimiento,
                        Importe = importe
                    };

                    // Usamos un comando con la transacción
                    string insertMovimientoQuery = "INSERT INTO MOVIMIENTO (NRO_CUENTA, FECHA, TIPO, IMPORTE) VALUES (@NroCuentaMov, @FechaMov, @TipoMov, @ImporteMov)";
                    using (SqlCommand insertMovimientoCommand = new SqlCommand(insertMovimientoQuery, connection, transaction))
                    {
                        insertMovimientoCommand.Parameters.AddWithValue("@NroCuentaMov", movimiento.NroCuenta);
                        insertMovimientoCommand.Parameters.AddWithValue("@FechaMov", movimiento.Fecha);
                        insertMovimientoCommand.Parameters.AddWithValue("@TipoMov", movimiento.Tipo);
                        insertMovimientoCommand.Parameters.AddWithValue("@ImporteMov", movimiento.Importe);
                        insertMovimientoCommand.ExecuteNonQuery();
                    }

                    // Si todo fue bien, confirmar la transacción
                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    // Revertir la transacción si hay un error de SQL
                    transaction.Rollback();
                    errorMessage = $"Error de base de datos al realizar la transacción: {ex.Message}";
                    return false;
                }
                catch (Exception ex)
                {
                    // Revertir la transacción si hay cualquier otro error
                    transaction.Rollback();
                    errorMessage = $"Ocurrió un error inesperado al realizar la transacción: {ex.Message}";
                    return false;
                }
            }
        }
        public bool RealizarTransferencia(string nroCuentaOrigen, string? nroCuentaDestino, decimal monto, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (nroCuentaOrigen == nroCuentaDestino)
            {
                errorMessage = "La cuenta origen y la cuenta destino no pueden ser la misma.";
                return false;
            }

            // Obtener las cuentas (ya lo validamos en UI, pero es buena práctica aquí también)
            Cuenta cuentaOrigen = _cuentaRepository.GetCuentaByNroCuenta(nroCuentaOrigen);
            if (cuentaOrigen == null)
            {
                errorMessage = "La cuenta origen no existe."; // Podría ser un error si alguien manipula la UI
                return false;
            }
            Cuenta cuentaDestino = _cuentaRepository.GetCuentaByNroCuenta(nroCuentaDestino);
            if (cuentaDestino == null)
            {
                errorMessage = "La cuenta destino no existe.";
                return false;
            }

            if (cuentaOrigen.Saldo < monto)
            {
                errorMessage = "Saldo insuficiente en la cuenta origen para la transferencia.";
                return false;
            }

            using (SqlConnection connection = DbHelper.GetConnection())
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Debitar de la cuenta origen
                    decimal nuevoSaldoOrigen = cuentaOrigen.Saldo - monto;
                    string updateOrigenQuery = "UPDATE CUENTA SET SALDO = @NuevoSaldoOrigen WHERE NRO_CUENTA = @NroCuentaOrigen";
                    using (SqlCommand cmdOrigen = new SqlCommand(updateOrigenQuery, connection, transaction))
                    {
                        cmdOrigen.Parameters.AddWithValue("@NuevoSaldoOrigen", nuevoSaldoOrigen);
                        cmdOrigen.Parameters.AddWithValue("@NroCuentaOrigen", nroCuentaOrigen);
                        cmdOrigen.ExecuteNonQuery();
                    }

                    // 2. Registrar movimiento de débito para la cuenta origen
                    Movimiento movimientoOrigen = new Movimiento
                    {
                        NroCuenta = nroCuentaOrigen,
                        Fecha = DateTime.Now,
                        Tipo = "D", // Debito
                        Importe = monto
                    };
                    string insertMovOrigenQuery = "INSERT INTO MOVIMIENTO (NRO_CUENTA, FECHA, TIPO, IMPORTE) VALUES (@NroCuentaMovOrigen, @FechaMovOrigen, @TipoMovOrigen, @ImporteMovOrigen)";
                    using (SqlCommand cmdMovOrigen = new SqlCommand(insertMovOrigenQuery, connection, transaction))
                    {
                        cmdMovOrigen.Parameters.AddWithValue("@NroCuentaMovOrigen", movimientoOrigen.NroCuenta);
                        cmdMovOrigen.Parameters.AddWithValue("@FechaMovOrigen", movimientoOrigen.Fecha);
                        cmdMovOrigen.Parameters.AddWithValue("@TipoMovOrigen", movimientoOrigen.Tipo);
                        cmdMovOrigen.Parameters.AddWithValue("@ImporteMovOrigen", movimientoOrigen.Importe);
                        cmdMovOrigen.ExecuteNonQuery();
                    }

                    // 3. Acreditar a la cuenta destino
                    decimal nuevoSaldoDestino = cuentaDestino.Saldo + monto;
                    string updateDestinoQuery = "UPDATE CUENTA SET SALDO = @NuevoSaldoDestino WHERE NRO_CUENTA = @NroCuentaDestino";
                    using (SqlCommand cmdDestino = new SqlCommand(updateDestinoQuery, connection, transaction))
                    {
                        cmdDestino.Parameters.AddWithValue("@NuevoSaldoDestino", nuevoSaldoDestino);
                        cmdDestino.Parameters.AddWithValue("@NroCuentaDestino", nroCuentaDestino);
                        cmdDestino.ExecuteNonQuery();
                    }

                    // 4. Registrar movimiento de abono para la cuenta destino
                    Movimiento movimientoDestino = new Movimiento
                    {
                        NroCuenta = nroCuentaDestino,
                        Fecha = DateTime.Now,
                        Tipo = "A", // Abono
                        Importe = monto
                    };
                    string insertMovDestinoQuery = "INSERT INTO MOVIMIENTO (NRO_CUENTA, FECHA, TIPO, IMPORTE) VALUES (@NroCuentaMovDestino, @FechaMovDestino, @TipoMovDestino, @ImporteMovDestino)";
                    using (SqlCommand cmdMovDestino = new SqlCommand(insertMovDestinoQuery, connection, transaction))
                    {
                        cmdMovDestino.Parameters.AddWithValue("@NroCuentaMovDestino", movimientoDestino.NroCuenta);
                        cmdMovDestino.Parameters.AddWithValue("@FechaMovDestino", movimientoDestino.Fecha);
                        cmdMovDestino.Parameters.AddWithValue("@TipoMovDestino", movimientoDestino.Tipo);
                        cmdMovDestino.Parameters.AddWithValue("@ImporteMovDestino", movimientoDestino.Importe);
                        cmdMovDestino.ExecuteNonQuery();
                    }

                    // Confirmar la transacción si todo fue exitoso
                    transaction.Commit();
                    return true;
                }
                catch (SqlException ex)
                {
                    transaction.Rollback();
                    errorMessage = $"Error de base de datos al realizar la transferencia: {ex.Message}";
                    return false;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    errorMessage = $"Ocurrió un error inesperado al realizar la transferencia: {ex.Message}";
                    return false;
                }
            }
        }
    }
}
