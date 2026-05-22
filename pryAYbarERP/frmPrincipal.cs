using System;
using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using pryAYbarERP.BaseDatos;
using pryAYbarERP.Clases;

namespace pryAYbarERP
{
    public partial class frmPrincipal : Form
    {
        // Tabla temporal de domicilios para el registro
        private DataTable _dtDomiciliosTemp;

        public frmPrincipal()
        {
            InitializeComponent();
            _dtDomiciliosTemp = new DataTable();
            _dtDomiciliosTemp.Columns.Add("Direccion", typeof(string));
            _dtDomiciliosTemp.Columns.Add("Id_Provincias", typeof(int));
            _dtDomiciliosTemp.Columns.Add("Provincia", typeof(string));
            _dtDomiciliosTemp.Columns.Add("Id_Localidades", typeof(int));
            _dtDomiciliosTemp.Columns.Add("Localidad", typeof(string));
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
                lblConexion.Text = "✓ Conectado";
                lblConexion.ForeColor = System.Drawing.Color.LimeGreen;

                // Datos para Tab Conexión
                ActualizarPanelConexion(true, mensaje);
            }
            else
            {
                BarraDeEstado.Value = 0;
                tsslEstado.Text = "Base de Datos:";
                lblConexion.Text = "✗ Sin conexión";
                lblConexion.ForeColor = System.Drawing.Color.OrangeRed;

                ActualizarPanelConexion(false, mensaje);
            }
        }

        private void ActualizarPanelConexion(bool conectado, string mensaje)
        {
            if (conectado)
            {
                lblIconoEstadoConn.Text = "✅";
                lblEstadoConnInfo.Text = "✓  CONECTADO";
                lblEstadoConnInfo.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
                panelEstadoConn.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
                pbConexionConn.Value = 100;

                // Extraer nombre de archivo del connection string
                string cs = Conexionbd.ConnectionString ?? "";
                string archivo = "—";
                string proveedor = "—";
                var matchDs = Regex.Match(cs, @"Data Source=([^;]+)");
                if (matchDs.Success)
                    archivo = System.IO.Path.GetFileName(matchDs.Groups[1].Value);
                var matchProv = Regex.Match(cs, @"Provider=([^;]+)");
                if (matchProv.Success)
                    proveedor = matchProv.Groups[1].Value;

                lblArchivoConn.Text = archivo;
                lblProveedorConn.Text = proveedor;
            }
            else
            {
                lblIconoEstadoConn.Text = "❌";
                lblEstadoConnInfo.Text = "✗  SIN CONEXIÓN";
                lblEstadoConnInfo.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
                panelEstadoConn.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
                pbConexionConn.Value = 0;
                lblArchivoConn.Text = "— No disponible —";
                lblProveedorConn.Text = "—";
            }

            lblFechaConexionConn.Text = DateTime.Now.ToString("dd/MM/yyyy  HH:mm:ss");
        }

        private void CargarPerfilesReg()
        {
            string msg;
            DataTable dt = Conexionbd.ObtenerPerfiles(out msg);
            if (dt != null && dt.Rows.Count > 0)
            {
                cmbPerfilReg.DataSource = dt;
                cmbPerfilReg.DisplayMember = "Nombre";
                cmbPerfilReg.ValueMember = "Id_Perfil";
                cmbPerfilReg.SelectedIndex = -1;
            }
        }

        private void CargarUsuariosEnCombo(ComboBox cmb)
        {
            string msg;
            DataTable dt = Conexionbd.ObtenerUsuariosCompleto(out msg);
            cmb.DataSource = null;
            if (dt != null && dt.Rows.Count > 0)
            {
                cmb.DataSource = dt;
                cmb.DisplayMember = "NombreCompleto";
                cmb.ValueMember = "Id_Usuario";
                cmb.SelectedIndex = -1;
            }
        }

        // ====================================================================
        //  TAB 1 – REGISTRAR USUARIO
        // ====================================================================

        private void cmbProvinciaReg_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargadorCombos.LimpiarLocalidades(cmbLocalidadReg);

            if (!CargadorCombos.EsCordoba(cmbProvinciaReg))
            {
                return;
            }
            
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

            int idProv = Convert.ToInt32(cmbProvinciaReg.SelectedValue);
            string nomProv = cmbProvinciaReg.Text;
            int idLoc = Convert.ToInt32(cmbLocalidadReg.SelectedValue);
            string nomLoc = cmbLocalidadReg.Text;

