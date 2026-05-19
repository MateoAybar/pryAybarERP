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
                toolStripProgressBar1.Value = 100;
                MessageBox.Show("Se conectó correctamente a la base de datos.", "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                toolStripProgressBar1.Value = 0;
                MessageBox.Show("No se pudo conectar a la base de datos:\n" + mensaje, "Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
