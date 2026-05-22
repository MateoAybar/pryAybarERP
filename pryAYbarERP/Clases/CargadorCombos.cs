using System;
using System.Data;
using System.Windows.Forms;
using pryAYbarERP.BaseDatos;

namespace pryAYbarERP.Clases
{
    internal class CargadorCombos
    {
        public static void CargarProvincias(ComboBox combo)
        {
            string mensaje;
            DataTable tabla = Conexionbd.ObtenerProvincias(out mensaje);
            PrepararTablaCombo(tabla, "Id_Provincias", "Provincias");

            combo.DataSource = null;
            combo.DataSource = tabla;
            combo.ValueMember = "Id_Provincias";
            combo.DisplayMember = "Provincias";
            combo.SelectedIndex = -1;
        }

        public static void CargarLocalidades(ComboBox combo, int idProvincia)
        {
            string mensaje;
            DataTable tabla = Conexionbd.ObtenerLocalidades(idProvincia, out mensaje);
            PrepararTablaCombo(tabla, "Id_Localidades", "Localidades");

            combo.DataSource = null;
            combo.DataSource = tabla;
            combo.ValueMember = "Id_Localidades";
            combo.DisplayMember = "Localidades";
            combo.SelectedIndex = -1;
        }

        public static void LimpiarLocalidades(ComboBox combo)
        {
            combo.DataSource = null;
            combo.DisplayMember = "";
            combo.ValueMember = "";
            combo.Enabled = false;
        }

        public static bool EsCordoba(ComboBox combo)
        {
            return combo.Text.ToLower().Contains("rdoba");
        }

        private static void PrepararTablaCombo(DataTable tabla, string columnaId, string columnaTexto)
        {
            if (tabla == null || tabla.Columns.Count < 2)
            {
                return;
            }

            if (!tabla.Columns.Contains(columnaId))
            {
                tabla.Columns[0].ColumnName = columnaId;
            }

            if (!tabla.Columns.Contains(columnaTexto))
            {
                tabla.Columns[1].ColumnName = columnaTexto;
            }
        }

        public static int ObtenerIdSeleccionado(ComboBox combo)
        {
            if (combo.SelectedValue == null)
            {
                return 0;
            }

            int id;
            if (int.TryParse(combo.SelectedValue.ToString(), out id))
            {
                return id;
            }

            return 0;
        }
    }
}
