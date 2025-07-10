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
    public partial class FrmTransferencia : Form
    {
        private CuentaService _cuentaService;
        private TransaccionService _transaccionService; // Lo necesitaremos
        private Cuenta _cuentaOrigenSeleccionada; // Para almacenar la cuenta origen

        public FrmTransferencia()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            _cuentaService = new CuentaService();
            _transaccionService = new TransaccionService(); // Inicializar

            LoadCuentasIntoComboBoxes(); // Nuevo método para cargar ambos ComboBoxes
            ClearForm(); // Inicializa el estado del formulario
            CheckEnableAcceptButton();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearForm(); // Limpia todos los campos
            LoadCuentasIntoComboBoxes(); // Recarga las cuentas por si se ha modificado algo
        }
        private void CheckEnableAcceptButton()
        {
            // El botón btnAceptar se habilitará si:
            // 1. Hay una cuenta de origen seleccionada.
            // 2. Hay una cuenta de destino seleccionada.
            // 3. El campo de monto no está vacío y es un número válido.

            bool origenSeleccionado = cboCuentaOrigen.SelectedIndex != -1;
            bool destinoSeleccionado = cboCuentaDestino.SelectedIndex != -1;
            bool montoValido = decimal.TryParse(txtMontoTransferir.Text.Trim(), out _);

            // Habilitar btnAceptar solo si todas las condiciones son verdaderas
            btnAceptar.Enabled = origenSeleccionado && destinoSeleccionado && montoValido;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones
            if (_cuentaOrigenSeleccionada == null)
            {
                MessageBox.Show("Debe seleccionar una cuenta de origen.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCuentaOrigen.Focus();
                return;
            }

            if (cboCuentaDestino.SelectedIndex == -1 || cboCuentaDestino.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una cuenta de destino.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCuentaDestino.Focus();
                return;
            }

            string? nroCuentaDestino = cboCuentaDestino.SelectedValue.ToString();

            if (!decimal.TryParse(txtMontoTransferir.Text.Trim(), out decimal monto))
            {
                MessageBox.Show("El monto a transferir debe ser un valor numérico válido.", "Error de Entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoTransferir.Focus();
                return;
            }

            if (monto <= 0)
            {
                MessageBox.Show("El monto a transferir debe ser mayor a cero.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoTransferir.Focus();
                return;
            }

            // Validación clave: monto menor o igual al saldo disponible de la cuenta origen
            if (monto > _cuentaOrigenSeleccionada.Saldo)
            {
                MessageBox.Show("El monto a transferir excede el saldo disponible en la cuenta origen.", "Saldo Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMontoTransferir.Focus();
                return;
            }

            // 2. Ejecutar la transferencia (usaremos un nuevo método en TransaccionService)
            string errorMessage;
            if (_transaccionService.RealizarTransferencia(_cuentaOrigenSeleccionada.NroCuenta, nroCuentaDestino, monto, out errorMessage))
            {
                MessageBox.Show($"Transferencia de {monto:N2} realizada exitosamente de {cboCuentaOrigen.SelectedValue} a {cboCuentaDestino.SelectedValue}.", "Transferencia Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(); // Limpiar el formulario después de una transferencia exitosa
                LoadCuentasIntoComboBoxes(); // Recargar los ComboBoxes para reflejar saldos actualizados
            }
            else
            {
                MessageBox.Show(errorMessage, "Error en la Transferencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCuentasIntoComboBoxes()
        {
            // Primero, desvincular el DataSource para poder limpiar los ítems si es necesario
            cboCuentaOrigen.DataSource = null;
            cboCuentaDestino.DataSource = null;

            // Ahora sí, puedes limpiar Items (aunque con DataSource = null, a menudo no es estrictamente necesario,
            // es una buena práctica para asegurar que no queden ítems residuales si la lista de cuentas está vacía)
            cboCuentaOrigen.Items.Clear();
            cboCuentaDestino.Items.Clear();

            List<Cuenta> cuentas = _cuentaService.ObtenerTodasLasCuentas();

            if (cuentas != null && cuentas.Count > 0)
            {
                // Cargar cboCuentaOrigen
                cboCuentaOrigen.DataSource = new List<Cuenta>(cuentas); // Nueva instancia para no afectar cboCuentaDestino
                cboCuentaOrigen.DisplayMember = "NroCuenta";
                cboCuentaOrigen.ValueMember = "NroCuenta";
                cboCuentaOrigen.SelectedIndex = -1;
                cboCuentaOrigen.Enabled = true;

                // Cargar cboCuentaDestino
                cboCuentaDestino.DataSource = new List<Cuenta>(cuentas); // Otra nueva instancia
                cboCuentaDestino.DisplayMember = "NroCuenta";
                cboCuentaDestino.ValueMember = "NroCuenta";
                cboCuentaDestino.SelectedIndex = -1;
                cboCuentaDestino.Enabled = true; // Habilitar siempre, la validación se hará después
            }
            else
            {
                cboCuentaOrigen.Text = "No hay cuentas disponibles";
                cboCuentaOrigen.Enabled = false;
                cboCuentaDestino.Text = "No hay cuentas disponibles";
                cboCuentaDestino.Enabled = false;
            }
        }
        private void ClearForm()
        {
            cboCuentaOrigen.SelectedIndex = -1;
            cboCuentaDestino.SelectedIndex = -1;
            txtSaldoDisponible.Clear();
            txtMontoTransferir.Clear();

            _cuentaOrigenSeleccionada = null; // Limpiar la cuenta origen seleccionada

            grpDestino.Enabled = false; // Deshabilitar sección de destino
            //btnAceptar.Enabled = false; // Deshabilitar botón de aceptar

            cboCuentaOrigen.Focus();
            CheckEnableAcceptButton();
        }

        private void cboCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCuentaOrigen.SelectedIndex != -1)
            {
                _cuentaOrigenSeleccionada = (Cuenta)cboCuentaOrigen.SelectedItem;
                txtSaldoDisponible.Text = _cuentaOrigenSeleccionada.Saldo.ToString("N2");

                // Habilitar la sección de destino y el botón Aceptar
                grpDestino.Enabled = true;
                //btnAceptar.Enabled = true; // Se habilitará solo si monto y destino son válidos
                txtMontoTransferir.Focus();

                // Asegurarse de que la cuenta origen no pueda ser la misma que la destino
                ActualizarCuentasDestinoDisponibles(_cuentaOrigenSeleccionada.NroCuenta);
            }
            else
            {
                txtSaldoDisponible.Clear();
                _cuentaOrigenSeleccionada = null;
                grpDestino.Enabled = false;
                btnAceptar.Enabled = false;
                txtMontoTransferir.Clear();
                cboCuentaDestino.SelectedIndex = -1;
            }
            CheckEnableAcceptButton();
        }
        // Nuevo método auxiliar para filtrar la cuenta de origen de la lista de destino
        private void ActualizarCuentasDestinoDisponibles(string nroCuentaOrigen)
        {
            List<Cuenta> todasCuentas = _cuentaService.ObtenerTodasLasCuentas();
            List<Cuenta> cuentasDestinoDisponibles = new List<Cuenta>();

            foreach (Cuenta c in todasCuentas)
            {
                if (c.NroCuenta != nroCuentaOrigen)
                {
                    cuentasDestinoDisponibles.Add(c);
                }
            }

            // Primero, desvincular el DataSource
            cboCuentaDestino.DataSource = null;
            // Luego, limpiar los ítems (aunque DataSource = null ya los quita visualmente)
            cboCuentaDestino.Items.Clear();

            if (cuentasDestinoDisponibles.Count > 0)
            {
                cboCuentaDestino.DataSource = cuentasDestinoDisponibles;
                cboCuentaDestino.DisplayMember = "NroCuenta";
                cboCuentaDestino.ValueMember = "NroCuenta";
                cboCuentaDestino.SelectedIndex = -1; // Nada seleccionado por defecto
                cboCuentaDestino.Enabled = true;
            }
            else
            {
                cboCuentaDestino.Text = "No hay otras cuentas";
                cboCuentaDestino.Enabled = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }

        private void cboCuentaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckEnableAcceptButton();
        }

        private void txtMontoTransferir_TextChanged(object sender, EventArgs e)
        {
            CheckEnableAcceptButton();
        }
    }
}
