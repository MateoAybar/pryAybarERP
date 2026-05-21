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

                    // Buscar el usuario específico por usuario o email
                    string sql = "SELECT * FROM usuario WHERE Usuario = ? OR Mail = ?";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        // Especificar tipo de dato explícitamente
                        OleDbParameter param1 = cmd.Parameters.Add("@p1", OleDbType.VarChar);
                        param1.Value = usuarioOEmail;

                        OleDbParameter param2 = cmd.Parameters.Add("@p2", OleDbType.VarChar);
                        param2.Value = usuarioOEmail;

                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            if (dt.Rows.Count == 0)
                            {
                                mensaje = "Usuario o correo no encontrado.";
                                return false;
                            }

                            // Validar SOLO el primer usuario encontrado
                            DataRow usuarioEncontrado = dt.Rows[0];

                            // Obtener la contraseña del usuario encontrado
                            if (dt.Columns.Contains("Contraseña"))
                            {
                                string contraseñaAlmacenada = usuarioEncontrado["Contraseña"]?.ToString() ?? string.Empty;

                                // Comparar la contraseña ingresada con la del usuario específico
                                if (contraseñaAlmacenada == contraseña)
                                {
                                    mensaje = "Ingreso correcto.";
                                    return true;
                                }
                                else
                                {
                                    mensaje = "Contraseña incorrecta.";
                                    return false;
                                }
                            }
                            else
                            {
                                mensaje = "Error: Campo de contraseña no encontrado.";
                                return false;
                            }
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

        // Graba intentos fallidos de inicio de sesión en la tabla AuditoriaSesion
        public static void GrabarAuditoriaSesion(string usuario, string detalle)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                    string hora = DateTime.Now.ToString("HH:mm:ss");

                    string sql = "INSERT INTO AuditoriaSesion (Usuario, Detalle, Fecha, Hora) VALUES (?, ?, ?, ?)";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        // Especificar tipo de dato explícitamente
                        OleDbParameter param1 = cmd.Parameters.Add("@p1", OleDbType.VarChar);
                        param1.Value = usuario ?? "";

                        OleDbParameter param2 = cmd.Parameters.Add("@p2", OleDbType.VarChar);
                        param2.Value = detalle ?? "";

                        OleDbParameter param3 = cmd.Parameters.Add("@p3", OleDbType.VarChar);
                        param3.Value = fecha;

                        OleDbParameter param4 = cmd.Parameters.Add("@p4", OleDbType.VarChar);
                        param4.Value = hora;

                        int filasInsertadas = cmd.ExecuteNonQuery();
                        System.Diagnostics.Debug.WriteLine($"[AUDITORÍA] Intento de login fallido registrado: {usuario} - {detalle} ({filasInsertadas} filas)");
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"[ERROR AUDITORÍA] No se pudo grabar intento de login: {ex.Message} | Inner: {ex.InnerException?.Message}");
            }
        }
    }
}
