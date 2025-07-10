namespace OPERACION_WRLF_EXAMEN_2025
{
    partial class FrmAddCuenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombreCuenta = new TextBox();
            cboMoneda = new ComboBox();
            txtNroCuenta = new TextBox();
            lblNombre = new Label();
            lblMoneda = new Label();
            lblNro = new Label();
            cboTipoCuenta = new ComboBox();
            lblTipo = new Label();
            txtSaldoInicial = new TextBox();
            lblSaldo = new Label();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnCerrar = new Button();
            SuspendLayout();
            // 
            // txtNombreCuenta
            // 
            txtNombreCuenta.Location = new Point(97, 216);
            txtNombreCuenta.Name = "txtNombreCuenta";
            txtNombreCuenta.Size = new Size(249, 23);
            txtNombreCuenta.TabIndex = 13;
            // 
            // cboMoneda
            // 
            cboMoneda.FormattingEnabled = true;
            cboMoneda.Items.AddRange(new object[] { "BOB", "USD" });
            cboMoneda.Location = new Point(97, 180);
            cboMoneda.Name = "cboMoneda";
            cboMoneda.Size = new Size(249, 23);
            cboMoneda.TabIndex = 12;
            // 
            // txtNroCuenta
            // 
            txtNroCuenta.Location = new Point(97, 102);
            txtNroCuenta.Name = "txtNroCuenta";
            txtNroCuenta.Size = new Size(249, 23);
            txtNroCuenta.TabIndex = 11;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(21, 216);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 10;
            lblNombre.Text = "Nombre:";
            // 
            // lblMoneda
            // 
            lblMoneda.AutoSize = true;
            lblMoneda.Location = new Point(21, 180);
            lblMoneda.Name = "lblMoneda";
            lblMoneda.Size = new Size(54, 15);
            lblMoneda.TabIndex = 9;
            lblMoneda.Text = "Moneda:";
            // 
            // lblNro
            // 
            lblNro.AutoSize = true;
            lblNro.Location = new Point(21, 105);
            lblNro.Name = "lblNro";
            lblNro.Size = new Size(57, 15);
            lblNro.TabIndex = 8;
            lblNro.Text = "Número: ";
            // 
            // cboTipoCuenta
            // 
            cboTipoCuenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoCuenta.FormattingEnabled = true;
            cboTipoCuenta.Items.AddRange(new object[] { "AHO", "CTE" });
            cboTipoCuenta.Location = new Point(97, 140);
            cboTipoCuenta.Name = "cboTipoCuenta";
            cboTipoCuenta.Size = new Size(249, 23);
            cboTipoCuenta.TabIndex = 15;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(21, 140);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(34, 15);
            lblTipo.TabIndex = 14;
            lblTipo.Text = "Tipo:";
            // 
            // txtSaldoInicial
            // 
            txtSaldoInicial.Location = new Point(97, 255);
            txtSaldoInicial.Name = "txtSaldoInicial";
            txtSaldoInicial.Size = new Size(249, 23);
            txtSaldoInicial.TabIndex = 17;
            // 
            // lblSaldo
            // 
            lblSaldo.AutoSize = true;
            lblSaldo.Location = new Point(21, 255);
            lblSaldo.Name = "lblSaldo";
            lblSaldo.Size = new Size(73, 15);
            lblSaldo.TabIndex = 16;
            lblSaldo.Text = "Saldo Inicial:";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(21, 303);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(163, 23);
            btnGuardar.TabIndex = 18;
            btnGuardar.Text = "Guardar Cuenta";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(190, 303);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(271, 303);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 20;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmAddCuenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(376, 395);
            Controls.Add(btnCerrar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnGuardar);
            Controls.Add(txtSaldoInicial);
            Controls.Add(lblSaldo);
            Controls.Add(cboTipoCuenta);
            Controls.Add(lblTipo);
            Controls.Add(txtNombreCuenta);
            Controls.Add(cboMoneda);
            Controls.Add(txtNroCuenta);
            Controls.Add(lblNombre);
            Controls.Add(lblMoneda);
            Controls.Add(lblNro);
            Name = "FrmAddCuenta";
            Text = "FrmAddCuenta";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombreCuenta;
        private ComboBox cboMoneda;
        private TextBox txtNroCuenta;
        private Label lblNombre;
        private Label lblMoneda;
        private Label lblNro;
        private ComboBox cboTipoCuenta;
        private Label lblTipo;
        private TextBox txtSaldoInicial;
        private Label lblSaldo;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnCerrar;
    }
}