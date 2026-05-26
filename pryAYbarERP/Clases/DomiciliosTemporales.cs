using System.Data;
using System.Windows.Forms;

namespace pryAYbarERP.Clases
{
    internal static class DomiciliosTemporales
    {
        public static DataTable CrearTabla()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Direccion", typeof(string));
            tabla.Columns.Add("Id_Provincias", typeof(int));
            tabla.Columns.Add("Provincias", typeof(string));
            tabla.Columns.Add("Id_Localidades", typeof(int));
            tabla.Columns.Add("Localidad", typeof(string));
            return tabla;
        }

        public static void Agregar(DataTable tabla, string direccion, int idProvincia,
            string provincia, int idLocalidad, string localidad)
        {
            DataRow fila = tabla.NewRow();
            fila["Direccion"] = direccion;
            fila["Id_Provincias"] = idProvincia;
            fila["Provincias"] = provincia;
            fila["Id_Localidades"] = idLocalidad;
            fila["Localidad"] = localidad;
            tabla.Rows.Add(fila);
        }

        public static void MostrarEnGrilla(DataTable tabla, DataGridView grilla)
        {
            grilla.Rows.Clear();

            foreach (DataRow fila in tabla.Rows)
            {
                grilla.Rows.Add(
                    fila["Direccion"],
                    fila["Id_Provincias"],
                    fila["Provincias"],
                    fila["Id_Localidades"],
                    fila["Localidad"]);
            }
        }

        public static void EliminarSeleccionado(DataTable tabla, DataGridView grilla)
        {
            if (grilla.SelectedRows.Count == 0)
                return;

            int indice = grilla.SelectedRows[0].Index;
            if (indice < 0 || indice >= tabla.Rows.Count)
                return;

            tabla.Rows.RemoveAt(indice);
            MostrarEnGrilla(tabla, grilla);
        }
    }
}
