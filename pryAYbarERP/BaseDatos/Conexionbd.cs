using System;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace pryAYbarERP.BaseDatos
{
    internal class Conexionbd
    {
        public static string ConnectionString { get; private set; }

        private static bool Conexion(out string mensaje)
        {
            try
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                string carpeta = Path.Combine(baseDir, "BaseDatos");

                if (!Directory.Exists(carpeta))
                {
                    mensaje = $"No se encontró la carpeta de BaseDatos en: {carpeta}";
                    return false;
                }

                string[] accdbFiles = Directory.GetFiles(carpeta, "*.accdb", SearchOption.TopDirectoryOnly);
                string[] mdbFiles = Directory.GetFiles(carpeta, "*.mdb", SearchOption.TopDirectoryOnly);

                string archivo = null;
                string provider = null;

                if (accdbFiles.Length > 0)
                {
                    archivo = accdbFiles[0];
                    provider = "Microsoft.ACE.OLEDB.12.0";
                }
                else if (mdbFiles.Length > 0)
                {
                    archivo = mdbFiles[0];
                    provider = "Microsoft.Jet.OLEDB.4.0";
                }

                if (archivo == null)
                {
                    mensaje = "No se encontró ningún archivo .accdb o .mdb en la carpeta BaseDatos.";
                    return false;
                }

                ConnectionString = $"Provider={provider};Data Source={archivo};Persist Security Info=False;";

                mensaje = $"Usando archivo de BD: {Path.GetFileName(archivo)}";
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        public static bool ProbarConexion(out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                if (!Conexion(out mensaje))
                {
                    return false;
                }
            }

            try
            {
                using (var cn = new OleDbConnection(ConnectionString))
                {
                    cn.Open();
                    mensaje = "Conexión exitosa a la base de datos Access.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        public static OleDbConnection GetConnection()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
            {
                string dummy;
                Conexion(out dummy);
            }

            return new OleDbConnection(ConnectionString);
        }

        // Valida usuario o email y contraseña contra la tabla 'usuarios' de la BD Access.
        public static bool ValidarUsuario(string usuarioOEmail, string contraseña, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    // Buscar por posibles nombres de campo de usuario/email
                    string sql = "SELECT * FROM usuario WHERE Usuario = ? OR Mail  = ?";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        // Agregar el mismo parámetro repetido (OleDb usa posición)
                        cmd.Parameters.AddWithValue("@p1", usuarioOEmail);
                        cmd.Parameters.AddWithValue("@p2", usuarioOEmail);
                        cmd.Parameters.AddWithValue("@p3", usuarioOEmail);
                        cmd.Parameters.AddWithValue("@p4", usuarioOEmail);

                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count == 0)
                            {
                                mensaje = "Usuario o correo no encontrado.";
                                return false;
                            }

                            // Posibles nombres de columna para la contraseña
                            string[] passCols = new[] { "Contraseña"};

                            foreach (DataRow row in dt.Rows)
                            {
                                foreach (var col in passCols)
                                {
                                    if (dt.Columns.Contains(col))
                                    {
                                        var val = row[col]?.ToString() ?? string.Empty;
                                        if (val == contraseña)
                                        {
                                            mensaje = "Ingreso correcto.";
                                            return true;
                                        }
                                    }
                                }
                            }

                            mensaje = "Contraseña incorrecta.";
                            return false;
                        }
                    }
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
