using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using pryAYbarERP.BaseDatos;
using pryAYbarERP.Clases;

namespace pryAYbarERP
{
    public partial class frmPrincipal : Form
    {
        // Tabla temporal de domicilios para el registro
        private DataTable _dtDomiciliosTemp;
        private TextBox txtDomicilioEdit;
        private Button btnGoogleMapsEdit;
        private Label lblDomicilioEdit;
        private Label lblPerfilAccesoEdit;
        private ComboBox cmbPerfilEdit;

        public frmPrincipal()
        {
            InitializeComponent();
            CrearControlesEdicionAdicionales();
            EstilosFormularios.Aplicar(this);
            _dtDomiciliosTemp = DomiciliosTemporales.CrearTabla();
        }

        // ====================================================================
        //  CARGA DEL FORMULARIO
        // ====================================================================
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            VerificarConexion();
            CargadorCombos.CargarProvincias(cmbProvinciaReg);
            CargadorCombos.LimpiarLocalidades(cmbLocalidadReg);
            CargarPerfilesReg();
            CargarPerfilesEdit();
        }

        // ====================================================================
        //  HELPERS GENERALES
        // ====================================================================

        private void VerificarConexion()
        {
            string mensaje;
            bool conectado = Conexionbd.ProbarConexion(out mensaje);

            if (conectado)
            {
                BarraDeEstado.Value = 100;
                tsslEstado.Text = "Base de Datos:";
                lblConexion.Text = "Conectado";
                lblConexion.ForeColor = System.Drawing.Color.LimeGreen;

                // Datos para Tab Conexión
                ActualizarPanelConexion(true, mensaje);
            }
            else
            {
                BarraDeEstado.Value = 0;
                tsslEstado.Text = "Base de Datos:";
                lblConexion.Text = "Sin conexion";
                lblConexion.ForeColor = System.Drawing.Color.OrangeRed;

                ActualizarPanelConexion(false, mensaje);
            }
        }

        private void ActualizarPanelConexion(bool conectado, string mensaje)
        {
            if (conectado)
            {
                lblIconoEstadoConn.Text = "OK";
                lblEstadoConnInfo.Text = "CONECTADO";
                lblEstadoConnInfo.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
                panelEstadoConn.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
                pbConexionConn.Value = 100;

                string cs = Conexionbd.ConnectionString ?? "";
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder(cs);
                string dataSource = builder.ContainsKey("Data Source") ? builder["Data Source"].ToString() : "";
                string provider = builder.ContainsKey("Provider") ? builder["Provider"].ToString() : "";

                lblArchivoConn.Text = System.IO.Path.GetFileName(dataSource);
                lblProveedorConn.Text = provider;
            }
            else
            {
                lblIconoEstadoConn.Text = "ERROR";
                lblEstadoConnInfo.Text = "SIN CONEXION";
                lblEstadoConnInfo.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
                panelEstadoConn.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
                pbConexionConn.Value = 0;
                lblArchivoConn.Text = "No disponible";
                lblProveedorConn.Text = "";
            }

            lblFechaConexionConn.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        }

