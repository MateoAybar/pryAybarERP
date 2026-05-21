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
            this.stEstadoConexion.SuspendLayout();
            this.SuspendLayout();
            // 
            // stEstadoConexion
            // 
            this.stEstadoConexion.AutoSize = false;
            this.stEstadoConexion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarraDeEstado});
            this.stEstadoConexion.Location = new System.Drawing.Point(0, 509);
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
            this.lblConexion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexion.ForeColor = System.Drawing.Color.Green;
            this.lblConexion.Location = new System.Drawing.Point(12, 485);
            this.lblConexion.Name = "lblConexion";
            this.lblConexion.Size = new System.Drawing.Size(0, 13);
            this.lblConexion.TabIndex = 1;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 531);
            this.Controls.Add(this.lblConexion);
            this.Controls.Add(this.stEstadoConexion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ERP - Sistema de Gestión";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.stEstadoConexion.ResumeLayout(false);
            this.stEstadoConexion.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip stEstadoConexion;
        private System.Windows.Forms.ToolStripProgressBar BarraDeEstado;
        private System.Windows.Forms.Label lblConexion;
    }
}

