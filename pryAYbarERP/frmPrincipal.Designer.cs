namespace pryAYbarERP
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            // ─── Status Strip ───────────────────────────────────────────────
            this.stEstadoConexion = new System.Windows.Forms.StatusStrip();
            this.tsslEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.BarraDeEstado = new System.Windows.Forms.ToolStripProgressBar();
            this.lblConexion = new System.Windows.Forms.Label();
            // ─── Tab Control ────────────────────────────────────────────────
            this.tcMenu = new System.Windows.Forms.TabControl();
            // ─── TAB 1: Registrar ────────────────────────────────────────────
            this.tpRegistrar = new System.Windows.Forms.TabPage();
            this.lblTitleReg = new System.Windows.Forms.Label();
            this.gpbDatosReg = new System.Windows.Forms.GroupBox();
            this.lblDniReg = new System.Windows.Forms.Label();
            this.txtDniReg = new System.Windows.Forms.TextBox();
            this.lblNombreReg = new System.Windows.Forms.Label();
            this.txtNombreReg = new System.Windows.Forms.TextBox();
            this.lblApellidoReg = new System.Windows.Forms.Label();
            this.txtApellidoReg = new System.Windows.Forms.TextBox();
            this.lblMailReg = new System.Windows.Forms.Label();
            this.txtMailReg = new System.Windows.Forms.TextBox();
            this.lblContrasenaReg = new System.Windows.Forms.Label();
            this.txtContrasenaReg = new System.Windows.Forms.TextBox();
            this.chkMostrarReg = new System.Windows.Forms.CheckBox();
            this.lblTelefonoReg = new System.Windows.Forms.Label();
            this.txtTelefonoReg = new System.Windows.Forms.TextBox();
            this.lblPerfilReg = new System.Windows.Forms.Label();
            this.cmbPerfilReg = new System.Windows.Forms.ComboBox();
            this.lblRedSocialReg = new System.Windows.Forms.Label();
            this.cmbRedSocialReg = new System.Windows.Forms.ComboBox();
            this.lblHandleReg = new System.Windows.Forms.Label();
            this.txtHandleReg = new System.Windows.Forms.TextBox();
            this.gpbDomiciliosReg = new System.Windows.Forms.GroupBox();
            this.lblDireccionReg = new System.Windows.Forms.Label();
            this.txtDireccionReg = new System.Windows.Forms.TextBox();
            this.btnGoogleMapsReg = new System.Windows.Forms.Button();
            this.lblProvinciaReg = new System.Windows.Forms.Label();
            this.cmbProvinciaReg = new System.Windows.Forms.ComboBox();
            this.lblLocalidadReg = new System.Windows.Forms.Label();
            this.cmbLocalidadReg = new System.Windows.Forms.ComboBox();
            this.btnAgregarDomReg = new System.Windows.Forms.Button();
            this.dgvDomiciliosReg = new System.Windows.Forms.DataGridView();
            this.colDirReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProvReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProvReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLocReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocReg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminarDomReg = new System.Windows.Forms.Button();
            this.btnLimpiarReg = new System.Windows.Forms.Button();
            this.btnRegistrarUsuario = new System.Windows.Forms.Button();
            // ─── TAB 2: Editar ───────────────────────────────────────────────
            this.tpEditar = new System.Windows.Forms.TabPage();
            this.lblTitleEdit = new System.Windows.Forms.Label();
            this.lblSelUsrEdit = new System.Windows.Forms.Label();
            this.cmbSelUsrEdit = new System.Windows.Forms.ComboBox();
            this.gpbDatosEdit = new System.Windows.Forms.GroupBox();
            this.lblNombreEdit = new System.Windows.Forms.Label();
            this.txtNombreEdit = new System.Windows.Forms.TextBox();
            this.lblApellidoEdit = new System.Windows.Forms.Label();
            this.txtApellidoEdit = new System.Windows.Forms.TextBox();
            this.lblMailEdit = new System.Windows.Forms.Label();
            this.txtMailEdit = new System.Windows.Forms.TextBox();
            this.lblContrasenaEdit = new System.Windows.Forms.Label();
            this.txtContrasenaEdit = new System.Windows.Forms.TextBox();
            this.chkMostrarEdit = new System.Windows.Forms.CheckBox();
            this.lblTelefonoEdit = new System.Windows.Forms.Label();
            this.txtTelefonoEdit = new System.Windows.Forms.TextBox();
            this.lblRedSocialEdit = new System.Windows.Forms.Label();
            this.cmbRedSocialEdit = new System.Windows.Forms.ComboBox();
            this.lblHandleEdit = new System.Windows.Forms.Label();
            this.txtHandleEdit = new System.Windows.Forms.TextBox();
            this.chkActivoEdit = new System.Windows.Forms.CheckBox();
            this.lblNotaEdit = new System.Windows.Forms.Label();
            this.btnGuardarEdit = new System.Windows.Forms.Button();
            // ─── TAB 3: Estado ───────────────────────────────────────────────
            this.tpEstado = new System.Windows.Forms.TabPage();
            this.lblTitleBaja = new System.Windows.Forms.Label();
            this.lblSelUsrBaja = new System.Windows.Forms.Label();
            this.cmbSelUsrBaja = new System.Windows.Forms.ComboBox();
            this.gpbEstadoBaja = new System.Windows.Forms.GroupBox();
            this.lblNombreCompletoBaja = new System.Windows.Forms.Label();
            this.lblMailMostrarBaja = new System.Windows.Forms.Label();
            this.panelEstadoBaja = new System.Windows.Forms.Panel();
            this.lblIconoEstado = new System.Windows.Forms.Label();
            this.lblEstadoBaja = new System.Windows.Forms.Label();
            this.btnActivarBaja = new System.Windows.Forms.Button();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            // ─── TAB 4: Conexión ─────────────────────────────────────────────
            this.tpConexion = new System.Windows.Forms.TabPage();
            this.lblTitleConn = new System.Windows.Forms.Label();
            this.gpbConexionInfo = new System.Windows.Forms.GroupBox();
            this.lblIconoEstadoConn = new System.Windows.Forms.Label();
            this.lblEstadoConnInfo = new System.Windows.Forms.Label();
            this.lblArchivoTitulo = new System.Windows.Forms.Label();
            this.lblArchivoConn = new System.Windows.Forms.Label();
            this.lblProveedorTitulo = new System.Windows.Forms.Label();
            this.lblProveedorConn = new System.Windows.Forms.Label();
            this.lblFechaConexionTitulo = new System.Windows.Forms.Label();
            this.lblFechaConexionConn = new System.Windows.Forms.Label();
            this.panelEstadoConn = new System.Windows.Forms.Panel();
            this.pbConexionConn = new System.Windows.Forms.ProgressBar();
            this.btnReconectar = new System.Windows.Forms.Button();

            this.stEstadoConexion.SuspendLayout();
            this.tcMenu.SuspendLayout();
            this.tpRegistrar.SuspendLayout();
            this.gpbDatosReg.SuspendLayout();
            this.gpbDomiciliosReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomiciliosReg)).BeginInit();
            this.tpEditar.SuspendLayout();
            this.gpbDatosEdit.SuspendLayout();
            this.tpEstado.SuspendLayout();
            this.gpbEstadoBaja.SuspendLayout();
            this.panelEstadoBaja.SuspendLayout();
            this.tpConexion.SuspendLayout();
            this.gpbConexionInfo.SuspendLayout();
            this.SuspendLayout();

            // ================================================================
            //  STATUS STRIP
            // ================================================================
            this.stEstadoConexion.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.stEstadoConexion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.tsslEstado,
                this.BarraDeEstado });
            this.stEstadoConexion.Location = new System.Drawing.Point(0, 688);
            this.stEstadoConexion.Name = "stEstadoConexion";
            this.stEstadoConexion.Size = new System.Drawing.Size(980, 22);
            this.stEstadoConexion.TabIndex = 0;

            this.tsslEstado.ForeColor = System.Drawing.Color.White;
            this.tsslEstado.Name = "tsslEstado";
            this.tsslEstado.Size = new System.Drawing.Size(120, 17);
            this.tsslEstado.Text = "Base de Datos:";

            this.BarraDeEstado.Name = "BarraDeEstado";
            this.BarraDeEstado.Size = new System.Drawing.Size(100, 16);

            // lblConexion (overlay)
            this.lblConexion.AutoSize = true;
            this.lblConexion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblConexion.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblConexion.BackColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblConexion.Location = new System.Drawing.Point(230, 693);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(80, 13);
            this.lblConexion.TabIndex = 1;
            this.lblConexion.Text = "";

            // ================================================================
            //  TAB CONTROL
            // ================================================================
            this.tcMenu.Controls.Add(this.tpRegistrar);
            this.tcMenu.Controls.Add(this.tpEditar);
            this.tcMenu.Controls.Add(this.tpEstado);
            this.tcMenu.Controls.Add(this.tpConexion);
            this.tcMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.tcMenu.Location = new System.Drawing.Point(10, 10);
            this.tcMenu.Name = "tcMenu";
            this.tcMenu.SelectedIndex = 0;
            this.tcMenu.Size = new System.Drawing.Size(960, 670);
            this.tcMenu.TabIndex = 2;
            this.tcMenu.ItemSize = new System.Drawing.Size(225, 26);
            this.tcMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;

            // ================================================================
            //  TAB 1 – REGISTRAR USUARIO
            // ================================================================
            this.tpRegistrar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.tpRegistrar.Controls.Add(this.lblTitleReg);
            this.tpRegistrar.Controls.Add(this.gpbDatosReg);
            this.tpRegistrar.Controls.Add(this.gpbDomiciliosReg);
            this.tpRegistrar.Controls.Add(this.btnLimpiarReg);
            this.tpRegistrar.Controls.Add(this.btnRegistrarUsuario);
            this.tpRegistrar.Location = new System.Drawing.Point(4, 30);
            this.tpRegistrar.Name = "tpRegistrar";
            this.tpRegistrar.Size = new System.Drawing.Size(952, 636);
            this.tpRegistrar.TabIndex = 0;
            this.tpRegistrar.Text = "   👤 Registrar Usuario   ";

            // lblTitleReg
            this.lblTitleReg.AutoSize = true;
            this.lblTitleReg.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleReg.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblTitleReg.Location = new System.Drawing.Point(10, 10);
            this.lblTitleReg.Name = "lblTitleReg";
            this.lblTitleReg.TabIndex = 0;
            this.lblTitleReg.Text = "👤 Registrar Nuevo Usuario";

            // gpbDatosReg
            this.gpbDatosReg.Controls.Add(this.lblDniReg);
            this.gpbDatosReg.Controls.Add(this.txtDniReg);
            this.gpbDatosReg.Controls.Add(this.lblNombreReg);
            this.gpbDatosReg.Controls.Add(this.txtNombreReg);
            this.gpbDatosReg.Controls.Add(this.lblApellidoReg);
            this.gpbDatosReg.Controls.Add(this.txtApellidoReg);
            this.gpbDatosReg.Controls.Add(this.lblMailReg);
            this.gpbDatosReg.Controls.Add(this.txtMailReg);
            this.gpbDatosReg.Controls.Add(this.lblContrasenaReg);
            this.gpbDatosReg.Controls.Add(this.txtContrasenaReg);
            this.gpbDatosReg.Controls.Add(this.chkMostrarReg);
            this.gpbDatosReg.Controls.Add(this.lblTelefonoReg);
            this.gpbDatosReg.Controls.Add(this.txtTelefonoReg);
            this.gpbDatosReg.Controls.Add(this.lblPerfilReg);
            this.gpbDatosReg.Controls.Add(this.cmbPerfilReg);
            this.gpbDatosReg.Controls.Add(this.lblRedSocialReg);
            this.gpbDatosReg.Controls.Add(this.cmbRedSocialReg);
            this.gpbDatosReg.Controls.Add(this.lblHandleReg);
            this.gpbDatosReg.Controls.Add(this.txtHandleReg);
            this.gpbDatosReg.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gpbDatosReg.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.gpbDatosReg.Location = new System.Drawing.Point(10, 45);
            this.gpbDatosReg.Name = "gpbDatosReg";
            this.gpbDatosReg.Size = new System.Drawing.Size(930, 210);
            this.gpbDatosReg.TabIndex = 1;
            this.gpbDatosReg.TabStop = false;
            this.gpbDatosReg.Text = " Datos Personales y de Acceso ";

            // --- Fila 1: DNI, Nombre, Apellido, Mail ---
            this.lblDniReg.AutoSize = true;
            this.lblDniReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDniReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDniReg.Location = new System.Drawing.Point(10, 25);
            this.lblDniReg.Name = "lblDniReg";
            this.lblDniReg.TabIndex = 0;
            this.lblDniReg.Text = "DNI: *";

            this.txtDniReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDniReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDniReg.Location = new System.Drawing.Point(10, 43);
            this.txtDniReg.MaxLength = 8;
            this.txtDniReg.Name = "txtDniReg";
            this.txtDniReg.Size = new System.Drawing.Size(115, 24);
            this.txtDniReg.TabIndex = 1;

            this.lblNombreReg.AutoSize = true;
            this.lblNombreReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblNombreReg.Location = new System.Drawing.Point(140, 25);
            this.lblNombreReg.Name = "lblNombreReg";
            this.lblNombreReg.TabIndex = 2;
            this.lblNombreReg.Text = "Nombre: *";

            this.txtNombreReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreReg.Location = new System.Drawing.Point(140, 43);
            this.txtNombreReg.Name = "txtNombreReg";
            this.txtNombreReg.Size = new System.Drawing.Size(190, 24);
            this.txtNombreReg.TabIndex = 3;

            this.lblApellidoReg.AutoSize = true;
            this.lblApellidoReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApellidoReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblApellidoReg.Location = new System.Drawing.Point(345, 25);
            this.lblApellidoReg.Name = "lblApellidoReg";
            this.lblApellidoReg.TabIndex = 4;
            this.lblApellidoReg.Text = "Apellido: *";

            this.txtApellidoReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellidoReg.Location = new System.Drawing.Point(345, 43);
            this.txtApellidoReg.Name = "txtApellidoReg";
            this.txtApellidoReg.Size = new System.Drawing.Size(190, 24);
            this.txtApellidoReg.TabIndex = 5;

            this.lblMailReg.AutoSize = true;
            this.lblMailReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMailReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblMailReg.Location = new System.Drawing.Point(550, 25);
            this.lblMailReg.Name = "lblMailReg";
            this.lblMailReg.TabIndex = 6;
            this.lblMailReg.Text = "Correo electrónico: *";

            this.txtMailReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMailReg.Location = new System.Drawing.Point(550, 43);
            this.txtMailReg.Name = "txtMailReg";
            this.txtMailReg.Size = new System.Drawing.Size(365, 24);
            this.txtMailReg.TabIndex = 7;

            // --- Fila 2: Contraseña, Teléfono, Perfil ---
            this.lblContrasenaReg.AutoSize = true;
            this.lblContrasenaReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContrasenaReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblContrasenaReg.Location = new System.Drawing.Point(10, 80);
            this.lblContrasenaReg.Name = "lblContrasenaReg";
            this.lblContrasenaReg.TabIndex = 8;
            this.lblContrasenaReg.Text = "Contraseña: *";

            this.txtContrasenaReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasenaReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContrasenaReg.Location = new System.Drawing.Point(10, 98);
            this.txtContrasenaReg.Name = "txtContrasenaReg";
            this.txtContrasenaReg.PasswordChar = '•';
            this.txtContrasenaReg.Size = new System.Drawing.Size(190, 24);
            this.txtContrasenaReg.TabIndex = 9;

            this.chkMostrarReg.AutoSize = true;
            this.chkMostrarReg.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarReg.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkMostrarReg.Location = new System.Drawing.Point(210, 101);
            this.chkMostrarReg.Name = "chkMostrarReg";
            this.chkMostrarReg.Size = new System.Drawing.Size(110, 19);
            this.chkMostrarReg.TabIndex = 10;
            this.chkMostrarReg.Text = "👁 Mostrar";
            this.chkMostrarReg.UseVisualStyleBackColor = true;
            this.chkMostrarReg.CheckedChanged += new System.EventHandler(this.chkMostrarReg_CheckedChanged);

            this.lblTelefonoReg.AutoSize = true;
            this.lblTelefonoReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefonoReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblTelefonoReg.Location = new System.Drawing.Point(345, 80);
            this.lblTelefonoReg.Name = "lblTelefonoReg";
            this.lblTelefonoReg.TabIndex = 11;
            this.lblTelefonoReg.Text = "Teléfono:";

            this.txtTelefonoReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefonoReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefonoReg.Location = new System.Drawing.Point(345, 98);
            this.txtTelefonoReg.Name = "txtTelefonoReg";
            this.txtTelefonoReg.Size = new System.Drawing.Size(160, 24);
            this.txtTelefonoReg.TabIndex = 12;

            this.lblPerfilReg.AutoSize = true;
            this.lblPerfilReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPerfilReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblPerfilReg.Location = new System.Drawing.Point(520, 80);
            this.lblPerfilReg.Name = "lblPerfilReg";
            this.lblPerfilReg.TabIndex = 13;
            this.lblPerfilReg.Text = "Perfil de acceso: *";

            this.cmbPerfilReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPerfilReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPerfilReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbPerfilReg.FormattingEnabled = true;
            this.cmbPerfilReg.Location = new System.Drawing.Point(520, 97);
            this.cmbPerfilReg.Name = "cmbPerfilReg";
            this.cmbPerfilReg.Size = new System.Drawing.Size(395, 25);
            this.cmbPerfilReg.TabIndex = 14;

            // --- Fila 3: Red Social ---
            this.lblRedSocialReg.AutoSize = true;
            this.lblRedSocialReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRedSocialReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblRedSocialReg.Location = new System.Drawing.Point(10, 137);
            this.lblRedSocialReg.Name = "lblRedSocialReg";
            this.lblRedSocialReg.TabIndex = 15;
            this.lblRedSocialReg.Text = "Red Social:";

            this.cmbRedSocialReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRedSocialReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRedSocialReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbRedSocialReg.FormattingEnabled = true;
            this.cmbRedSocialReg.Items.AddRange(new object[] { "(Ninguna)", "Facebook", "Instagram", "Twitter / X", "LinkedIn", "TikTok", "WhatsApp", "YouTube", "Pinterest", "Snapchat" });
            this.cmbRedSocialReg.Location = new System.Drawing.Point(10, 155);
            this.cmbRedSocialReg.Name = "cmbRedSocialReg";
            this.cmbRedSocialReg.Size = new System.Drawing.Size(155, 25);
            this.cmbRedSocialReg.TabIndex = 16;
            this.cmbRedSocialReg.SelectedIndex = 0;

            this.lblHandleReg.AutoSize = true;
            this.lblHandleReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHandleReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblHandleReg.Location = new System.Drawing.Point(180, 137);
            this.lblHandleReg.Name = "lblHandleReg";
            this.lblHandleReg.TabIndex = 17;
            this.lblHandleReg.Text = "Usuario / Perfil en la red:";

            this.txtHandleReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHandleReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtHandleReg.Location = new System.Drawing.Point(180, 155);
            this.txtHandleReg.Name = "txtHandleReg";
            this.txtHandleReg.Size = new System.Drawing.Size(240, 24);
            this.txtHandleReg.TabIndex = 18;

            // gpbDomiciliosReg
            this.gpbDomiciliosReg.Controls.Add(this.lblDireccionReg);
            this.gpbDomiciliosReg.Controls.Add(this.txtDireccionReg);
            this.gpbDomiciliosReg.Controls.Add(this.btnGoogleMapsReg);
            this.gpbDomiciliosReg.Controls.Add(this.lblProvinciaReg);
            this.gpbDomiciliosReg.Controls.Add(this.cmbProvinciaReg);
            this.gpbDomiciliosReg.Controls.Add(this.lblLocalidadReg);
            this.gpbDomiciliosReg.Controls.Add(this.cmbLocalidadReg);
            this.gpbDomiciliosReg.Controls.Add(this.btnAgregarDomReg);
            this.gpbDomiciliosReg.Controls.Add(this.dgvDomiciliosReg);
            this.gpbDomiciliosReg.Controls.Add(this.btnEliminarDomReg);
            this.gpbDomiciliosReg.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gpbDomiciliosReg.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.gpbDomiciliosReg.Location = new System.Drawing.Point(10, 265);
            this.gpbDomiciliosReg.Name = "gpbDomiciliosReg";
            this.gpbDomiciliosReg.Size = new System.Drawing.Size(930, 265);
            this.gpbDomiciliosReg.TabIndex = 2;
            this.gpbDomiciliosReg.TabStop = false;
            this.gpbDomiciliosReg.Text = " 📍 Domicilios (puede agregar varios) ";

            this.lblDireccionReg.AutoSize = true;
            this.lblDireccionReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccionReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblDireccionReg.Location = new System.Drawing.Point(10, 22);
            this.lblDireccionReg.Name = "lblDireccionReg";
            this.lblDireccionReg.TabIndex = 0;
            this.lblDireccionReg.Text = "Dirección (Calle, Nro., Piso, Dpto.):";

            this.txtDireccionReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccionReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccionReg.Location = new System.Drawing.Point(10, 40);
            this.txtDireccionReg.Name = "txtDireccionReg";
            this.txtDireccionReg.Size = new System.Drawing.Size(775, 24);
            this.txtDireccionReg.TabIndex = 1;

            this.btnGoogleMapsReg.BackColor = System.Drawing.Color.FromArgb(7, 89, 133);
            this.btnGoogleMapsReg.FlatAppearance.BorderSize = 0;
            this.btnGoogleMapsReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoogleMapsReg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGoogleMapsReg.ForeColor = System.Drawing.Color.White;
            this.btnGoogleMapsReg.Location = new System.Drawing.Point(795, 38);
            this.btnGoogleMapsReg.Name = "btnGoogleMapsReg";
            this.btnGoogleMapsReg.Size = new System.Drawing.Size(125, 28);
            this.btnGoogleMapsReg.TabIndex = 2;
            this.btnGoogleMapsReg.Text = "🗺️ Google Maps";
            this.btnGoogleMapsReg.UseVisualStyleBackColor = false;
            this.btnGoogleMapsReg.Click += new System.EventHandler(this.btnGoogleMapsReg_Click);

            this.lblProvinciaReg.AutoSize = true;
            this.lblProvinciaReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProvinciaReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblProvinciaReg.Location = new System.Drawing.Point(10, 78);
            this.lblProvinciaReg.Name = "lblProvinciaReg";
            this.lblProvinciaReg.TabIndex = 3;
            this.lblProvinciaReg.Text = "Provincia:";

            this.cmbProvinciaReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvinciaReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProvinciaReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbProvinciaReg.FormattingEnabled = true;
            this.cmbProvinciaReg.Location = new System.Drawing.Point(10, 96);
            this.cmbProvinciaReg.Name = "cmbProvinciaReg";
            this.cmbProvinciaReg.Size = new System.Drawing.Size(200, 25);
            this.cmbProvinciaReg.TabIndex = 4;
            this.cmbProvinciaReg.SelectedIndexChanged += new System.EventHandler(this.cmbProvinciaReg_SelectedIndexChanged);

            this.lblLocalidadReg.AutoSize = true;
            this.lblLocalidadReg.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocalidadReg.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblLocalidadReg.Location = new System.Drawing.Point(225, 78);
            this.lblLocalidadReg.Name = "lblLocalidadReg";
            this.lblLocalidadReg.TabIndex = 5;
            this.lblLocalidadReg.Text = "Localidad (solo Córdoba):";

            this.cmbLocalidadReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidadReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLocalidadReg.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbLocalidadReg.FormattingEnabled = true;
            this.cmbLocalidadReg.Location = new System.Drawing.Point(225, 96);
            this.cmbLocalidadReg.Name = "cmbLocalidadReg";
            this.cmbLocalidadReg.Size = new System.Drawing.Size(200, 25);
            this.cmbLocalidadReg.TabIndex = 6;

            this.btnAgregarDomReg.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnAgregarDomReg.FlatAppearance.BorderSize = 0;
            this.btnAgregarDomReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDomReg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAgregarDomReg.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDomReg.Location = new System.Drawing.Point(440, 94);
            this.btnAgregarDomReg.Name = "btnAgregarDomReg";
            this.btnAgregarDomReg.Size = new System.Drawing.Size(130, 28);
            this.btnAgregarDomReg.TabIndex = 7;
            this.btnAgregarDomReg.Text = "➕ Agregar";
            this.btnAgregarDomReg.UseVisualStyleBackColor = false;
            this.btnAgregarDomReg.Click += new System.EventHandler(this.btnAgregarDomReg_Click);

            // DataGridView domicilios
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvDomiciliosReg.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDomiciliosReg.AllowUserToAddRows = false;
            this.dgvDomiciliosReg.AllowUserToDeleteRows = false;
            this.dgvDomiciliosReg.BackgroundColor = System.Drawing.Color.White;
            this.dgvDomiciliosReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDomiciliosReg.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDomiciliosReg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDomiciliosReg.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colDirReg, this.colIdProvReg, this.colProvReg, this.colIdLocReg, this.colLocReg });
            this.dgvDomiciliosReg.GridColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.dgvDomiciliosReg.Location = new System.Drawing.Point(10, 134);
            this.dgvDomiciliosReg.Name = "dgvDomiciliosReg";
            this.dgvDomiciliosReg.ReadOnly = true;
            this.dgvDomiciliosReg.RowHeadersVisible = false;
            this.dgvDomiciliosReg.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDomiciliosReg.Size = new System.Drawing.Size(910, 100);
            this.dgvDomiciliosReg.TabIndex = 8;

            this.colDirReg.HeaderText = "Dirección";
            this.colDirReg.Name = "colDirReg";
            this.colDirReg.ReadOnly = true;
            this.colDirReg.Width = 390;

            this.colIdProvReg.HeaderText = "IdProv";
            this.colIdProvReg.Name = "colIdProvReg";
            this.colIdProvReg.ReadOnly = true;
            this.colIdProvReg.Visible = false;

            this.colProvReg.HeaderText = "Provincia";
            this.colProvReg.Name = "colProvReg";
            this.colProvReg.ReadOnly = true;
            this.colProvReg.Width = 220;

            this.colIdLocReg.HeaderText = "IdLoc";
            this.colIdLocReg.Name = "colIdLocReg";
            this.colIdLocReg.ReadOnly = true;
            this.colIdLocReg.Visible = false;

            this.colLocReg.HeaderText = "Localidad";
            this.colLocReg.Name = "colLocReg";
            this.colLocReg.ReadOnly = true;
            this.colLocReg.Width = 220;

            this.btnEliminarDomReg.BackColor = System.Drawing.Color.FromArgb(153, 27, 27);
            this.btnEliminarDomReg.FlatAppearance.BorderSize = 0;
            this.btnEliminarDomReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDomReg.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarDomReg.ForeColor = System.Drawing.Color.White;
            this.btnEliminarDomReg.Location = new System.Drawing.Point(790, 243);
            this.btnEliminarDomReg.Name = "btnEliminarDomReg";
            this.btnEliminarDomReg.Size = new System.Drawing.Size(130, 28);
            this.btnEliminarDomReg.TabIndex = 9;
            this.btnEliminarDomReg.Text = "🗑️ Eliminar Selec.";
            this.btnEliminarDomReg.UseVisualStyleBackColor = false;
            this.btnEliminarDomReg.Click += new System.EventHandler(this.btnEliminarDomReg_Click);

            // Botones finales del tab
            this.btnLimpiarReg.BackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnLimpiarReg.FlatAppearance.BorderSize = 0;
            this.btnLimpiarReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarReg.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiarReg.ForeColor = System.Drawing.Color.White;
            this.btnLimpiarReg.Location = new System.Drawing.Point(10, 545);
            this.btnLimpiarReg.Name = "btnLimpiarReg";
            this.btnLimpiarReg.Size = new System.Drawing.Size(155, 40);
            this.btnLimpiarReg.TabIndex = 3;
            this.btnLimpiarReg.Text = "🔄 Limpiar";
            this.btnLimpiarReg.UseVisualStyleBackColor = false;
            this.btnLimpiarReg.Click += new System.EventHandler(this.btnLimpiarReg_Click);

            this.btnRegistrarUsuario.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnRegistrarUsuario.FlatAppearance.BorderSize = 0;
            this.btnRegistrarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarUsuario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRegistrarUsuario.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarUsuario.Location = new System.Drawing.Point(770, 545);
            this.btnRegistrarUsuario.Name = "btnRegistrarUsuario";
            this.btnRegistrarUsuario.Size = new System.Drawing.Size(172, 40);
            this.btnRegistrarUsuario.TabIndex = 4;
            this.btnRegistrarUsuario.Text = "💾 REGISTRAR USUARIO";
            this.btnRegistrarUsuario.UseVisualStyleBackColor = false;
            this.btnRegistrarUsuario.Click += new System.EventHandler(this.btnRegistrarUsuario_Click);

            // ================================================================
            //  TAB 2 – EDITAR USUARIO
            // ================================================================
            this.tpEditar.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.tpEditar.Controls.Add(this.lblTitleEdit);
            this.tpEditar.Controls.Add(this.lblSelUsrEdit);
            this.tpEditar.Controls.Add(this.cmbSelUsrEdit);
            this.tpEditar.Controls.Add(this.gpbDatosEdit);
            this.tpEditar.Controls.Add(this.btnGuardarEdit);
            this.tpEditar.Location = new System.Drawing.Point(4, 30);
            this.tpEditar.Name = "tpEditar";
            this.tpEditar.Size = new System.Drawing.Size(952, 636);
            this.tpEditar.TabIndex = 1;
            this.tpEditar.Text = "   ✏️ Editar Usuario   ";
            this.tpEditar.Enter += new System.EventHandler(this.tpEditar_Enter);

            this.lblTitleEdit.AutoSize = true;
            this.lblTitleEdit.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleEdit.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblTitleEdit.Location = new System.Drawing.Point(10, 10);
            this.lblTitleEdit.Name = "lblTitleEdit";
            this.lblTitleEdit.TabIndex = 0;
            this.lblTitleEdit.Text = "✏️ Editar Datos del Usuario";

            this.lblSelUsrEdit.AutoSize = true;
            this.lblSelUsrEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSelUsrEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblSelUsrEdit.Location = new System.Drawing.Point(10, 50);
            this.lblSelUsrEdit.Name = "lblSelUsrEdit";
            this.lblSelUsrEdit.TabIndex = 1;
            this.lblSelUsrEdit.Text = "Seleccionar Usuario:";

            this.cmbSelUsrEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelUsrEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSelUsrEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSelUsrEdit.FormattingEnabled = true;
            this.cmbSelUsrEdit.Location = new System.Drawing.Point(10, 68);
            this.cmbSelUsrEdit.Name = "cmbSelUsrEdit";
            this.cmbSelUsrEdit.Size = new System.Drawing.Size(930, 25);
            this.cmbSelUsrEdit.TabIndex = 2;
            this.cmbSelUsrEdit.SelectedIndexChanged += new System.EventHandler(this.cmbSelUsrEdit_SelectedIndexChanged);

            this.gpbDatosEdit.Controls.Add(this.lblNombreEdit);
            this.gpbDatosEdit.Controls.Add(this.txtNombreEdit);
            this.gpbDatosEdit.Controls.Add(this.lblApellidoEdit);
            this.gpbDatosEdit.Controls.Add(this.txtApellidoEdit);
            this.gpbDatosEdit.Controls.Add(this.lblMailEdit);
            this.gpbDatosEdit.Controls.Add(this.txtMailEdit);
            this.gpbDatosEdit.Controls.Add(this.lblContrasenaEdit);
            this.gpbDatosEdit.Controls.Add(this.txtContrasenaEdit);
            this.gpbDatosEdit.Controls.Add(this.chkMostrarEdit);
            this.gpbDatosEdit.Controls.Add(this.lblTelefonoEdit);
            this.gpbDatosEdit.Controls.Add(this.txtTelefonoEdit);
            this.gpbDatosEdit.Controls.Add(this.lblRedSocialEdit);
            this.gpbDatosEdit.Controls.Add(this.cmbRedSocialEdit);
            this.gpbDatosEdit.Controls.Add(this.lblHandleEdit);
            this.gpbDatosEdit.Controls.Add(this.txtHandleEdit);
            this.gpbDatosEdit.Controls.Add(this.chkActivoEdit);
            this.gpbDatosEdit.Controls.Add(this.lblNotaEdit);
            this.gpbDatosEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gpbDatosEdit.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.gpbDatosEdit.Location = new System.Drawing.Point(10, 108);
            this.gpbDatosEdit.Name = "gpbDatosEdit";
            this.gpbDatosEdit.Size = new System.Drawing.Size(930, 310);
            this.gpbDatosEdit.TabIndex = 3;
            this.gpbDatosEdit.TabStop = false;
            this.gpbDatosEdit.Text = " Datos Editables ";

            this.lblNombreEdit.AutoSize = true;
            this.lblNombreEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblNombreEdit.Location = new System.Drawing.Point(10, 25);
            this.lblNombreEdit.Name = "lblNombreEdit";
            this.lblNombreEdit.TabIndex = 0;
            this.lblNombreEdit.Text = "Nombre:";

            this.txtNombreEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombreEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtNombreEdit.Location = new System.Drawing.Point(10, 43);
            this.txtNombreEdit.Name = "txtNombreEdit";
            this.txtNombreEdit.Size = new System.Drawing.Size(200, 24);
            this.txtNombreEdit.TabIndex = 1;

            this.lblApellidoEdit.AutoSize = true;
            this.lblApellidoEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblApellidoEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblApellidoEdit.Location = new System.Drawing.Point(225, 25);
            this.lblApellidoEdit.Name = "lblApellidoEdit";
            this.lblApellidoEdit.TabIndex = 2;
            this.lblApellidoEdit.Text = "Apellido:";

            this.txtApellidoEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellidoEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtApellidoEdit.Location = new System.Drawing.Point(225, 43);
            this.txtApellidoEdit.Name = "txtApellidoEdit";
            this.txtApellidoEdit.Size = new System.Drawing.Size(200, 24);
            this.txtApellidoEdit.TabIndex = 3;

            this.lblMailEdit.AutoSize = true;
            this.lblMailEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMailEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblMailEdit.Location = new System.Drawing.Point(440, 25);
            this.lblMailEdit.Name = "lblMailEdit";
            this.lblMailEdit.TabIndex = 4;
            this.lblMailEdit.Text = "Correo electrónico:";

            this.txtMailEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtMailEdit.Location = new System.Drawing.Point(440, 43);
            this.txtMailEdit.Name = "txtMailEdit";
            this.txtMailEdit.Size = new System.Drawing.Size(475, 24);
            this.txtMailEdit.TabIndex = 5;

            this.lblContrasenaEdit.AutoSize = true;
            this.lblContrasenaEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblContrasenaEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblContrasenaEdit.Location = new System.Drawing.Point(10, 83);
            this.lblContrasenaEdit.Name = "lblContrasenaEdit";
            this.lblContrasenaEdit.TabIndex = 6;
            this.lblContrasenaEdit.Text = "Nueva contraseña (dejar vacío para no cambiar):";

            this.txtContrasenaEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasenaEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtContrasenaEdit.Location = new System.Drawing.Point(10, 101);
            this.txtContrasenaEdit.Name = "txtContrasenaEdit";
            this.txtContrasenaEdit.PasswordChar = '•';
            this.txtContrasenaEdit.Size = new System.Drawing.Size(200, 24);
            this.txtContrasenaEdit.TabIndex = 7;

            this.chkMostrarEdit.AutoSize = true;
            this.chkMostrarEdit.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.chkMostrarEdit.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.chkMostrarEdit.Location = new System.Drawing.Point(220, 104);
            this.chkMostrarEdit.Name = "chkMostrarEdit";
            this.chkMostrarEdit.Size = new System.Drawing.Size(90, 19);
            this.chkMostrarEdit.TabIndex = 8;
            this.chkMostrarEdit.Text = "👁 Mostrar";
            this.chkMostrarEdit.UseVisualStyleBackColor = true;
            this.chkMostrarEdit.CheckedChanged += new System.EventHandler(this.chkMostrarEdit_CheckedChanged);

            this.lblTelefonoEdit.AutoSize = true;
            this.lblTelefonoEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefonoEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblTelefonoEdit.Location = new System.Drawing.Point(440, 83);
            this.lblTelefonoEdit.Name = "lblTelefonoEdit";
            this.lblTelefonoEdit.TabIndex = 9;
            this.lblTelefonoEdit.Text = "Teléfono:";

            this.txtTelefonoEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefonoEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTelefonoEdit.Location = new System.Drawing.Point(440, 101);
            this.txtTelefonoEdit.Name = "txtTelefonoEdit";
            this.txtTelefonoEdit.Size = new System.Drawing.Size(190, 24);
            this.txtTelefonoEdit.TabIndex = 10;

            this.lblRedSocialEdit.AutoSize = true;
            this.lblRedSocialEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRedSocialEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblRedSocialEdit.Location = new System.Drawing.Point(10, 142);
            this.lblRedSocialEdit.Name = "lblRedSocialEdit";
            this.lblRedSocialEdit.TabIndex = 11;
            this.lblRedSocialEdit.Text = "Red Social:";

            this.cmbRedSocialEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRedSocialEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRedSocialEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbRedSocialEdit.FormattingEnabled = true;
            this.cmbRedSocialEdit.Items.AddRange(new object[] { "(Ninguna)", "Facebook", "Instagram", "Twitter / X", "LinkedIn", "TikTok", "WhatsApp", "YouTube", "Pinterest", "Snapchat" });
            this.cmbRedSocialEdit.Location = new System.Drawing.Point(10, 160);
            this.cmbRedSocialEdit.Name = "cmbRedSocialEdit";
            this.cmbRedSocialEdit.Size = new System.Drawing.Size(155, 25);
            this.cmbRedSocialEdit.TabIndex = 12;

            this.lblHandleEdit.AutoSize = true;
            this.lblHandleEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHandleEdit.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblHandleEdit.Location = new System.Drawing.Point(180, 142);
            this.lblHandleEdit.Name = "lblHandleEdit";
            this.lblHandleEdit.TabIndex = 13;
            this.lblHandleEdit.Text = "Usuario / Perfil en la red:";

            this.txtHandleEdit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHandleEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtHandleEdit.Location = new System.Drawing.Point(180, 160);
            this.txtHandleEdit.Name = "txtHandleEdit";
            this.txtHandleEdit.Size = new System.Drawing.Size(240, 24);
            this.txtHandleEdit.TabIndex = 14;

            this.chkActivoEdit.AutoSize = true;
            this.chkActivoEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkActivoEdit.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.chkActivoEdit.Location = new System.Drawing.Point(10, 210);
            this.chkActivoEdit.Name = "chkActivoEdit";
            this.chkActivoEdit.Size = new System.Drawing.Size(150, 23);
            this.chkActivoEdit.TabIndex = 15;
            this.chkActivoEdit.Text = "✔ Usuario Activo";
            this.chkActivoEdit.UseVisualStyleBackColor = true;

            this.lblNotaEdit.AutoSize = true;
            this.lblNotaEdit.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblNotaEdit.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblNotaEdit.Location = new System.Drawing.Point(10, 260);
            this.lblNotaEdit.Name = "lblNotaEdit";
            this.lblNotaEdit.Size = new System.Drawing.Size(500, 15);
            this.lblNotaEdit.TabIndex = 16;
            this.lblNotaEdit.Text = "ℹ️  Para dar de baja o reactivar un usuario también puede usar la pestaña 'Gestión de Estado'.";

            this.btnGuardarEdit.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnGuardarEdit.FlatAppearance.BorderSize = 0;
            this.btnGuardarEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarEdit.ForeColor = System.Drawing.Color.White;
            this.btnGuardarEdit.Location = new System.Drawing.Point(760, 440);
            this.btnGuardarEdit.Name = "btnGuardarEdit";
            this.btnGuardarEdit.Size = new System.Drawing.Size(180, 40);
            this.btnGuardarEdit.TabIndex = 4;
            this.btnGuardarEdit.Text = "💾 GUARDAR CAMBIOS";
            this.btnGuardarEdit.UseVisualStyleBackColor = false;
            this.btnGuardarEdit.Click += new System.EventHandler(this.btnGuardarEdit_Click);

            // ================================================================
            //  TAB 3 – GESTIÓN DE ESTADO
            // ================================================================
            this.tpEstado.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.tpEstado.Controls.Add(this.lblTitleBaja);
            this.tpEstado.Controls.Add(this.lblSelUsrBaja);
            this.tpEstado.Controls.Add(this.cmbSelUsrBaja);
            this.tpEstado.Controls.Add(this.gpbEstadoBaja);
            this.tpEstado.Controls.Add(this.btnActivarBaja);
            this.tpEstado.Controls.Add(this.btnDarDeBaja);
            this.tpEstado.Location = new System.Drawing.Point(4, 30);
            this.tpEstado.Name = "tpEstado";
            this.tpEstado.Size = new System.Drawing.Size(952, 636);
            this.tpEstado.TabIndex = 2;
            this.tpEstado.Text = "   🔄 Gestión de Estado   ";
            this.tpEstado.Enter += new System.EventHandler(this.tpEstado_Enter);

            this.lblTitleBaja.AutoSize = true;
            this.lblTitleBaja.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleBaja.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblTitleBaja.Location = new System.Drawing.Point(10, 10);
            this.lblTitleBaja.Name = "lblTitleBaja";
            this.lblTitleBaja.TabIndex = 0;
            this.lblTitleBaja.Text = "🔄 Gestión de Estado del Usuario";

            this.lblSelUsrBaja.AutoSize = true;
            this.lblSelUsrBaja.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblSelUsrBaja.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblSelUsrBaja.Location = new System.Drawing.Point(10, 50);
            this.lblSelUsrBaja.Name = "lblSelUsrBaja";
            this.lblSelUsrBaja.TabIndex = 1;
            this.lblSelUsrBaja.Text = "Seleccionar Usuario:";

            this.cmbSelUsrBaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelUsrBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSelUsrBaja.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbSelUsrBaja.FormattingEnabled = true;
            this.cmbSelUsrBaja.Location = new System.Drawing.Point(10, 68);
            this.cmbSelUsrBaja.Name = "cmbSelUsrBaja";
            this.cmbSelUsrBaja.Size = new System.Drawing.Size(930, 25);
            this.cmbSelUsrBaja.TabIndex = 2;
            this.cmbSelUsrBaja.SelectedIndexChanged += new System.EventHandler(this.cmbSelUsrBaja_SelectedIndexChanged);

            this.gpbEstadoBaja.Controls.Add(this.lblNombreCompletoBaja);
            this.gpbEstadoBaja.Controls.Add(this.lblMailMostrarBaja);
            this.gpbEstadoBaja.Controls.Add(this.panelEstadoBaja);
            this.gpbEstadoBaja.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gpbEstadoBaja.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.gpbEstadoBaja.Location = new System.Drawing.Point(10, 108);
            this.gpbEstadoBaja.Name = "gpbEstadoBaja";
            this.gpbEstadoBaja.Size = new System.Drawing.Size(930, 220);
            this.gpbEstadoBaja.TabIndex = 3;
            this.gpbEstadoBaja.TabStop = false;
            this.gpbEstadoBaja.Text = " Información del Usuario ";

            this.lblNombreCompletoBaja.AutoSize = true;
            this.lblNombreCompletoBaja.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblNombreCompletoBaja.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblNombreCompletoBaja.Location = new System.Drawing.Point(15, 30);
            this.lblNombreCompletoBaja.Name = "lblNombreCompletoBaja";
            this.lblNombreCompletoBaja.Size = new System.Drawing.Size(300, 25);
            this.lblNombreCompletoBaja.TabIndex = 0;
            this.lblNombreCompletoBaja.Text = "— Seleccione un usuario —";

            this.lblMailMostrarBaja.AutoSize = true;
            this.lblMailMostrarBaja.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMailMostrarBaja.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblMailMostrarBaja.Location = new System.Drawing.Point(15, 60);
            this.lblMailMostrarBaja.Name = "lblMailMostrarBaja";
            this.lblMailMostrarBaja.Size = new System.Drawing.Size(200, 19);
            this.lblMailMostrarBaja.TabIndex = 1;
            this.lblMailMostrarBaja.Text = "";

            this.panelEstadoBaja.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.panelEstadoBaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEstadoBaja.Controls.Add(this.lblIconoEstado);
            this.panelEstadoBaja.Controls.Add(this.lblEstadoBaja);
            this.panelEstadoBaja.Location = new System.Drawing.Point(15, 100);
            this.panelEstadoBaja.Name = "panelEstadoBaja";
            this.panelEstadoBaja.Size = new System.Drawing.Size(330, 80);
            this.panelEstadoBaja.TabIndex = 2;

            this.lblIconoEstado.AutoSize = true;
            this.lblIconoEstado.Font = new System.Drawing.Font("Segoe UI", 28F);
            this.lblIconoEstado.Location = new System.Drawing.Point(10, 12);
            this.lblIconoEstado.Name = "lblIconoEstado";
            this.lblIconoEstado.TabIndex = 0;
            this.lblIconoEstado.Text = "⚪";

            this.lblEstadoBaja.AutoSize = true;
            this.lblEstadoBaja.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEstadoBaja.Location = new System.Drawing.Point(65, 22);
            this.lblEstadoBaja.Name = "lblEstadoBaja";
            this.lblEstadoBaja.TabIndex = 1;
            this.lblEstadoBaja.Text = "Sin selección";

            this.btnActivarBaja.BackColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.btnActivarBaja.FlatAppearance.BorderSize = 0;
            this.btnActivarBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivarBaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnActivarBaja.ForeColor = System.Drawing.Color.White;
            this.btnActivarBaja.Location = new System.Drawing.Point(10, 360);
            this.btnActivarBaja.Name = "btnActivarBaja";
            this.btnActivarBaja.Size = new System.Drawing.Size(220, 50);
            this.btnActivarBaja.TabIndex = 4;
            this.btnActivarBaja.Text = "✅ ACTIVAR USUARIO";
            this.btnActivarBaja.UseVisualStyleBackColor = false;
            this.btnActivarBaja.Click += new System.EventHandler(this.btnActivarBaja_Click);

            this.btnDarDeBaja.BackColor = System.Drawing.Color.FromArgb(153, 27, 27);
            this.btnDarDeBaja.FlatAppearance.BorderSize = 0;
            this.btnDarDeBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarDeBaja.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDarDeBaja.ForeColor = System.Drawing.Color.White;
            this.btnDarDeBaja.Location = new System.Drawing.Point(250, 360);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(220, 50);
            this.btnDarDeBaja.TabIndex = 5;
            this.btnDarDeBaja.Text = "🚫 DAR DE BAJA";
            this.btnDarDeBaja.UseVisualStyleBackColor = false;
            this.btnDarDeBaja.Click += new System.EventHandler(this.btnDarDeBaja_Click);

            // ================================================================
            //  TAB 4 – ESTADO DE CONEXIÓN
            // ================================================================
            this.tpConexion.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            this.tpConexion.Controls.Add(this.lblTitleConn);
            this.tpConexion.Controls.Add(this.gpbConexionInfo);
            this.tpConexion.Controls.Add(this.btnReconectar);
            this.tpConexion.Location = new System.Drawing.Point(4, 30);
            this.tpConexion.Name = "tpConexion";
            this.tpConexion.Size = new System.Drawing.Size(952, 636);
            this.tpConexion.TabIndex = 3;
            this.tpConexion.Text = "   🔌 Conexión BD   ";

            this.lblTitleConn.AutoSize = true;
            this.lblTitleConn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleConn.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblTitleConn.Location = new System.Drawing.Point(10, 10);
            this.lblTitleConn.Name = "lblTitleConn";
            this.lblTitleConn.TabIndex = 0;
            this.lblTitleConn.Text = "🔌 Estado de Conexión a la Base de Datos";

            this.gpbConexionInfo.Controls.Add(this.lblIconoEstadoConn);
            this.gpbConexionInfo.Controls.Add(this.lblEstadoConnInfo);
            this.gpbConexionInfo.Controls.Add(this.pbConexionConn);
            this.gpbConexionInfo.Controls.Add(this.panelEstadoConn);
            this.gpbConexionInfo.Controls.Add(this.lblArchivoTitulo);
            this.gpbConexionInfo.Controls.Add(this.lblArchivoConn);
            this.gpbConexionInfo.Controls.Add(this.lblProveedorTitulo);
            this.gpbConexionInfo.Controls.Add(this.lblProveedorConn);
            this.gpbConexionInfo.Controls.Add(this.lblFechaConexionTitulo);
            this.gpbConexionInfo.Controls.Add(this.lblFechaConexionConn);
            this.gpbConexionInfo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gpbConexionInfo.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.gpbConexionInfo.Location = new System.Drawing.Point(10, 50);
            this.gpbConexionInfo.Name = "gpbConexionInfo";
            this.gpbConexionInfo.Size = new System.Drawing.Size(930, 350);
            this.gpbConexionInfo.TabIndex = 1;
            this.gpbConexionInfo.TabStop = false;
            this.gpbConexionInfo.Text = " Información de la Conexión ";

            this.lblIconoEstadoConn.AutoSize = true;
            this.lblIconoEstadoConn.Font = new System.Drawing.Font("Segoe UI", 48F);
            this.lblIconoEstadoConn.Location = new System.Drawing.Point(30, 35);
            this.lblIconoEstadoConn.Name = "lblIconoEstadoConn";
            this.lblIconoEstadoConn.TabIndex = 0;
            this.lblIconoEstadoConn.Text = "🔌";

            this.panelEstadoConn.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.panelEstadoConn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelEstadoConn.Location = new System.Drawing.Point(140, 35);
            this.panelEstadoConn.Name = "panelEstadoConn";
            this.panelEstadoConn.Size = new System.Drawing.Size(320, 70);
            this.panelEstadoConn.TabIndex = 8;

            this.lblEstadoConnInfo.AutoSize = true;
            this.lblEstadoConnInfo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEstadoConnInfo.ForeColor = System.Drawing.Color.FromArgb(51, 65, 85);
            this.lblEstadoConnInfo.Location = new System.Drawing.Point(150, 55);
            this.lblEstadoConnInfo.Name = "lblEstadoConnInfo";
            this.lblEstadoConnInfo.TabIndex = 1;
            this.lblEstadoConnInfo.Text = "Verificando...";

            this.pbConexionConn.Location = new System.Drawing.Point(30, 125);
            this.pbConexionConn.Name = "pbConexionConn";
            this.pbConexionConn.Size = new System.Drawing.Size(870, 18);
            this.pbConexionConn.TabIndex = 2;

            this.lblArchivoTitulo.AutoSize = true;
            this.lblArchivoTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblArchivoTitulo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblArchivoTitulo.Location = new System.Drawing.Point(30, 160);
            this.lblArchivoTitulo.Name = "lblArchivoTitulo";
            this.lblArchivoTitulo.TabIndex = 3;
            this.lblArchivoTitulo.Text = "📁  Archivo de Base de Datos:";

            this.lblArchivoConn.AutoSize = true;
            this.lblArchivoConn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblArchivoConn.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblArchivoConn.Location = new System.Drawing.Point(45, 180);
            this.lblArchivoConn.Name = "lblArchivoConn";
            this.lblArchivoConn.Size = new System.Drawing.Size(200, 17);
            this.lblArchivoConn.TabIndex = 4;
            this.lblArchivoConn.Text = "—";

            this.lblProveedorTitulo.AutoSize = true;
            this.lblProveedorTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProveedorTitulo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblProveedorTitulo.Location = new System.Drawing.Point(30, 215);
            this.lblProveedorTitulo.Name = "lblProveedorTitulo";
            this.lblProveedorTitulo.TabIndex = 5;
            this.lblProveedorTitulo.Text = "🔧  Proveedor OLE DB:";

            this.lblProveedorConn.AutoSize = true;
            this.lblProveedorConn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblProveedorConn.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblProveedorConn.Location = new System.Drawing.Point(45, 235);
            this.lblProveedorConn.Name = "lblProveedorConn";
            this.lblProveedorConn.Size = new System.Drawing.Size(200, 17);
            this.lblProveedorConn.TabIndex = 6;
            this.lblProveedorConn.Text = "—";

            this.lblFechaConexionTitulo.AutoSize = true;
            this.lblFechaConexionTitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFechaConexionTitulo.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.lblFechaConexionTitulo.Location = new System.Drawing.Point(30, 270);
            this.lblFechaConexionTitulo.Name = "lblFechaConexionTitulo";
            this.lblFechaConexionTitulo.TabIndex = 7;
            this.lblFechaConexionTitulo.Text = "🕐  Última verificación:";

            this.lblFechaConexionConn.AutoSize = true;
            this.lblFechaConexionConn.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblFechaConexionConn.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblFechaConexionConn.Location = new System.Drawing.Point(45, 290);
            this.lblFechaConexionConn.Name = "lblFechaConexionConn";
            this.lblFechaConexionConn.Size = new System.Drawing.Size(200, 17);
            this.lblFechaConexionConn.TabIndex = 9;
            this.lblFechaConexionConn.Text = "—";

            this.btnReconectar.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.btnReconectar.FlatAppearance.BorderSize = 0;
            this.btnReconectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReconectar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReconectar.ForeColor = System.Drawing.Color.White;
            this.btnReconectar.Location = new System.Drawing.Point(10, 420);
            this.btnReconectar.Name = "btnReconectar";
            this.btnReconectar.Size = new System.Drawing.Size(190, 42);
            this.btnReconectar.TabIndex = 2;
            this.btnReconectar.Text = "🔄 RECONECTAR";
            this.btnReconectar.UseVisualStyleBackColor = false;
            this.btnReconectar.Click += new System.EventHandler(this.btnReconectar_Click);

            // ================================================================
            //  FORM PRINCIPAL
            // ================================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            this.ClientSize = new System.Drawing.Size(980, 712);
            this.Controls.Add(this.tcMenu);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.stEstadoConexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "🏢 Sistema ERP – Gestión de Usuarios";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);

            this.stEstadoConexion.ResumeLayout(false);
            this.stEstadoConexion.PerformLayout();
            this.tcMenu.ResumeLayout(false);
            this.tpRegistrar.ResumeLayout(false);
            this.tpRegistrar.PerformLayout();
            this.gpbDatosReg.ResumeLayout(false);
            this.gpbDatosReg.PerformLayout();
            this.gpbDomiciliosReg.ResumeLayout(false);
            this.gpbDomiciliosReg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomiciliosReg)).EndInit();
            this.tpEditar.ResumeLayout(false);
            this.tpEditar.PerformLayout();
            this.gpbDatosEdit.ResumeLayout(false);
            this.gpbDatosEdit.PerformLayout();
            this.tpEstado.ResumeLayout(false);
            this.tpEstado.PerformLayout();
            this.gpbEstadoBaja.ResumeLayout(false);
            this.gpbEstadoBaja.PerformLayout();
            this.panelEstadoBaja.ResumeLayout(false);
            this.panelEstadoBaja.PerformLayout();
            this.tpConexion.ResumeLayout(false);
            this.tpConexion.PerformLayout();
            this.gpbConexionInfo.ResumeLayout(false);
            this.gpbConexionInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        // Status Strip
        private System.Windows.Forms.StatusStrip stEstadoConexion;
        private System.Windows.Forms.ToolStripStatusLabel tsslEstado;
        private System.Windows.Forms.ToolStripProgressBar BarraDeEstado;
        private System.Windows.Forms.Label lblConexion;
        // TabControl
        private System.Windows.Forms.TabControl tcMenu;
        // Tab 1 – Registrar
        private System.Windows.Forms.TabPage tpRegistrar;
        private System.Windows.Forms.Label lblTitleReg;
        private System.Windows.Forms.GroupBox gpbDatosReg;
        private System.Windows.Forms.Label lblDniReg;
        private System.Windows.Forms.TextBox txtDniReg;
        private System.Windows.Forms.Label lblNombreReg;
        private System.Windows.Forms.TextBox txtNombreReg;
        private System.Windows.Forms.Label lblApellidoReg;
        private System.Windows.Forms.TextBox txtApellidoReg;
        private System.Windows.Forms.Label lblMailReg;
        private System.Windows.Forms.TextBox txtMailReg;
        private System.Windows.Forms.Label lblContrasenaReg;
        private System.Windows.Forms.TextBox txtContrasenaReg;
        private System.Windows.Forms.CheckBox chkMostrarReg;
        private System.Windows.Forms.Label lblTelefonoReg;
        private System.Windows.Forms.TextBox txtTelefonoReg;
        private System.Windows.Forms.Label lblPerfilReg;
        private System.Windows.Forms.ComboBox cmbPerfilReg;
        private System.Windows.Forms.Label lblRedSocialReg;
        private System.Windows.Forms.ComboBox cmbRedSocialReg;
        private System.Windows.Forms.Label lblHandleReg;
        private System.Windows.Forms.TextBox txtHandleReg;
        private System.Windows.Forms.GroupBox gpbDomiciliosReg;
        private System.Windows.Forms.Label lblDireccionReg;
        private System.Windows.Forms.TextBox txtDireccionReg;
        private System.Windows.Forms.Button btnGoogleMapsReg;
        private System.Windows.Forms.Label lblProvinciaReg;
        private System.Windows.Forms.ComboBox cmbProvinciaReg;
        private System.Windows.Forms.Label lblLocalidadReg;
        private System.Windows.Forms.ComboBox cmbLocalidadReg;
        private System.Windows.Forms.Button btnAgregarDomReg;
        private System.Windows.Forms.DataGridView dgvDomiciliosReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProvReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProvReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLocReg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocReg;
        private System.Windows.Forms.Button btnEliminarDomReg;
        private System.Windows.Forms.Button btnLimpiarReg;
        private System.Windows.Forms.Button btnRegistrarUsuario;
        // Tab 2 – Editar
        private System.Windows.Forms.TabPage tpEditar;
        private System.Windows.Forms.Label lblTitleEdit;
        private System.Windows.Forms.Label lblSelUsrEdit;
        private System.Windows.Forms.ComboBox cmbSelUsrEdit;
        private System.Windows.Forms.GroupBox gpbDatosEdit;
        private System.Windows.Forms.Label lblNombreEdit;
        private System.Windows.Forms.TextBox txtNombreEdit;
        private System.Windows.Forms.Label lblApellidoEdit;
        private System.Windows.Forms.TextBox txtApellidoEdit;
        private System.Windows.Forms.Label lblMailEdit;
        private System.Windows.Forms.TextBox txtMailEdit;
        private System.Windows.Forms.Label lblContrasenaEdit;
        private System.Windows.Forms.TextBox txtContrasenaEdit;
        private System.Windows.Forms.CheckBox chkMostrarEdit;
        private System.Windows.Forms.Label lblTelefonoEdit;
        private System.Windows.Forms.TextBox txtTelefonoEdit;
        private System.Windows.Forms.Label lblRedSocialEdit;
        private System.Windows.Forms.ComboBox cmbRedSocialEdit;
        private System.Windows.Forms.Label lblHandleEdit;
        private System.Windows.Forms.TextBox txtHandleEdit;
        private System.Windows.Forms.CheckBox chkActivoEdit;
        private System.Windows.Forms.Label lblNotaEdit;
        private System.Windows.Forms.Button btnGuardarEdit;
        // Tab 3 – Estado
        private System.Windows.Forms.TabPage tpEstado;
        private System.Windows.Forms.Label lblTitleBaja;
        private System.Windows.Forms.Label lblSelUsrBaja;
        private System.Windows.Forms.ComboBox cmbSelUsrBaja;
        private System.Windows.Forms.GroupBox gpbEstadoBaja;
        private System.Windows.Forms.Label lblNombreCompletoBaja;
        private System.Windows.Forms.Label lblMailMostrarBaja;
        private System.Windows.Forms.Panel panelEstadoBaja;
        private System.Windows.Forms.Label lblIconoEstado;
        private System.Windows.Forms.Label lblEstadoBaja;
        private System.Windows.Forms.Button btnActivarBaja;
        private System.Windows.Forms.Button btnDarDeBaja;
        // Tab 4 – Conexión
        private System.Windows.Forms.TabPage tpConexion;
        private System.Windows.Forms.Label lblTitleConn;
        private System.Windows.Forms.GroupBox gpbConexionInfo;
        private System.Windows.Forms.Label lblIconoEstadoConn;
        private System.Windows.Forms.Panel panelEstadoConn;
        private System.Windows.Forms.Label lblEstadoConnInfo;
        private System.Windows.Forms.ProgressBar pbConexionConn;
        private System.Windows.Forms.Label lblArchivoTitulo;
        private System.Windows.Forms.Label lblArchivoConn;
        private System.Windows.Forms.Label lblProveedorTitulo;
        private System.Windows.Forms.Label lblProveedorConn;
        private System.Windows.Forms.Label lblFechaConexionTitulo;
        private System.Windows.Forms.Label lblFechaConexionConn;
        private System.Windows.Forms.Button btnReconectar;
    }
}
