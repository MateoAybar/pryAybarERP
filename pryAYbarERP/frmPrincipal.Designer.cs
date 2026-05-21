namespace pryAYbarERP
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.stEstadoConexion = new System.Windows.Forms.StatusStrip();
            this.BarraDeEstado = new System.Windows.Forms.ToolStripProgressBar();
            this.lblConexion = new System.Windows.Forms.Label();
            this.tcMenu = new System.Windows.Forms.TabControl();
            this.tpPersonal = new System.Windows.Forms.TabPage();
            this.gpbDomicilios = new System.Windows.Forms.GroupBox();
            this.lnkMaps = new System.Windows.Forms.LinkLabel();
            this.dgvDomicilios = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDireccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdProv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProvincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIdLoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLocalidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarDom = new System.Windows.Forms.Button();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.btnGuardarPersonal = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.lblDni = new System.Windows.Forms.Label();
            this.tpContacto = new System.Windows.Forms.TabPage();
            this.btnGuardarContacto = new System.Windows.Forms.Button();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.txtRedes = new System.Windows.Forms.TextBox();
            this.lblRedes = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.cmbUsuarios = new System.Windows.Forms.ComboBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblTitleContacto = new System.Windows.Forms.Label();
            this.stEstadoConexion.SuspendLayout();
            this.tcMenu.SuspendLayout();
            this.tpPersonal.SuspendLayout();
            this.gpbDomicilios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).BeginInit();
            this.tpContacto.SuspendLayout();
            this.SuspendLayout();
            // 
            // stEstadoConexion
            // 
            this.stEstadoConexion.AutoSize = false;
            this.stEstadoConexion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarraDeEstado});
            this.stEstadoConexion.Location = new System.Drawing.Point(0, 538);
            this.stEstadoConexion.Name = "stEstadoConexion";
            this.stEstadoConexion.Size = new System.Drawing.Size(800, 22);
            this.stEstadoConexion.TabIndex = 0;
            this.stEstadoConexion.Text = "statusStrip1";
            this.stEstadoConexion.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.stEstadoConexion_ItemClicked);
            // 
            // BarraDeEstado
            // 
            this.BarraDeEstado.Name = "BarraDeEstado";
            this.BarraDeEstado.Size = new System.Drawing.Size(100, 16);
            // 
            // lblConexion
            // 
            this.lblConexion.AutoSize = true;
            this.lblConexion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexion.ForeColor = System.Drawing.Color.Green;
            this.lblConexion.Location = new System.Drawing.Point(120, 542);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(0, 13);
            this.lblConexion.TabIndex = 1;
            // 
            // tcMenu
            // 
            this.tcMenu.Controls.Add(this.tpPersonal);
            this.tcMenu.Controls.Add(this.tpContacto);
            this.tcMenu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMenu.Location = new System.Drawing.Point(12, 12);
            this.tcMenu.Name = "tcMenu";
            this.tcMenu.SelectedIndex = 0;
            this.tcMenu.Size = new System.Drawing.Size(776, 510);
            this.tcMenu.TabIndex = 2;
            // 
            // tpPersonal
            // 
            this.tpPersonal.BackColor = System.Drawing.Color.White;
            this.tpPersonal.Controls.Add(this.gpbDomicilios);
            this.tpPersonal.Controls.Add(this.btnGuardarPersonal);
            this.tpPersonal.Controls.Add(this.txtNombre);
            this.tpPersonal.Controls.Add(this.lblNombre);
            this.tpPersonal.Controls.Add(this.txtApellido);
            this.tpPersonal.Controls.Add(this.lblApellido);
            this.tpPersonal.Controls.Add(this.btnBuscar);
            this.tpPersonal.Controls.Add(this.txtDni);
            this.tpPersonal.Controls.Add(this.lblDni);
            this.tpPersonal.Location = new System.Drawing.Point(4, 26);
            this.tpPersonal.Name = "tpPersonal";
            this.tpPersonal.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonal.Size = new System.Drawing.Size(768, 480);
            this.tpPersonal.TabIndex = 0;
            this.tpPersonal.Text = "Gestión de Personal";
            // 
            // gpbDomicilios
            // 
            this.gpbDomicilios.Controls.Add(this.lnkMaps);
            this.gpbDomicilios.Controls.Add(this.dgvDomicilios);
            this.gpbDomicilios.Controls.Add(this.btnAgregarDom);
            this.gpbDomicilios.Controls.Add(this.cmbLocalidad);
            this.gpbDomicilios.Controls.Add(this.lblLocalidad);
            this.gpbDomicilios.Controls.Add(this.cmbProvincia);
            this.gpbDomicilios.Controls.Add(this.lblProvincia);
            this.gpbDomicilios.Controls.Add(this.txtDireccion);
            this.gpbDomicilios.Controls.Add(this.lblDireccion);
            this.gpbDomicilios.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.gpbDomicilios.ForeColor = System.Drawing.Color.DarkGreen;
            this.gpbDomicilios.Location = new System.Drawing.Point(20, 115);
            this.gpbDomicilios.Name = "gpbDomicilios";
            this.gpbDomicilios.Size = new System.Drawing.Size(728, 305);
            this.gpbDomicilios.TabIndex = 8;
            this.gpbDomicilios.TabStop = false;
            this.gpbDomicilios.Text = "Domicilios Asociados";
            // 
            // lnkMaps
            // 
            this.lnkMaps.AutoSize = true;
            this.lnkMaps.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lnkMaps.LinkColor = System.Drawing.Color.DodgerBlue;
            this.lnkMaps.Location = new System.Drawing.Point(490, 80);
            this.lnkMaps.Name = "lnkMaps";
            this.lnkMaps.Size = new System.Drawing.Size(223, 17);
            this.lnkMaps.TabIndex = 8;
            this.lnkMaps.TabStop = true;
            this.lnkMaps.Text = "🗺️ Ver seleccionado en Google Maps";
            this.lnkMaps.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkMaps_LinkClicked);
            // 
            // dgvDomicilios
            // 
            this.dgvDomicilios.AllowUserToAddRows = false;
            this.dgvDomicilios.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDomicilios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDomicilios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDireccion,
            this.colIdProv,
            this.colProvincia,
            this.colIdLoc,
            this.colLocalidad});
            this.dgvDomicilios.GridColor = System.Drawing.Color.Silver;
            this.dgvDomicilios.Location = new System.Drawing.Point(15, 110);
            this.dgvDomicilios.Name = "dgvDomicilios";
            this.dgvDomicilios.ReadOnly = true;
            this.dgvDomicilios.RowHeadersVisible = false;
            this.dgvDomicilios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDomicilios.Size = new System.Drawing.Size(698, 180);
            this.dgvDomicilios.TabIndex = 7;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "Id_Domicilio";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Visible = false;
            // 
            // colDireccion
            // 
            this.colDireccion.DataPropertyName = "Direccion";
            this.colDireccion.HeaderText = "Dirección";
            this.colDireccion.Name = "colDireccion";
            this.colDireccion.ReadOnly = true;
            this.colDireccion.Width = 320;
            // 
            // colIdProv
            // 
            this.colIdProv.DataPropertyName = "Id_Provincia";
            this.colIdProv.HeaderText = "IdProvincia";
            this.colIdProv.Name = "colIdProv";
            this.colIdProv.ReadOnly = true;
            this.colIdProv.Visible = false;
            // 
            // colProvincia
            // 
            this.colProvincia.DataPropertyName = "Provincia";
            this.colProvincia.HeaderText = "Provincia";
            this.colProvincia.Name = "colProvincia";
            this.colProvincia.ReadOnly = true;
            this.colProvincia.Width = 170;
            // 
            // colIdLoc
            // 
            this.colIdLoc.DataPropertyName = "Id_Localidad";
            this.colIdLoc.HeaderText = "IdLocalidad";
            this.colIdLoc.Name = "colIdLoc";
            this.colIdLoc.ReadOnly = true;
            this.colIdLoc.Visible = false;
            // 
            // colLocalidad
            // 
            this.colLocalidad.DataPropertyName = "Localidad";
            this.colLocalidad.HeaderText = "Localidad";
            this.colLocalidad.Name = "colLocalidad";
            this.colLocalidad.ReadOnly = true;
            this.colLocalidad.Width = 175;
            // 
            // btnAgregarDom
            // 
            this.btnAgregarDom.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnAgregarDom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDom.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDom.Location = new System.Drawing.Point(340, 75);
            this.btnAgregarDom.Name = "btnAgregarDom";
            this.btnAgregarDom.Size = new System.Drawing.Size(140, 26);
            this.btnAgregarDom.TabIndex = 6;
            this.btnAgregarDom.Text = "➕ Agregar";
            this.btnAgregarDom.UseVisualStyleBackColor = false;
            this.btnAgregarDom.Click += new System.EventHandler(this.btnAgregarDom_Click);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(180, 76);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(150, 25);
            this.cmbLocalidad.TabIndex = 5;
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblLocalidad.ForeColor = System.Drawing.Color.Black;
            this.lblLocalidad.Location = new System.Drawing.Point(180, 58);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(61, 15);
            this.lblLocalidad.TabIndex = 4;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvincia.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(15, 76);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(150, 25);
            this.cmbProvincia.TabIndex = 3;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProvincia.ForeColor = System.Drawing.Color.Black;
            this.lblProvincia.Location = new System.Drawing.Point(15, 58);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(59, 15);
            this.lblProvincia.TabIndex = 2;
            this.lblProvincia.Text = "Provincia:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDireccion.Location = new System.Drawing.Point(15, 30);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(698, 24);
            this.txtDireccion.TabIndex = 1;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDireccion.ForeColor = System.Drawing.Color.Black;
            this.lblDireccion.Location = new System.Drawing.Point(15, 13);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(147, 15);
            this.lblDireccion.TabIndex = 0;
            this.lblDireccion.Text = "Dirección (Calle, Nro, Piso):";
            // 
            // btnGuardarPersonal
            // 
            this.btnGuardarPersonal.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardarPersonal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPersonal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPersonal.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPersonal.Location = new System.Drawing.Point(530, 430);
            this.btnGuardarPersonal.Name = "btnGuardarPersonal";
            this.btnGuardarPersonal.Size = new System.Drawing.Size(218, 38);
            this.btnGuardarPersonal.TabIndex = 7;
            this.btnGuardarPersonal.Text = "💾 GUARDAR PERSONAL";
            this.btnGuardarPersonal.UseVisualStyleBackColor = false;
            this.btnGuardarPersonal.Click += new System.EventHandler(this.btnGuardarPersonal_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(510, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(238, 25);
            this.txtNombre.TabIndex = 6;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(510, 10);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 17);
            this.lblNombre.TabIndex = 5;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(260, 30);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(230, 25);
            this.txtApellido.TabIndex = 4;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(260, 10);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(59, 17);
            this.lblApellido.TabIndex = 3;
            this.lblApellido.Text = "Apellido:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DarkSlateGray;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(165, 29);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(80, 26);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.Text = "🔍 Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(20, 30);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(140, 25);
            this.txtDni.TabIndex = 1;
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(20, 10);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(33, 17);
            this.lblDni.TabIndex = 0;
            this.lblDni.Text = "DNI:";
            // 
            // tpContacto
            // 
            this.tpContacto.BackColor = System.Drawing.Color.White;
            this.tpContacto.Controls.Add(this.btnGuardarContacto);
            this.tpContacto.Controls.Add(this.chkActivo);
            this.tpContacto.Controls.Add(this.txtRedes);
            this.tpContacto.Controls.Add(this.lblRedes);
            this.tpContacto.Controls.Add(this.txtTelefono);
            this.tpContacto.Controls.Add(this.lblTelefono);
            this.tpContacto.Controls.Add(this.txtMail);
            this.tpContacto.Controls.Add(this.lblMail);
            this.tpContacto.Controls.Add(this.cmbUsuarios);
            this.tpContacto.Controls.Add(this.lblUsuario);
            this.tpContacto.Controls.Add(this.lblTitleContacto);
            this.tpContacto.Location = new System.Drawing.Point(4, 26);
            this.tpContacto.Name = "tpContacto";
            this.tpContacto.Padding = new System.Windows.Forms.Padding(3);
            this.tpContacto.Size = new System.Drawing.Size(768, 480);
            this.tpContacto.TabIndex = 1;
            this.tpContacto.Text = "Contacto de Usuarios";
            // 
            // btnGuardarContacto
            // 
            this.btnGuardarContacto.BackColor = System.Drawing.Color.ForestGreen;
            this.btnGuardarContacto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarContacto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarContacto.ForeColor = System.Drawing.Color.White;
            this.btnGuardarContacto.Location = new System.Drawing.Point(40, 360);
            this.btnGuardarContacto.Name = "btnGuardarContacto";
            this.btnGuardarContacto.Size = new System.Drawing.Size(260, 38);
            this.btnGuardarContacto.TabIndex = 10;
            this.btnGuardarContacto.Text = "💾 GUARDAR CONTACTO";
            this.btnGuardarContacto.UseVisualStyleBackColor = false;
            this.btnGuardarContacto.Click += new System.EventHandler(this.btnGuardarContacto_Click);
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.chkActivo.ForeColor = System.Drawing.Color.DarkGreen;
            this.chkActivo.Location = new System.Drawing.Point(40, 200);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(127, 23);
            this.chkActivo.TabIndex = 9;
            this.chkActivo.Text = "Usuario Activo";
            this.chkActivo.UseVisualStyleBackColor = true;
            this.chkActivo.CheckedChanged += new System.EventHandler(this.chkActivo_CheckedChanged);
            // 
            // txtRedes
            // 
            this.txtRedes.Location = new System.Drawing.Point(40, 305);
            this.txtRedes.Name = "txtRedes";
            this.txtRedes.Size = new System.Drawing.Size(690, 25);
            this.txtRedes.TabIndex = 8;
            // 
            // lblRedes
            // 
            this.lblRedes.AutoSize = true;
            this.lblRedes.Location = new System.Drawing.Point(40, 285);
            this.lblRedes.Name = "lblRedes";
            this.lblRedes.Size = new System.Drawing.Size(201, 17);
            this.lblRedes.TabIndex = 7;
            this.lblRedes.Text = "Redes Sociales (ej. Facebook/Ig):";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(40, 245);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(690, 25);
            this.txtTelefono.TabIndex = 6;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(40, 225);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(61, 17);
            this.lblTelefono.TabIndex = 5;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtMail.Location = new System.Drawing.Point(40, 155);
            this.txtMail.Name = "txtMail";
            this.txtMail.ReadOnly = true;
            this.txtMail.Size = new System.Drawing.Size(690, 25);
            this.txtMail.TabIndex = 4;
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Location = new System.Drawing.Point(40, 135);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(120, 17);
            this.lblMail.TabIndex = 3;
            this.lblMail.Text = "Correo Electrónico:";
            // 
            // cmbUsuarios
            // 
            this.cmbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUsuarios.FormattingEnabled = true;
            this.cmbUsuarios.Location = new System.Drawing.Point(40, 95);
            this.cmbUsuarios.Name = "cmbUsuarios";
            this.cmbUsuarios.Size = new System.Drawing.Size(690, 25);
            this.cmbUsuarios.TabIndex = 2;
            this.cmbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cmbUsuarios_SelectedIndexChanged);
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(40, 75);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(127, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Seleccionar Usuario:";
            // 
            // lblTitleContacto
            // 
            this.lblTitleContacto.AutoSize = true;
            this.lblTitleContacto.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitleContacto.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTitleContacto.Location = new System.Drawing.Point(35, 20);
            this.lblTitleContacto.Name = "lblTitleContacto";
            this.lblTitleContacto.Size = new System.Drawing.Size(359, 30);
            this.lblTitleContacto.TabIndex = 0;
            this.lblTitleContacto.Text = "Información de Contacto y Estado";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 560);
            this.Controls.Add(this.tcMenu);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.stEstadoConexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP - Menú Integral de Gestión";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.stEstadoConexion.ResumeLayout(false);
            this.stEstadoConexion.PerformLayout();
            this.tcMenu.ResumeLayout(false);
            this.tpPersonal.ResumeLayout(false);
            this.tpPersonal.PerformLayout();
            this.gpbDomicilios.ResumeLayout(false);
            this.gpbDomicilios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDomicilios)).EndInit();
            this.tpContacto.ResumeLayout(false);
            this.tpContacto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stEstadoConexion;
        private System.Windows.Forms.ToolStripProgressBar BarraDeEstado;
        private System.Windows.Forms.Label lblConexion;
        private System.Windows.Forms.TabControl tcMenu;
        private System.Windows.Forms.TabPage tpPersonal;
        private System.Windows.Forms.TabPage tpContacto;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.GroupBox gpbDomicilios;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Button btnAgregarDom;
        private System.Windows.Forms.DataGridView dgvDomicilios;
        private System.Windows.Forms.LinkLabel lnkMaps;
        private System.Windows.Forms.Button btnGuardarPersonal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDireccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdProv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProvincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdLoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLocalidad;
        private System.Windows.Forms.Label lblTitleContacto;
        private System.Windows.Forms.ComboBox cmbUsuarios;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtRedes;
        private System.Windows.Forms.Label lblRedes;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardarContacto;
    }
}
