using System;
using System.Data.SqlClient;

namespace pryAYbarERP.BaseDatos
{
    internal class Conexionbd
    {
        // Cadena de conexión por defecto. Modifícala según tu servidor/base de datos.
        public static string ConnectionString { get; set; } = "Data Source=.;Initial Catalog=master;Integrated Security=True";

        // Prueba la conexión y devuelve true si se conectó. En out mensaje viene información adicional o el error.
        public static bool ProbarConexion(out string mensaje)
        {
            try
            {
                using (var cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    mensaje = "Conexión exitosa.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
    }
}
