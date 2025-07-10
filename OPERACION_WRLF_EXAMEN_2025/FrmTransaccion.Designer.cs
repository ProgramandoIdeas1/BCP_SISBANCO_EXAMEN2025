namespace OPERACION_WRLF_EXAMEN_2025
{
    partial class FrmTransaccion
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
            components = new System.ComponentModel.Container();
            lblTitulo = new Label();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            txtImporte = new TextBox();
            label2 = new Label();
            cboNroCuenta = new ComboBox();
            btnDeposito = new Button();
            btnRetiro = new Button();
            btnCerrar = new Button();
            btnLimpiar = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(38, 43);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(201, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Depósitos y Retiros";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 118);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 1;
            label1.Text = "Seleccione Cuenta:";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // txtImporte
            // 
            txtImporte.Location = new Point(166, 160);
            txtImporte.Name = "txtImporte";
            txtImporte.Size = new Size(197, 23);
            txtImporte.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(38, 168);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 4;
            label2.Text = "Monto:";
            // 
            // cboNroCuenta
            // 
            cboNroCuenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNroCuenta.FormattingEnabled = true;
            cboNroCuenta.Location = new Point(166, 118);
            cboNroCuenta.Name = "cboNroCuenta";
            cboNroCuenta.Size = new Size(197, 23);
            cboNroCuenta.TabIndex = 0;
            cboNroCuenta.SelectedIndexChanged += cboNroCuenta_SelectedIndexChanged;
            // 
            // btnDeposito
            // 
            btnDeposito.Location = new Point(193, 226);
            btnDeposito.Name = "btnDeposito";
            btnDeposito.Size = new Size(75, 23);
            btnDeposito.TabIndex = 5;
            btnDeposito.Text = "Depósito";
            btnDeposito.UseVisualStyleBackColor = true;
            btnDeposito.Click += btnDeposito_Click;
            // 
            // btnRetiro
            // 
            btnRetiro.Location = new Point(288, 226);
            btnRetiro.Name = "btnRetiro";
            btnRetiro.Size = new Size(75, 23);
            btnRetiro.TabIndex = 6;
            btnRetiro.Text = "Retiro";
            btnRetiro.UseVisualStyleBackColor = true;
            btnRetiro.Click += btnRetiro_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(288, 255);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(75, 23);
            btnCerrar.TabIndex = 8;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(193, 255);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // FrmTransaccion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuHighlight;
            ClientSize = new Size(431, 444);
            Controls.Add(btnCerrar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRetiro);
            Controls.Add(btnDeposito);
            Controls.Add(cboNroCuenta);
            Controls.Add(label2);
            Controls.Add(txtImporte);
            Controls.Add(label1);
            Controls.Add(lblTitulo);
            Name = "FrmTransaccion";
            Text = "FrmTransaccion";
            Load += FrmTransaccion_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtImporte;
        private Label label2;
        private ComboBox cboNroCuenta;
        private Button btnDeposito;
        private Button btnRetiro;
        private Button btnCerrar;
        private Button btnLimpiar;
    }
}