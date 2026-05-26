using System;
using System.Windows.Forms;
using pryAYbarERP.BaseDatos;
using pryAYbarERP.Clases;

namespace pryAYbarERP
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
            EstilosFormularios.Aplicar(this);
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Ingrese el usuario o correo.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mensaje;
            bool ok = Conexionbd.ValidarUsuario(usuario, contrasena, out mensaje);

            if (ok)
            {
                Conexionbd.GrabarAuditoriaSesion(usuario, mensaje);
                var frm = new frmPrincipal();
                frm.Show();
                this.Hide();
            }
            else
            {
                Conexionbd.GrabarAuditoriaSesion(usuario, mensaje);
                MessageBox.Show(mensaje, "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
                txtContrasena.PasswordChar = '\0';
            else
                txtContrasena.PasswordChar = '•';
        }
    }
}
