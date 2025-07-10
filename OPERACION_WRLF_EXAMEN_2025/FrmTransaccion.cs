using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPERACION_WRLF_EXAMEN_2025.BusinessLogic;
using OPERACION_WRLF_EXAMEN_2025.Models;

namespace OPERACION_WRLF_EXAMEN_2025
{
    public partial class FrmTransaccion : Form
    {
        private CuentaService _cuentaService;
        private TransaccionService _transaccionService;

        public FrmTransaccion()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            _cuentaService = new CuentaService();
            _transaccionService = new TransaccionService();

            // Cargar las cuentas en el ComboBox al iniciar el formulario
            LoadCuentasIntoComboBox();
            ClearForm(); // Llama a un nuevo método para limpiar y resetear el formulario
        }
        private void LoadCuentasIntoComboBox()
        {
            cboNroCuenta.Items.Clear(); // Limpiar ítems existentes
            List<Cuenta> cuentas = _cuentaService.ObtenerTodasLasCuentas();

            if (cuentas != null && cuentas.Count > 0)
            {
                cboNroCuenta.DataSource = cuentas;
                cboNroCuenta.DisplayMember = "NroCuenta"; // Mostrar el número de cuenta
                cboNroCuenta.ValueMember = "NroCuenta";   // Valor interno es también el número de cuenta
                cboNroCuenta.SelectedIndex = -1;          // Nada seleccionado al inicio
                cboNroCuenta.Enabled = true; // Asegurarse de que esté habilitado si hay cuentas
            }
            else
            {
                cboNroCuenta.Text = "No hay cuentas disponibles";
                cboNroCuenta.Enabled = false; // Deshabilitar si no hay cuentas
            }
        }
        private void ClearForm()
        {
            cboNroCuenta.SelectedIndex = -1; // Deseleccionar ítem en el ComboBox
            txtImporte.Clear();

            // Deshabilitar botones de transacción hasta que se seleccione una cuenta
            btnDeposito.Enabled = false;
            btnRetiro.Enabled = false;

            cboNroCuenta.Focus();
        }
        private void FrmTransaccion_Load(object sender, EventArgs e)
        {

        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            RealizarTransaccionSimplificada("Deposito");
        }

        private void cboNroCuenta_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboNroCuenta.SelectedIndex != -1)
            {
                // Una cuenta ha sido seleccionada
                btnDeposito.Enabled = true;
                btnRetiro.Enabled = true;
                txtImporte.Focus();
            }
            else
            {
                // No hay cuenta seleccionada
                btnDeposito.Enabled = false;
                btnRetiro.Enabled = false;
                txtImporte.Clear(); // Limpiar monto si no hay cuenta
            }
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            RealizarTransaccionSimplificada("Retiro");
        }
        // Nuevo método auxiliar para manejar la lógica de transacción simplificada
        private void RealizarTransaccionSimplificada(string tipoTransaccion)
        {
            // 1. Validar selección de cuenta
            if (cboNroCuenta.SelectedIndex == -1 || cboNroCuenta.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione una cuenta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNroCuenta.Focus();
                return;
            }

            // Obtener el número de cuenta de la cuenta seleccionada en el ComboBox
            string nroCuenta = cboNroCuenta.SelectedValue.ToString();

            // 2. Validar el importe
            if (!decimal.TryParse(txtImporte.Text.Trim(), out decimal importe))
            {
                MessageBox.Show("Por favor, ingrese un monto numérico válido.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return;
            }

            if (importe <= 0)
            {
                MessageBox.Show("El monto debe ser mayor a cero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtImporte.Focus();
                return;
            }

            // 3. Llamar al TransaccionService
            string errorMessage;
            if (_transaccionService.RealizarTransaccion(nroCuenta, importe, tipoTransaccion, out errorMessage))
            {
                MessageBox.Show($"{tipoTransaccion} realizado exitosamente en la cuenta {nroCuenta}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Solo limpiamos el campo de importe, la cuenta puede seguir seleccionada para otra transacción.
                txtImporte.Clear();
                txtImporte.Focus();
            }
            else
            {
                MessageBox.Show(errorMessage, $"Error al realizar {tipoTransaccion}", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ClearForm();
            // Opcional: recargar el ComboBox si limpias todo y quieres que se refresque
            // LoadCuentasIntoComboBox();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