            DataRow nr = _dtDomiciliosTemp.NewRow();
            nr["Direccion"] = dir;
            nr["Id_Provincias"] = idProv;
            nr["Provincias"] = nomProv;
            nr["Id_Localidades"] = idLoc;
            nr["Localidad"] = nomLoc;
            _dtDomiciliosTemp.Rows.Add(nr);

            RefrescarGrillaDomicilios();

            txtDireccionReg.Clear();
            cmbProvinciaReg.SelectedIndex = -1;
            cmbLocalidadReg.DataSource = null;
        }

        private void RefrescarGrillaDomicilios()
        {
            dgvDomiciliosReg.Rows.Clear();
            foreach (DataRow r in _dtDomiciliosTemp.Rows)
            {
                dgvDomiciliosReg.Rows.Add(
                    r["Direccion"],
                    r["Id_Provincias"],
                    r["Provincias"],
                    r["Id_Localidades"],
                    r["Localidad"]
                );
            }
        }

        private void btnEliminarDomReg_Click(object sender, EventArgs e)
        {
            if (dgvDomiciliosReg.SelectedRows.Count == 0) return;
            int idx = dgvDomiciliosReg.SelectedRows[0].Index;
            if (idx >= 0 && idx < _dtDomiciliosTemp.Rows.Count)
            {
                _dtDomiciliosTemp.Rows.RemoveAt(idx);
                RefrescarGrillaDomicilios();
            }
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

            if (string.IsNullOrWhiteSpace(dni))
            { MsgWarn("Ingrese el DNI."); txtDniReg.Focus(); return; }
            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
            { MsgWarn("El DNI debe tener 7 u 8 dígitos numéricos."); txtDniReg.Focus(); return; }
            if (string.IsNullOrWhiteSpace(nombre))
            { MsgWarn("Ingrese el Nombre."); txtNombreReg.Focus(); return; }
            if (string.IsNullOrWhiteSpace(apellido))
            { MsgWarn("Ingrese el Apellido."); txtApellidoReg.Focus(); return; }
            if (string.IsNullOrWhiteSpace(mail))
            { MsgWarn("Ingrese el Correo Electrónico."); txtMailReg.Focus(); return; }
            if (!Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { MsgWarn("El correo electrónico no tiene un formato válido."); txtMailReg.Focus(); return; }
            if (string.IsNullOrWhiteSpace(contrasena))
            { MsgWarn("Ingrese la Contraseña."); txtContrasenaReg.Focus(); return; }
            if (cmbPerfilReg.SelectedValue == null || cmbPerfilReg.SelectedIndex == -1)
            { MsgWarn("Seleccione el Perfil de acceso."); cmbPerfilReg.Focus(); return; }

            int idPerfil = Convert.ToInt32(cmbPerfilReg.SelectedValue);
            string redesSociales = string.IsNullOrEmpty(tipoRed) ? "" : $"{tipoRed}|{handle}";

            string msg;
            bool ok = Conexionbd.RegistrarUsuarioCompleto(
                dni, nombre, apellido, mail, contrasena,
                idPerfil, telefono, redesSociales, _dtDomiciliosTemp, out msg);

            if (ok)
            {
                MessageBox.Show("✅ Usuario registrado exitosamente.", "Registro exitoso",
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
            if (cmbSelUsrEdit.SelectedValue == null || cmbSelUsrEdit.SelectedIndex == -1) return;
            int idUsuario = Convert.ToInt32(cmbSelUsrEdit.SelectedValue);
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

            object activoObj = row["Activo"];
            bool activo = activoObj != DBNull.Value && Convert.ToBoolean(activoObj);
            chkActivoEdit.Checked = activo;
        }

        private void chkMostrarEdit_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasenaEdit.PasswordChar = chkMostrarEdit.Checked ? '\0' : '•';
        }

        private void btnGuardarEdit_Click(object sender, EventArgs e)
        {
            if (cmbSelUsrEdit.SelectedValue == null || cmbSelUsrEdit.SelectedIndex == -1)
            {
                MsgWarn("Seleccione un usuario para editar.");
                return;
            }

            int idUsuario = Convert.ToInt32(cmbSelUsrEdit.SelectedValue);
            string nombre = txtNombreEdit.Text.Trim();
            string apellido = txtApellidoEdit.Text.Trim();
            string mail = txtMailEdit.Text.Trim();
            string nuevaContrasena = txtContrasenaEdit.Text;
            string telefono = txtTelefonoEdit.Text.Trim();
            string tipoRed = cmbRedSocialEdit.SelectedIndex > 0 ? cmbRedSocialEdit.SelectedItem.ToString() : "";
            string handle = txtHandleEdit.Text.Trim();
            bool activo = chkActivoEdit.Checked;

            if (string.IsNullOrWhiteSpace(nombre))
            { MsgWarn("Ingrese el Nombre."); txtNombreEdit.Focus(); return; }
            if (string.IsNullOrWhiteSpace(apellido))
            { MsgWarn("Ingrese el Apellido."); txtApellidoEdit.Focus(); return; }
            if (string.IsNullOrWhiteSpace(mail) || !Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            { MsgWarn("Ingrese un correo electrónico válido."); txtMailEdit.Focus(); return; }

            string redesSociales = string.IsNullOrEmpty(tipoRed) ? handle : $"{tipoRed}|{handle}";

            string msg;
            bool ok = Conexionbd.EditarUsuario(idUsuario, nombre, apellido, mail, nuevaContrasena,
                telefono, redesSociales, activo, out msg);

            if (ok)
            {
                MessageBox.Show("✅ Datos del usuario actualizados correctamente.", "Actualizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuariosEnCombo(cmbSelUsrEdit);
            }
            else
            {
                MessageBox.Show(msg, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        //  TAB 3 – GESTIÓN DE ESTADO (DAR DE BAJA / ACTIVAR)
        // ====================================================================

        private void tpEstado_Enter(object sender, EventArgs e)
        {
            CargarUsuariosEnCombo(cmbSelUsrBaja);
            LimpiarPanelEstado();
        }

        private void cmbSelUsrBaja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelUsrBaja.SelectedValue == null || cmbSelUsrBaja.SelectedIndex == -1)
            {
                LimpiarPanelEstado();
                return;
            }
            int idUsuario = Convert.ToInt32(cmbSelUsrBaja.SelectedValue);
            MostrarEstadoUsuario(idUsuario);
        }

        private void LimpiarPanelEstado()
        {
            lblNombreCompletoBaja.Text = "— Seleccione un usuario —";
            lblMailMostrarBaja.Text = "";
            lblIconoEstado.Text = "⚪";
            lblEstadoBaja.Text = "Sin selección";
            lblEstadoBaja.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            panelEstadoBaja.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
        }

        private void MostrarEstadoUsuario(int idUsuario)
        {
            string msg;
            DataRow row = Conexionbd.ObtenerDatosUsuario(idUsuario, out msg);
            if (row == null) return;

            lblNombreCompletoBaja.Text = $"{row["Apellido"]}, {row["Nombre"]}";
            lblMailMostrarBaja.Text = $"📧  {row["Mail"]}";

            object activoObj = row["Activo"];
            bool activo = activoObj != DBNull.Value && Convert.ToBoolean(activoObj);

            if (activo)
            {
                lblIconoEstado.Text = "🟢";
                lblEstadoBaja.Text = "ACTIVO";
                lblEstadoBaja.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
                panelEstadoBaja.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
            }
            else
            {
                lblIconoEstado.Text = "🔴";
                lblEstadoBaja.Text = "INACTIVO";
                lblEstadoBaja.ForeColor = System.Drawing.Color.FromArgb(153, 27, 27);
                panelEstadoBaja.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            }
        }

        private void btnActivarBaja_Click(object sender, EventArgs e)
        {
            CambiarEstado(true);
        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            CambiarEstado(false);
        }

        private void CambiarEstado(bool activar)
        {
            if (cmbSelUsrBaja.SelectedValue == null || cmbSelUsrBaja.SelectedIndex == -1)
            {
                MsgWarn("Seleccione un usuario primero.");
                return;
            }

            string accion = activar ? "activar" : "dar de baja";
            string nombre = lblNombreCompletoBaja.Text;
            var confirm = MessageBox.Show(
                $"¿Desea {accion} al usuario \"{nombre}\"?",
                "Confirmar acción",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int idUsuario = Convert.ToInt32(cmbSelUsrBaja.SelectedValue);
            string msg;
            bool ok = Conexionbd.CambiarEstadoUsuario(idUsuario, activar, out msg);

            if (ok)
            {
                string resultado = activar ? "✅ Usuario ACTIVADO correctamente." : "🚫 Usuario dado de BAJA correctamente.";
                MessageBox.Show(resultado, "Estado actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MostrarEstadoUsuario(idUsuario);
            }
            else
            {
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        //  TAB 4 – CONEXIÓN BD
        // ====================================================================

        private void btnReconectar_Click(object sender, EventArgs e)
        {
            lblEstadoConnInfo.Text = "⏳ Reconectando...";
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
    }
}
