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
        private TextBox txtDniEdit;
        private Button btnGoogleMapsEdit;
        private Button btnBajaUsuarioEdit;
        private Button btnSalirSistema;
        private Panel pnlInfoUsuarioEdit;
        private Label lblInfoNombreEdit;
        private Label lblInfoEstadoEdit;
        private Label lblInfoDniEdit;
        private Label lblInfoMailEdit;
        private Label lblInfoTelefonoEdit;
        private Label lblInfoDomicilioEdit;
        private Label lblDomicilioEdit;
        private Label lblDniEdit;
        private Label lblPerfilAccesoEdit;
        private ComboBox cmbPerfilEdit;

        public frmPrincipal()
        {
            InitializeComponent();
            CrearControlesEdicionAdicionales();
            CrearBotonSalir();
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
                // Datos para Tab Conexión
                ActualizarPanelConexion(true, mensaje);
            }
            else
            {
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
            gpbDatosEdit.Location = new Point(10, 250);
            gpbDatosEdit.Height = 275;
            btnGuardarEdit.Location = new Point(760, 545);
            btnGuardarEdit.Size = new Size(180, 42);

            CrearTarjetaInformacionUsuario();

            lblDniEdit = new Label
            {
                Name = "lblDniEdit",
                Text = "DNI:",
                AutoSize = true,
                Location = new Point(650, 83)
            };

            txtDniEdit = new TextBox
            {
                Name = "txtDniEdit",
                Location = new Point(650, 101),
                MaxLength = 8,
                Size = new Size(270, 24)
            };

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
                Text = "Domicilio / domicilios:",
                AutoSize = true,
                Location = new Point(10, 190)
            };

            txtDomicilioEdit = new TextBox
            {
                Name = "txtDomicilioEdit",
                Location = new Point(10, 208),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Size = new Size(740, 48)
            };

            btnGoogleMapsEdit = new Button
            {
                Name = "btnGoogleMapsEdit",
                Text = "MAPS",
                Location = new Point(770, 216),
                Size = new Size(150, 32)
            };
            btnGoogleMapsEdit.Click += btnGoogleMapsEdit_Click;

            chkActivoEdit.Location = new Point(650, 160);
            chkActivoEdit.Text = "Usuario Activo";
            lblNotaEdit.Location = new Point(10, 260);
            lblNotaEdit.Size = new Size(880, 30);
            lblNotaEdit.Text = "El boton Dar de baja deja al usuario inactivo. Para reactivarlo, marque Usuario Activo y guarde los cambios.";

            btnBajaUsuarioEdit = new Button
            {
                Name = "btnBajaUsuarioEdit",
                Text = "DAR DE BAJA",
                Location = new Point(590, 545),
                Size = new Size(150, 42)
            };
            btnBajaUsuarioEdit.Click += btnBajaUsuarioEdit_Click;

            gpbDatosEdit.Controls.Add(lblDniEdit);
            gpbDatosEdit.Controls.Add(txtDniEdit);
            gpbDatosEdit.Controls.Add(lblPerfilAccesoEdit);
            gpbDatosEdit.Controls.Add(cmbPerfilEdit);
            gpbDatosEdit.Controls.Add(lblDomicilioEdit);
            gpbDatosEdit.Controls.Add(txtDomicilioEdit);
            gpbDatosEdit.Controls.Add(btnGoogleMapsEdit);
            tpEditar.Controls.Add(pnlInfoUsuarioEdit);
            tpEditar.Controls.Add(btnBajaUsuarioEdit);
        }

        private void CrearTarjetaInformacionUsuario()
        {
            pnlInfoUsuarioEdit = new Panel
            {
                Name = "pnlInfoUsuarioEdit",
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, 105),
                Size = new Size(930, 135)
            };

            Label lblTitulo = new Label
            {
                Text = "Informacion del usuario",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 58, 138),
                Location = new Point(14, 10),
                Size = new Size(250, 22)
            };

            lblInfoNombreEdit = CrearEtiquetaInfo("Seleccione un usuario", 14, 36, 420, 26, 12F, true);
            lblInfoEstadoEdit = CrearEtiquetaInfo("", 770, 14, 130, 26, 9.5F, true);
            lblInfoDniEdit = CrearEtiquetaInfo("DNI: -", 14, 70, 220, 22, 9.5F, false);
            lblInfoMailEdit = CrearEtiquetaInfo("Mail: -", 245, 70, 360, 22, 9.5F, false);
            lblInfoTelefonoEdit = CrearEtiquetaInfo("Telefono: -", 620, 70, 280, 22, 9.5F, false);
            lblInfoDomicilioEdit = CrearEtiquetaInfo("Domicilio: -", 14, 100, 886, 28, 9.5F, false);

            pnlInfoUsuarioEdit.Controls.Add(lblTitulo);
            pnlInfoUsuarioEdit.Controls.Add(lblInfoNombreEdit);
            pnlInfoUsuarioEdit.Controls.Add(lblInfoEstadoEdit);
            pnlInfoUsuarioEdit.Controls.Add(lblInfoDniEdit);
            pnlInfoUsuarioEdit.Controls.Add(lblInfoMailEdit);
            pnlInfoUsuarioEdit.Controls.Add(lblInfoTelefonoEdit);
            pnlInfoUsuarioEdit.Controls.Add(lblInfoDomicilioEdit);
        }

        private Label CrearEtiquetaInfo(string texto, int x, int y, int ancho, int alto, float tamano, bool negrita)
        {
            return new Label
            {
                Text = texto,
                AutoSize = false,
                Font = new Font("Segoe UI", tamano, negrita ? FontStyle.Bold : FontStyle.Regular),
                ForeColor = Color.FromArgb(31, 41, 55),
                Location = new Point(x, y),
                Size = new Size(ancho, alto)
            };
        }

        private void CrearBotonSalir()
        {
            btnSalirSistema = new Button
            {
                Name = "btnSalirSistema",
                Text = "SALIR",
                Location = new Point(850, 12),
                Size = new Size(90, 28)
            };
            btnSalirSistema.Click += btnSalirSistema_Click;
            Controls.Add(btnSalirSistema);
            btnSalirSistema.BringToFront();
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
            if (!ObtenerIdUsuarioSeleccionado(cmbSelUsrEdit, out idUsuario))
            {
                LimpiarTarjetaInformacionUsuario();
                return;
            }

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
            txtDniEdit.Text = row["DNI"]?.ToString() ?? "";
            txtContrasenaEdit.Clear();
            txtTelefonoEdit.Text = row["Telefono"]?.ToString() ?? "";
            string domicilio = row.IsNull("Domicilio") ? "" : row["Domicilio"].ToString();
            txtDomicilioEdit.Text = domicilio;

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

            MostrarInformacionUsuario(row, domicilio);
        }

        private void MostrarInformacionUsuario(DataRow row, string domicilio)
        {
            string nombreCompleto = (ObtenerTexto(row, "Nombre") + " " + ObtenerTexto(row, "Apellido")).Trim();
            string estado = ValidadorUsuarios.EstaActivo(row["Activo"]) ? "Activo" : "Dado de baja";
            string domicilioVisible = string.IsNullOrWhiteSpace(domicilio) ? "Sin domicilio cargado" : domicilio.Trim();

            lblInfoNombreEdit.Text = string.IsNullOrWhiteSpace(nombreCompleto) ? "Usuario sin nombre" : nombreCompleto;
            lblInfoEstadoEdit.Text = estado;
            lblInfoEstadoEdit.ForeColor = estado == "Activo"
                ? Color.FromArgb(22, 101, 52)
                : Color.FromArgb(185, 28, 28);
            lblInfoDniEdit.Text = "DNI: " + ObtenerTexto(row, "DNI");
            lblInfoMailEdit.Text = "Mail: " + ObtenerTexto(row, "Mail");
            lblInfoTelefonoEdit.Text = "Telefono: " + ObtenerTexto(row, "Telefono");
            lblInfoDomicilioEdit.Text = "Domicilio: " + NormalizarDomicilioParaTarjeta(domicilioVisible);
        }

        private void LimpiarTarjetaInformacionUsuario()
        {
            lblInfoNombreEdit.Text = "Seleccione un usuario";
            lblInfoEstadoEdit.Text = "";
            lblInfoDniEdit.Text = "DNI: -";
            lblInfoMailEdit.Text = "Mail: -";
            lblInfoTelefonoEdit.Text = "Telefono: -";
            lblInfoDomicilioEdit.Text = "Domicilio: -";
        }

        private string NormalizarDomicilioParaTarjeta(string domicilio)
        {
            return domicilio.Replace(Environment.NewLine, " | ").Replace("\n", " | ").Replace("\r", " | ");
        }

        private string ObtenerTexto(DataRow row, string columna)
        {
            return row.IsNull(columna) ? "" : row[columna].ToString();
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
            string dni = txtDniEdit.Text.Trim();
            string nuevaContrasena = txtContrasenaEdit.Text;
            string telefono = txtTelefonoEdit.Text.Trim();
            string domicilio = txtDomicilioEdit.Text.Trim();
            string tipoRed = cmbRedSocialEdit.SelectedIndex > 0 ? cmbRedSocialEdit.SelectedItem.ToString() : "";
            string handle = txtHandleEdit.Text.Trim();
            bool activo = chkActivoEdit.Checked;

            string aviso;
            if (!ValidadorUsuarios.ValidarEdicion(dni, nombre, apellido, mail, out aviso))
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
            bool ok = Conexionbd.EditarUsuario(idUsuario, dni, nombre, apellido, mail, nuevaContrasena,
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

        private void btnBajaUsuarioEdit_Click(object sender, EventArgs e)
        {
            int idUsuario;
            if (!ObtenerIdUsuarioSeleccionado(cmbSelUsrEdit, out idUsuario))
            {
                MsgWarn("Seleccione un usuario para dar de baja.");
                return;
            }

            DialogResult respuesta = MessageBox.Show(
                "Desea dar de baja al usuario seleccionado?",
                "Confirmar baja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            string msg;
            if (Conexionbd.DarDeBajaUsuario(idUsuario, out msg))
            {
                chkActivoEdit.Checked = false;
                MessageBox.Show("Usuario dado de baja correctamente.", "Baja realizada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuariosEnCombo(cmbSelUsrEdit);
            }
            else
            {
                MessageBox.Show(msg, "Error al dar de baja", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnSalirSistema_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
