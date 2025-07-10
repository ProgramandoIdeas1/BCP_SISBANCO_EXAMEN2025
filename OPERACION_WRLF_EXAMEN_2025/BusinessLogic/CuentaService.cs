using Microsoft.Data.SqlClient;
using OPERACION_WRLF_EXAMEN_2025.DataAccess;
using OPERACION_WRLF_EXAMEN_2025.Models;

namespace OPERACION_WRLF_EXAMEN_2025.BusinessLogic
{
    public class CuentaService
    {
        private CuentaRepository _cuentaRepository;

        public CuentaService()
        {
            _cuentaRepository = new CuentaRepository();
        }

        public bool RegistrarNuevaCuenta(Cuenta cuenta, out string errorMessage)
        {
            errorMessage = string.Empty;

            // 1. Validaciones de datos (usando la clase Validation)
            if (string.IsNullOrWhiteSpace(cuenta.NroCuenta))
            {
                errorMessage = "El Número de Cuenta no puede estar vacío.";
                return false;
            }
            if (!Validation.IsNumeric(cuenta.NroCuenta))
            {
                errorMessage = "El Número de Cuenta solo debe contener dígitos (0-9).";
                return false;
            }
            if (string.IsNullOrWhiteSpace(cuenta.Tipo))
            {
                errorMessage = "Debe seleccionar el Tipo de Cuenta (AHO/CTE).";
                return false;
            }
            if (!Validation.IsValidAccountLength(cuenta.NroCuenta, cuenta.Tipo))
            {
                errorMessage = $"Una Cuenta {cuenta.Tipo} debe tener {(cuenta.Tipo == "CTE" ? "13" : "14")} caracteres.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(cuenta.Moneda))
            {
                errorMessage = "La Moneda no puede estar vacía.";
                return false;
            }
            if (string.IsNullOrWhiteSpace(cuenta.Nombre))
            {
                errorMessage = "El Nombre de la Cuenta no puede estar vacío.";
                return false;
            }
            if (cuenta.Saldo < 0) // No debería pasar si validamos TryParse antes, pero por si acaso
            {
                errorMessage = "El Saldo Inicial no puede ser negativo.";
                return false;
            }

            // 2. Lógica de negocio (interacción con la DAL)
            try
            {
                // Antes de insertar, verificar si la cuenta ya existe para dar un mensaje más específico
                if (_cuentaRepository.GetCuentaByNroCuenta(cuenta.NroCuenta) != null)
                {
                    errorMessage = "El número de cuenta ya existe. Por favor, use un número diferente.";
                    return false;
                }

                _cuentaRepository.InsertarCuenta(cuenta);
                return true;
            }
            catch (SqlException ex)
            {
                // Captura errores específicos de SQL (ej. duplicados si no se manejó antes)
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    errorMessage = "Error de base de datos: El número de cuenta ya existe. (Error DB)";
                }
                else
                {
                    errorMessage = $"Error de base de datos al registrar la cuenta: {ex.Message}";
                }
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"Ocurrió un error inesperado al registrar la cuenta: {ex.Message}";
                return false;
            }
        }

        public List<Cuenta> ObtenerTodasLasCuentas()
        {
            return _cuentaRepository.GetAllCuentas();
        }

        public Cuenta ObtenerCuentaPorNumero(string nroCuenta)
        {
            return _cuentaRepository.GetCuentaByNroCuenta(nroCuenta);
        }
    }
}
