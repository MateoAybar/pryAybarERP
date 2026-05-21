using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using pryAYbarERP.BaseDatos;

namespace pryAYbarERP
{
    public partial class frmRegistroUsuario : Form
    {
        private Form _frmLogin;

        public frmRegistroUsuario(Form frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void frmRegistroUsuario_Load(object sender, EventArgs e)
        {
            CargarPerfiles();
        }

        private void CargarPerfiles()
        {
            string mensaje;
            DataTable dtPerfiles = Conexionbd.ObtenerPerfiles(out mensaje);

            if (dtPerfiles != null && dtPerfiles.Rows.Count > 0)
            {
                cmbPerfil.DataSource = dtPerfiles;
                cmbPerfil.DisplayMember = "Nombre";
                cmbPerfil.ValueMember = "Id_Perfil";
                cmbPerfil.SelectedIndex = -1; // Comienza vacío para obligar a seleccionar
            }
            else
            {
                MessageBox.Show(
                    string.IsNullOrWhiteSpace(mensaje) ? "No se pudieron cargar los perfiles desde la base de datos." : mensaje,
                    "Error al cargar perfiles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrar.Checked)
                txtContrasena.PasswordChar = '\0';
            else
                txtContrasena.PasswordChar = '•';
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            VolverAlLogin();
        }

        private void VolverAlLogin()
        {
            if (_frmLogin != null)
            {
                _frmLogin.Show();
            }
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string mail = txtMail.Text.Trim();
            string contrasena = txtContrasena.Text;

            // Validaciones de entrada
            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingrese el Nombre.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show("Por favor, ingrese el Apellido.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(mail))
            {
                MessageBox.Show("Por favor, ingrese el Correo Electrónico.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return;
            }

            // Expresión regular básica para validar correo electrónico
            string patronEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(mail, patronEmail))
            {
                MessageBox.Show("Por favor, ingrese un Correo Electrónico válido (ejemplo@dominio.com).", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, ingrese la Contraseña.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContrasena.Focus();
                return;
            }

            if (cmbPerfil.SelectedValue == null || cmbPerfil.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un perfil para la cuenta.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPerfil.Focus();
                return;
            }

            int idPerfil = Convert.ToInt32(cmbPerfil.SelectedValue);

            // Registro en la base de datos
            string mensaje;
            bool exito = Conexionbd.RegistrarUsuario(nombre, apellido, mail, contrasena, idPerfil, out mensaje);

            if (exito)
            {
                MessageBox.Show("Usuario registrado correctamente.", "Registro exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                VolverAlLogin();
            }
            else
            {
                MessageBox.Show(mensaje, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
