using OPERACION_WRLF_EXAMEN_2025.DataAccess;

namespace OPERACION_WRLF_EXAMEN_2025
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnTestConexion_Click(object sender, EventArgs e)
        {
            if (DbHelper.TestConnection())
            {
                MessageBox.Show("�Conexi�n a la base de datos exitosa!", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al conectar a la base de datos. Revisa la configuraci�n de la cadena de conexi�n y el servidor SQL.", "Error de Conexi�n", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbrirAddCuenta_Click(object sender, EventArgs e)
        {
            FrmAddCuenta frmAddCuenta = new FrmAddCuenta();
            frmAddCuenta.ShowDialog();
        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            FrmTransaccion frmTransaccion = new FrmTransaccion();
            frmTransaccion.ShowDialog();
        }

        private void btnTransf_Click(object sender, EventArgs e)
        {
            FrmTransferencia frmTransferencias = new FrmTransferencia();
            frmTransferencias.ShowDialog();
        }
    }
}
