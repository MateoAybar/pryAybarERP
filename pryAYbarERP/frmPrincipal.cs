using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryAYbarERP
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
           
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            string mensaje;
            bool conectado = BaseDatos.Conexionbd.ProbarConexion(out mensaje);

            if (conectado)
            {
                BarraDeEstado.Value = 100;
                lblConexion.Text = "✓ Conectado";
                lblConexion.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                BarraDeEstado.Value = 0;
                lblConexion.Text = "✗ Sin conexión";
                lblConexion.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void stEstadoConexion_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
