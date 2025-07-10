using OPERACION_WRLF_EXAMEN_2025.BusinessLogic;
using OPERACION_WRLF_EXAMEN_2025.Models;

namespace OPERACION_WRLF_EXAMEN_2025
{
    public partial class FrmAddCuenta : Form
    {
        private CuentaService _cuentaService; // Instancia del servicio de cuentas

        public FrmAddCuenta()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _cuentaService = new CuentaService(); // Inicializar el servicio
            cboTipoCuenta.SelectedIndex = 0; // Seleccionar AHO por defecto (opcional)
            cboMoneda.SelectedIndex = 0; // Seleccionar el primer valor como por defecto
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // 1. Recolectar datos y convertirlos al objeto Modelo
            if (!decimal.TryParse(txtSaldoInicial.Text.Trim(), out decimal saldoInicial))
            {
                MessageBox.Show("El Saldo Inicial debe ser un valor numérico válido.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSaldoInicial.Focus();
                return;
            }

            Cuenta nuevaCuenta = new Cuenta
            {
                NroCuenta = txtNroCuenta.Text.Trim(),
                Tipo = cboTipoCuenta.SelectedItem?.ToString(),
                Moneda = cboMoneda.SelectedItem?.ToString(),
                Nombre = txtNombreCuenta.Text.Trim(),
                Saldo = saldoInicial
            };

            // 2. Llamar a la lógica de negocio (CuentaService)
            string errorMessage;
            if (_cuentaService.RegistrarNuevaCuenta(nuevaCuenta, out errorMessage))
            {
                MessageBox.Show("Cuenta registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
            }
            else
            {
                MessageBox.Show(errorMessage, "Error al Registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // El método ValidateInputs() del formulario ya no es necesario
        // porque las validaciones se mueven a CuentaService/Validation.
        // Puedes eliminar el método ValidateInputs() de aquí.

        private void ClearInputs()
        {
            txtNroCuenta.Clear();
            cboTipoCuenta.SelectedIndex = 0; // Poner AHO como valor por defecto
            cboMoneda.SelectedIndex = 0; // Poner el primer valor como por defecto
            txtNombreCuenta.Clear();
            txtSaldoInicial.Clear();
            txtNroCuenta.Focus();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
