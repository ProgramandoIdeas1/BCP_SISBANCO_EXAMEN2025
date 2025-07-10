namespace OPERACION_WRLF_EXAMEN_2025
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnTestConexion = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            btnAbrirAddCuenta = new Button();
            btnTransacciones = new Button();
            btnTransf = new Button();
            SuspendLayout();
            // 
            // btnTestConexion
            // 
            btnTestConexion.Location = new Point(54, 40);
            btnTestConexion.Name = "btnTestConexion";
            btnTestConexion.Size = new Size(152, 28);
            btnTestConexion.TabIndex = 0;
            btnTestConexion.Text = "Probar Conexion DB";
            btnTestConexion.UseVisualStyleBackColor = true;
            btnTestConexion.Click += btnTestConexion_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // btnAbrirAddCuenta
            // 
            btnAbrirAddCuenta.Location = new Point(39, 74);
            btnAbrirAddCuenta.Name = "btnAbrirAddCuenta";
            btnAbrirAddCuenta.Size = new Size(184, 28);
            btnAbrirAddCuenta.TabIndex = 8;
            btnAbrirAddCuenta.Text = "Registrar Cuenta";
            btnAbrirAddCuenta.UseVisualStyleBackColor = true;
            btnAbrirAddCuenta.Click += btnAbrirAddCuenta_Click;
            // 
            // btnTransacciones
            // 
            btnTransacciones.Location = new Point(39, 108);
            btnTransacciones.Name = "btnTransacciones";
            btnTransacciones.Size = new Size(184, 28);
            btnTransacciones.TabIndex = 9;
            btnTransacciones.Text = "Depositos / Retiros";
            btnTransacciones.UseVisualStyleBackColor = true;
            btnTransacciones.Click += btnTransacciones_Click;
            // 
            // btnTransf
            // 
            btnTransf.Location = new Point(39, 142);
            btnTransf.Name = "btnTransf";
            btnTransf.Size = new Size(184, 28);
            btnTransf.TabIndex = 10;
            btnTransf.Text = "Transferencias entre cuentas";
            btnTransf.UseVisualStyleBackColor = true;
            btnTransf.Click += btnTransf_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(270, 222);
            Controls.Add(btnTransf);
            Controls.Add(btnTransacciones);
            Controls.Add(btnAbrirAddCuenta);
            Controls.Add(btnTestConexion);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnTestConexion;
        private ContextMenuStrip contextMenuStrip1;
        private Button btnAbrirAddCuenta;
        private Button btnTransacciones;
        private Button btnTransf;
    }
}
