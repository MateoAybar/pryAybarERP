using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pryAYbarERP.Clases;

namespace pryAYbarERP
{
    public partial class frmPersonal : Form
    {
        public frmPersonal()
        {
            InitializeComponent();
            CargadorCombos.CargarProvincias(cmbProvincia);
            CargadorCombos.LimpiarLocalidades(cmbLocalidad);
            cmbProvincia.SelectedIndexChanged += cmbProvincia_SelectedIndexChanged;
        }

        private void cmbProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargadorCombos.LimpiarLocalidades(cmbLocalidad);

            if (!CargadorCombos.EsCordoba(cmbProvincia))
            {
                return;
            }

            int idProvincia = CargadorCombos.ObtenerIdSeleccionado(cmbProvincia);
            if (idProvincia == 0) return;

            cmbLocalidad.Enabled = true;
            CargadorCombos.CargarLocalidades(cmbLocalidad, idProvincia);
        }
    }
}
