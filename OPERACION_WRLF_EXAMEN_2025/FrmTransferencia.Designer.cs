namespace OPERACION_WRLF_EXAMEN_2025
{
    partial class FrmTransferencia
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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cboCuentaOrigen = new ComboBox();
            cboCuentaDestino = new ComboBox();
            txtSaldoDisponible = new TextBox();
            txtMontoTransferir = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            grpDestino = new GroupBox();
            btnCerrar = new Button();
            grpDestino.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 31);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "CUENTA ORIGEN";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 77);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 2;
            label3.Text = "CUENTA:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 126);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 3;
            label4.Text = "SALDO DISPONIBLE:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 49);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "CUENTA:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 88);
            label6.Name = "label6";
            label6.Size = new Size(134, 15);
            label6.TabIndex = 5;
            label6.Text = "MONTO A TRANSFERIR:";
            // 
            // cboCuentaOrigen
            // 
            cboCuentaOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCuentaOrigen.FormattingEnabled = true;
            cboCuentaOrigen.Location = new Point(150, 74);
            cboCuentaOrigen.Name = "cboCuentaOrigen";
            cboCuentaOrigen.Size = new Size(185, 23);
            cboCuentaOrigen.TabIndex = 6;
            cboCuentaOrigen.SelectedIndexChanged += cboCuentaOrigen_SelectedIndexChanged;
            // 
            // cboCuentaDestino
            // 
            cboCuentaDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCuentaDestino.FormattingEnabled = true;
            cboCuentaDestino.Location = new Point(166, 41);
            cboCuentaDestino.Name = "cboCuentaDestino";
            cboCuentaDestino.Size = new Size(185, 23);
            cboCuentaDestino.TabIndex = 7;
            cboCuentaDestino.SelectedIndexChanged += cboCuentaDestino_SelectedIndexChanged;
            // 
            // txtSaldoDisponible
            // 
            txtSaldoDisponible.Enabled = false;
            txtSaldoDisponible.Location = new Point(150, 123);
            txtSaldoDisponible.Name = "txtSaldoDisponible";
            txtSaldoDisponible.Size = new Size(185, 23);
            txtSaldoDisponible.TabIndex = 8;
            // 
            // txtMontoTransferir
            // 
            txtMontoTransferir.Location = new Point(166, 85);
            txtMontoTransferir.Name = "txtMontoTransferir";
            txtMontoTransferir.Size = new Size(185, 23);
            txtMontoTransferir.TabIndex = 9;
            txtMontoTransferir.TextChanged += txtMontoTransferir_TextChanged;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(166, 129);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(185, 23);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar Transferencia";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(166, 158);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(185, 23);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // grpDestino
            // 
            grpDestino.Controls.Add(label5);
            grpDestino.Controls.Add(btnCancelar);
            grpDestino.Controls.Add(btnAceptar);
            grpDestino.Controls.Add(label6);
            grpDestino.Controls.Add(txtMontoTransferir);
            grpDestino.Controls.Add(cboCuentaDestino);
            grpDestino.Enabled = false;
            grpDestino.Location = new Point(6, 170);
            grpDestino.Name = "grpDestino";
            grpDestino.Size = new Size(372, 199);
            grpDestino.TabIndex = 12;
            grpDestino.TabStop = false;
            grpDestino.Text = "CUENTA DESTINO";
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(6, 375);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(372, 23);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // FrmTransferencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(390, 407);
            Controls.Add(btnCerrar);
            Controls.Add(grpDestino);
            Controls.Add(txtSaldoDisponible);
            Controls.Add(cboCuentaOrigen);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "FrmTransferencia";
            Text = "FrmTransferencias";
            grpDestino.ResumeLayout(false);
            grpDestino.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cboCuentaOrigen;
        private ComboBox cboCuentaDestino;
        private TextBox txtSaldoDisponible;
        private TextBox txtMontoTransferir;
        private Button btnAceptar;
        private Button btnCancelar;
        private GroupBox grpDestino;
        private Button btnCerrar;
    }
}