        private void CargarPerfilesReg()
        {
            string mensaje;
            if (!CargadorCombos.CargarPerfiles(cmbPerfilReg, out mensaje) && !string.IsNullOrWhiteSpace(mensaje))
                MessageBox.Show(mensaje, "Error al cargar perfiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CargarUsuariosEnCombo(ComboBox cmb)
        {
            string mensaje;
            if (!CargadorCombos.CargarUsuarios(cmb, out mensaje) && !string.IsNullOrWhiteSpace(mensaje))
                MessageBox.Show(mensaje, "Error al cargar usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CargarPerfilesEdit()
        {
            string mensaje;
            if (!CargadorCombos.CargarPerfiles(cmbPerfilEdit, out mensaje) && !string.IsNullOrWhiteSpace(mensaje))
                MessageBox.Show(mensaje, "Error al cargar perfiles", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CrearControlesEdicionAdicionales()
        {
            gpbDatosEdit.Height = 400;
            btnGuardarEdit.Location = new Point(760, 528);
            btnGuardarEdit.Size = new Size(180, 42);

            lblPerfilAccesoEdit = new Label
            {
                Name = "lblPerfilAccesoEdit",
                Text = "Perfil de acceso:",
                AutoSize = true,
                Location = new Point(650, 25)
            };

            cmbPerfilEdit = new ComboBox
            {
                Name = "cmbPerfilEdit",
                DropDownStyle = ComboBoxStyle.DropDownList,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(650, 43),
                Size = new Size(270, 25)
            };

            lblDomicilioEdit = new Label
            {
                Name = "lblDomicilioEdit",
                Text = "Domicilio:",
                AutoSize = true,
                Location = new Point(10, 210)
            };

            txtDomicilioEdit = new TextBox
            {
                Name = "txtDomicilioEdit",
                Location = new Point(10, 228),
                Size = new Size(740, 24)
            };

            btnGoogleMapsEdit = new Button
            {
                Name = "btnGoogleMapsEdit",
                Text = "MAPS",
                Location = new Point(770, 224),
                Size = new Size(150, 32)
            };
            btnGoogleMapsEdit.Click += btnGoogleMapsEdit_Click;

            chkActivoEdit.Location = new Point(10, 285);
            lblNotaEdit.Location = new Point(10, 325);
            lblNotaEdit.Size = new Size(880, 30);

            gpbDatosEdit.Controls.Add(lblPerfilAccesoEdit);
            gpbDatosEdit.Controls.Add(cmbPerfilEdit);
            gpbDatosEdit.Controls.Add(lblDomicilioEdit);
            gpbDatosEdit.Controls.Add(txtDomicilioEdit);
            gpbDatosEdit.Controls.Add(btnGoogleMapsEdit);
        }

        // ====================================================================
        //  TAB 1 – REGISTRAR USUARIO
        // ====================================================================

        private void cmbProvinciaReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargadorCombos.LimpiarLocalidades(cmbLocalidadReg);

            if (cmbProvinciaReg.SelectedIndex < 0) return;
            
            int idProv = CargadorCombos.ObtenerIdSeleccionado(cmbProvinciaReg);
            if (idProv == 0) return;

            cmbLocalidadReg.Enabled = true;
            CargadorCombos.CargarLocalidades(cmbLocalidadReg, idProv);
        }

        private void chkMostrarReg_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenaReg.PasswordChar = chkMostrarReg.Checked ? '\0' : '•';
        }

        private void btnGoogleMapsReg_Click(object sender, EventArgs e)
        {
            string dir = txtDireccionReg.Text.Trim();
            if (string.IsNullOrWhiteSpace(dir))
            {
                MessageBox.Show("Ingrese una dirección primero.", "Dirección vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string prov = cmbProvinciaReg.SelectedIndex >= 0 ? cmbProvinciaReg.Text : "";
            string loc = cmbLocalidadReg.SelectedIndex >= 0 ? cmbLocalidadReg.Text : "";
            string query = Uri.EscapeDataString($"{dir}, {loc}, {prov}, Argentina");
            Process.Start(new ProcessStartInfo
            {
                FileName = $"https://www.google.com/maps/search/?api=1&query={query}",
                UseShellExecute = true
            });
        }

        private void btnAgregarDomReg_Click(object sender, EventArgs e)
        {
            string dir = txtDireccionReg.Text.Trim();
            if (string.IsNullOrWhiteSpace(dir))
            {
                MessageBox.Show("Ingrese la dirección.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDireccionReg.Focus();
                return;
            }
            if (cmbProvinciaReg.SelectedValue == null)
            {
                MessageBox.Show("Seleccione la provincia.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProvinciaReg.Focus();
                return;
            }
            if (cmbLocalidadReg.SelectedValue == null)
            {
                MessageBox.Show("Seleccione la localidad.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbLocalidadReg.Focus();
                return;
            }

            int idProv = CargadorCombos.ObtenerIdSeleccionado(cmbProvinciaReg);
            string nomProv = cmbProvinciaReg.Text;
            int idLoc = CargadorCombos.ObtenerIdSeleccionado(cmbLocalidadReg);
            string nomLoc = cmbLocalidadReg.Text;

            DomiciliosTemporales.Agregar(_dtDomiciliosTemp, dir, idProv, nomProv, idLoc, nomLoc);
            DomiciliosTemporales.MostrarEnGrilla(_dtDomiciliosTemp, dgvDomiciliosReg);

            txtDireccionReg.Clear();
            cmbProvinciaReg.SelectedIndex = -1;
            cmbLocalidadReg.DataSource = null;
        }

        private void RefrescarGrillaDomicilios()
        {
            DomiciliosTemporales.MostrarEnGrilla(_dtDomiciliosTemp, dgvDomiciliosReg);
        }

        private void btnEliminarDomReg_Click(object sender, EventArgs e)
        {
            DomiciliosTemporales.EliminarSeleccionado(_dtDomiciliosTemp, dgvDomiciliosReg);
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            // Validaciones
            string dni = txtDniReg.Text.Trim();
            string nombre = txtNombreReg.Text.Trim();
            string apellido = txtApellidoReg.Text.Trim();
            string mail = txtMailReg.Text.Trim();
            string contrasena = txtContrasenaReg.Text;
            string telefono = txtTelefonoReg.Text.Trim();
            string tipoRed = cmbRedSocialReg.SelectedIndex > 0 ? cmbRedSocialReg.SelectedItem.ToString() : "";
            string handle = txtHandleReg.Text.Trim();

            string aviso;
            bool perfilSeleccionado = cmbPerfilReg.SelectedValue != null && cmbPerfilReg.SelectedIndex != -1;
            if (!ValidadorUsuarios.ValidarRegistro(dni, nombre, apellido, mail, contrasena, perfilSeleccionado, out aviso))
            {
                MsgWarn(aviso);
                return;
            }

            int idPerfil = Convert.ToInt32(cmbPerfilReg.SelectedValue);
            string redesSociales = ValidadorUsuarios.ArmarRedSocial(tipoRed, handle);

            string msg;
            bool ok = Conexionbd.RegistrarUsuarioCompleto(
                dni, nombre, apellido, mail, contrasena,
                idPerfil, telefono, redesSociales, _dtDomiciliosTemp, out msg);

            if (ok)
            {
                MessageBox.Show("Usuario registrado exitosamente.", "Registro exitoso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarFormularioRegistro();
            }
            else
            {
                MessageBox.Show(msg, "Error al registrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarReg_Click(object sender, EventArgs e)
        {
            LimpiarFormularioRegistro();
        }

        private void LimpiarFormularioRegistro()
        {
            txtDniReg.Clear();
            txtNombreReg.Clear();
            txtApellidoReg.Clear();
            txtMailReg.Clear();
            txtContrasenaReg.Clear();
            txtTelefonoReg.Clear();
            txtHandleReg.Clear();
            txtDireccionReg.Clear();
            cmbPerfilReg.SelectedIndex = -1;
            cmbRedSocialReg.SelectedIndex = 0;
            cmbProvinciaReg.SelectedIndex = -1;
            CargadorCombos.LimpiarLocalidades(cmbLocalidadReg);
            chkMostrarReg.Checked = false;
            _dtDomiciliosTemp.Clear();
            dgvDomiciliosReg.Rows.Clear();
        }

        // ====================================================================
        //  TAB 2 – EDITAR USUARIO
        // ====================================================================

        private void tpEditar_Enter(object sender, EventArgs e)
        {
            CargarUsuariosEnCombo(cmbSelUsrEdit);
        }

        private void cmbSelUsrEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idUsuario;
            if (!ObtenerIdUsuarioSeleccionado(cmbSelUsrEdit, out idUsuario)) return;

            CargarDatosUsuarioEnEdit(idUsuario);
        }

        private void CargarDatosUsuarioEnEdit(int idUsuario)
        {
            string msg;
            DataRow row = Conexionbd.ObtenerDatosUsuario(idUsuario, out msg);
            if (row == null)
            {
                MessageBox.Show(string.IsNullOrEmpty(msg) ? "No se encontraron datos del usuario." : msg,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            txtNombreEdit.Text = row["Nombre"]?.ToString() ?? "";
            txtApellidoEdit.Text = row["Apellido"]?.ToString() ?? "";
            txtMailEdit.Text = row["Mail"]?.ToString() ?? "";
            txtContrasenaEdit.Clear();
            txtTelefonoEdit.Text = row["Telefono"]?.ToString() ?? "";
            txtDomicilioEdit.Text = row["Domicilio"]?.ToString() ?? "";

            // Parsear red social: "Facebook|usuario"
            string redesRaw = row["RedesSociales"]?.ToString() ?? "";
            if (redesRaw.Contains("|"))
            {
                string[] partes = redesRaw.Split('|');
                string tipoRed = partes[0];
                int idxRed = cmbRedSocialEdit.Items.IndexOf(tipoRed);
                cmbRedSocialEdit.SelectedIndex = idxRed >= 0 ? idxRed : 0;
                txtHandleEdit.Text = partes.Length > 1 ? partes[1] : "";
            }
            else
            {
                cmbRedSocialEdit.SelectedIndex = 0;
                txtHandleEdit.Text = redesRaw;
            }

            chkActivoEdit.Checked = ValidadorUsuarios.EstaActivo(row["Activo"]);

            string msgPerfil;
            int idPerfil = Conexionbd.ObtenerPerfilUsuario(idUsuario, out msgPerfil);
            if (idPerfil > 0)
                cmbPerfilEdit.SelectedValue = idPerfil;
        }

        private void chkMostrarEdit_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenaEdit.PasswordChar = chkMostrarEdit.Checked ? '\0' : '•';
        }

        private void btnGuardarEdit_Click(object sender, EventArgs e)
        {
            int idUsuario;
            if (!ObtenerIdUsuarioSeleccionado(cmbSelUsrEdit, out idUsuario))
            {
                MsgWarn("Seleccione un usuario para editar.");
                return;
            }

            string nombre = txtNombreEdit.Text.Trim();
            string apellido = txtApellidoEdit.Text.Trim();
            string mail = txtMailEdit.Text.Trim();
            string nuevaContrasena = txtContrasenaEdit.Text;
            string telefono = txtTelefonoEdit.Text.Trim();
            string domicilio = txtDomicilioEdit.Text.Trim();
            string tipoRed = cmbRedSocialEdit.SelectedIndex > 0 ? cmbRedSocialEdit.SelectedItem.ToString() : "";
            string handle = txtHandleEdit.Text.Trim();
            bool activo = chkActivoEdit.Checked;

            string aviso;
            if (!ValidadorUsuarios.ValidarEdicion(nombre, apellido, mail, out aviso))
            {
                MsgWarn(aviso);
                return;
            }

            int idPerfil;
            if (cmbPerfilEdit.SelectedValue == null || !int.TryParse(cmbPerfilEdit.SelectedValue.ToString(), out idPerfil))
            {
                MsgWarn("Seleccione el perfil de acceso.");
                return;
            }

            string redesSociales = ValidadorUsuarios.ArmarRedSocial(tipoRed, handle);

            string msg;
            bool ok = Conexionbd.EditarUsuario(idUsuario, nombre, apellido, mail, nuevaContrasena,
                telefono, redesSociales, domicilio, activo, idPerfil, out msg);

            if (ok)
            {
                MessageBox.Show("Datos del usuario actualizados correctamente.", "Actualizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuariosEnCombo(cmbSelUsrEdit);
            }
            else
            {
                MessageBox.Show(msg, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoogleMapsEdit_Click(object sender, EventArgs e)
        {
            string dir = txtDomicilioEdit.Text.Trim();
            if (string.IsNullOrWhiteSpace(dir))
            {
                MessageBox.Show("Ingrese un domicilio primero.", "Domicilio vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = Uri.EscapeDataString(dir + ", Argentina");
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://www.google.com/maps/search/?api=1&query=" + query,
                UseShellExecute = true
            });
        }

        // ====================================================================
        //  TAB 3 – GESTIÓN DE ESTADO (DAR DE BAJA / ACTIVAR)
        // ====================================================================

        // NOTE: Se eliminó la pestaña de Gestión de Estado y su UI. La gestión
        // de si un usuario está activo ahora se realiza desde la pestaña Editar
        // usando el checkbox `chkActivoEdit` y guardando con `btnGuardarEdit`.

        // (Métodos relacionados con la pestaña anterior han sido removidos.)

        // ====================================================================
        //  TAB 4 – CONEXIÓN BD
        // ====================================================================

        private void btnReconectar_Click(object sender, EventArgs e)
        {
            lblEstadoConnInfo.Text = "Reconectando...";
            lblEstadoConnInfo.ForeColor = System.Drawing.Color.FromArgb(161, 98, 7);
            panelEstadoConn.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.Refresh();

            VerificarConexion();
        }

        private void stEstadoConexion_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        // ====================================================================
        //  HELPERS
        // ====================================================================
        private void MsgWarn(string texto)
        {
            MessageBox.Show(texto, "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool ObtenerIdUsuarioSeleccionado(ComboBox combo, out int idUsuario)
        {
            idUsuario = 0;

            if (combo.SelectedIndex == -1 || combo.SelectedValue == null)
                return false;

            if (combo.SelectedValue is DataRowView)
                return false;

            return int.TryParse(combo.SelectedValue.ToString(), out idUsuario);
        }

        // Agrego el manejador faltante para cmbRedSocialReg.SelectedIndexChanged
        private void cmbRedSocialReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Si se selecciona "(Ninguna)" deshabilito y limpio el campo de handle,
            // en caso contrario lo habilito para que el usuario ingrese su perfil/usuario.
            if (cmbRedSocialReg.SelectedItem != null && cmbRedSocialReg.SelectedItem.ToString() == "(Ninguna)")
            {
                txtHandleReg.Text = string.Empty;
                txtHandleReg.Enabled = false;
            }
            else
            {
                txtHandleReg.Enabled = true;
            }
        }
    }
}
