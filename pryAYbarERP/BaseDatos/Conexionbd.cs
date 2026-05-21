using System;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Windows.Forms;

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

        // Valida usuario o email y contraseña contra la tabla 'Usuario' de la BD Access.
        public static bool ValidarUsuario(string usuarioOEmail, string contraseña, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    // Cargar todos los usuarios de la tabla
                    string sql = "SELECT * FROM Usuario";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);

                            // Buscar el usuario en memoria
                            foreach (DataRow row in dt.Rows)
                            {
                                string nombreBD = row["Nombre"]?.ToString() ?? "";
                                string mailBD = row["Mail"]?.ToString() ?? "";
                                string contraseñaBD = row["Contraseña"]?.ToString() ?? "";

                                // Comparar por nombre O email (case-insensitive)
                                if ((nombreBD.Equals(usuarioOEmail, StringComparison.OrdinalIgnoreCase) || 
                                     mailBD.Equals(usuarioOEmail, StringComparison.OrdinalIgnoreCase)))
                                {
                                    // Validar que la contraseña coincida EXACTAMENTE con este usuario
                                    if (contraseñaBD == contraseña)
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
                            }

                            // Si no encuentra el usuario
                            mensaje = "Usuario o correo no encontrado.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error: {ex.Message}";
                return false;
            }
        }

        // Graba intentos fallidos de inicio de sesión en la tabla AuditoriaSesion
        public static void GrabarAuditoriaSesion(string usuario)
        {
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();

                    string fecha = DateTime.Now.ToString("dd/MM/yyyy");
                    string hora = DateTime.Now.ToString("HH:mm:ss");
                    string detalle = "Datos incorrectos";
                    string usuarioEscapado = (usuario ?? "").Replace("'", "''");

                    // SQL INSERT directo
                    string sql = $"INSERT INTO AuditoriaSesion (Usuario, Detalle, Fecha, Hora) VALUES ('{usuarioEscapado}', '{detalle}', '{fecha}', '{hora}')";

                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        cmd.CommandTimeout = 10;
                        int resultado = cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al grabar auditoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Obtiene todos los perfiles registrados en la base de datos
        public static DataTable ObtenerPerfiles(out string mensaje)
        {
            mensaje = string.Empty;
            var dt = new DataTable();
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = "SELECT Id_Perfil, Nombre FROM Perfil ORDER BY Nombre ASC";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener perfiles: {ex.Message}";
                return null;
            }
        }

        // Registra un nuevo usuario insertando sus datos básicos en Usuario,
        // obteniendo el ID asignado, y creando la relación en [Relacion Us-Pe].
        public static bool RegistrarUsuario(string nombre, string apellido, string mail, string contrasena, int idPerfil, out string mensaje)
        {
            mensaje = string.Empty;
            OleDbTransaction transaction = null;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    transaction = cn.BeginTransaction();

                    // 1. Insertar en tabla Usuario
                    string sqlUsuario = "INSERT INTO Usuario (Nombre, Apellido, Mail, Contraseña) VALUES (?, ?, ?, ?)";
                    int nuevoIdUsuario = 0;
                    using (var cmdUsuario = new OleDbCommand(sqlUsuario, cn, transaction))
                    {
                        cmdUsuario.Parameters.AddWithValue("?", nombre);
                        cmdUsuario.Parameters.AddWithValue("?", apellido);
                        cmdUsuario.Parameters.AddWithValue("?", mail);
                        cmdUsuario.Parameters.AddWithValue("?", contrasena);

                        cmdUsuario.ExecuteNonQuery();
                    }

                    // 2. Obtener el ID generado por el AutoNumérico (Identity)
                    using (var cmdIdentity = new OleDbCommand("SELECT @@IDENTITY", cn, transaction))
                    {
                        object objId = cmdIdentity.ExecuteScalar();
                        if (objId != null && objId != DBNull.Value)
                        {
                            nuevoIdUsuario = Convert.ToInt32(objId);
                        }
                    }

                    if (nuevoIdUsuario <= 0)
                    {
                        throw new Exception("No se pudo obtener el ID del usuario insertado.");
                    }

                    // 3. Insertar relación en la tabla [Relacion Us-Pe]
                    string sqlRelacion = "INSERT INTO [Relacion Us-Pe] (Id_Usuario, Id_Perfil) VALUES (?, ?)";
                    using (var cmdRelacion = new OleDbCommand(sqlRelacion, cn, transaction))
                    {
                        cmdRelacion.Parameters.AddWithValue("?", nuevoIdUsuario.ToString());
                        cmdRelacion.Parameters.AddWithValue("?", idPerfil.ToString());

                        cmdRelacion.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    mensaje = "Usuario registrado exitosamente.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try { transaction.Rollback(); } catch { }
                }
                mensaje = $"Error al registrar usuario: {ex.Message}";
                return false;
            }
        }

        // Obtiene todas las provincias registradas
        public static DataTable ObtenerProvincias(out string mensaje)
        {
            mensaje = string.Empty;
            var dt = new DataTable();
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = "SELECT Id_Provincia, Nombre FROM Provincia ORDER BY Nombre ASC";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener provincias: {ex.Message}";
                return null;
            }
        }

        // Obtiene todas las localidades asociadas a una provincia específica
        public static DataTable ObtenerLocalidades(int idProvincia, out string mensaje)
        {
            mensaje = string.Empty;
            var dt = new DataTable();
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = "SELECT Id_Localidad, Nombre FROM Localidad WHERE Id_Provincia = ? ORDER BY Nombre ASC";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("?", idProvincia);
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener localidades: {ex.Message}";
                return null;
            }
        }

        // Obtiene los usuarios registrados en el sistema
        public static DataTable ObtenerUsuarios(out string mensaje)
        {
            mensaje = string.Empty;
            var dt = new DataTable();
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = "SELECT Id_Usuario, Nombre, Apellido, Mail FROM Usuario ORDER BY Apellido ASC, Nombre ASC";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener usuarios: {ex.Message}";
                return null;
            }
        }

        // Busca una persona por su DNI
        public static DataRow BuscarPersonal(string dni, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = "SELECT DNI, Apellido, Nombre FROM Personal WHERE DNI = ?";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("?", dni);
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                                return dt.Rows[0];
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al buscar personal: {ex.Message}";
                return null;
            }
        }

        // Obtiene los domicilios registrados para un DNI con los nombres de provincia y localidad
        public static DataTable ObtenerDomiciliosPersonal(string dni, out string mensaje)
        {
            mensaje = string.Empty;
            var dt = new DataTable();
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = "SELECT d.Id_Domicilio, d.DNI_Personal, d.Direccion, d.Id_Provincia, p.Nombre AS Provincia, d.Id_Localidad, l.Nombre AS Localidad " +
                                 "FROM ((Domicilio d " +
                                 "LEFT JOIN Provincia p ON d.Id_Provincia = p.Id_Provincia) " +
                                 "LEFT JOIN Localidad l ON d.Id_Localidad = l.Id_Localidad) " +
                                 "WHERE d.DNI_Personal = ?";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("?", dni);
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener domicilios: {ex.Message}";
                return null;
            }
        }

        // Guarda o actualiza los datos de una persona y sus domicilios asociados en una transacción
        public static bool GuardarPersonalConDomicilios(string dni, string apellido, string nombre, DataTable dtDomicilios, out string mensaje)
        {
            mensaje = string.Empty;
            OleDbTransaction transaction = null;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    transaction = cn.BeginTransaction();

                    // 1. Verificar si Personal existe, si sí, UPDATE, si no, INSERT
                    string sqlCheck = "SELECT COUNT(*) FROM Personal WHERE DNI = ?";
                    int existe = 0;
                    using (var cmdCheck = new OleDbCommand(sqlCheck, cn, transaction))
                    {
                        cmdCheck.Parameters.AddWithValue("?", dni);
                        existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    }

                    if (existe > 0)
                    {
                        string sqlUpdate = "UPDATE Personal SET Apellido = ?, Nombre = ? WHERE DNI = ?";
                        using (var cmdUpdate = new OleDbCommand(sqlUpdate, cn, transaction))
                        {
                            cmdUpdate.Parameters.AddWithValue("?", apellido);
                            cmdUpdate.Parameters.AddWithValue("?", nombre);
                            cmdUpdate.Parameters.AddWithValue("?", dni);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string sqlInsert = "INSERT INTO Personal (DNI, Apellido, Nombre) VALUES (?, ?, ?)";
                        using (var cmdInsert = new OleDbCommand(sqlInsert, cn, transaction))
                        {
                            cmdInsert.Parameters.AddWithValue("?", dni);
                            cmdInsert.Parameters.AddWithValue("?", apellido);
                            cmdInsert.Parameters.AddWithValue("?", nombre);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    // 2. Eliminar todos los domicilios existentes para este DNI
                    string sqlDelete = "DELETE FROM Domicilio WHERE DNI_Personal = ?";
                    using (var cmdDelete = new OleDbCommand(sqlDelete, cn, transaction))
                    {
                        cmdDelete.Parameters.AddWithValue("?", dni);
                        cmdDelete.ExecuteNonQuery();
                    }

                    // 3. Insertar los nuevos domicilios
                    string sqlInsertDom = "INSERT INTO Domicilio (DNI_Personal, Direccion, Id_Provincia, Id_Localidad) VALUES (?, ?, ?, ?)";
                    foreach (DataRow row in dtDomicilios.Rows)
                    {
                        using (var cmdInsertDom = new OleDbCommand(sqlInsertDom, cn, transaction))
                        {
                            cmdInsertDom.Parameters.AddWithValue("?", dni);
                            cmdInsertDom.Parameters.AddWithValue("?", row["Direccion"]?.ToString() ?? "");
                            cmdInsertDom.Parameters.AddWithValue("?", Convert.ToInt32(row["Id_Provincia"]));
                            cmdInsertDom.Parameters.AddWithValue("?", Convert.ToInt32(row["Id_Localidad"]));
                            cmdInsertDom.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    mensaje = "Datos de personal y domicilios guardados correctamente.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    try { transaction.Rollback(); } catch { }
                }
                mensaje = $"Error al guardar datos: {ex.Message}";
                return false;
            }
        }

        // Busca el contacto registrado para un usuario
        public static DataRow BuscarContactoUsuario(int idUsuario, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = "SELECT Id_Contacto, Id_Usuario, Telefono, RedesSociales, Activo FROM Contacto WHERE Id_Usuario = ?";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("?", idUsuario);
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            if (dt.Rows.Count > 0)
                                return dt.Rows[0];
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                mensaje = $"Error al buscar contacto: {ex.Message}";
                return null;
            }
        }

        // Guarda o actualiza la información de contacto de un usuario
        public static bool GuardarContactoUsuario(int idUsuario, string telefono, string redesSociales, bool activo, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    // Verificar si ya existe
                    string sqlCheck = "SELECT COUNT(*) FROM Contacto WHERE Id_Usuario = ?";
                    int existe = 0;
                    using (var cmdCheck = new OleDbCommand(sqlCheck, cn))
                    {
                        cmdCheck.Parameters.AddWithValue("?", idUsuario);
                        existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                    }

                    if (existe > 0)
                    {
                        string sqlUpdate = "UPDATE Contacto SET Telefono = ?, RedesSociales = ?, Activo = ? WHERE Id_Usuario = ?";
                        using (var cmdUpdate = new OleDbCommand(sqlUpdate, cn))
                        {
                            cmdUpdate.Parameters.AddWithValue("?", telefono);
                            cmdUpdate.Parameters.AddWithValue("?", redesSociales);
                            cmdUpdate.Parameters.AddWithValue("?", activo);
                            cmdUpdate.Parameters.AddWithValue("?", idUsuario);
                            cmdUpdate.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        string sqlInsert = "INSERT INTO Contacto (Id_Usuario, Telefono, RedesSociales, Activo) VALUES (?, ?, ?, ?)";
                        using (var cmdInsert = new OleDbCommand(sqlInsert, cn))
                        {
                            cmdInsert.Parameters.AddWithValue("?", idUsuario);
                            cmdInsert.Parameters.AddWithValue("?", telefono);
                            cmdInsert.Parameters.AddWithValue("?", redesSociales);
                            cmdInsert.Parameters.AddWithValue("?", activo);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    mensaje = "Datos de contacto guardados correctamente.";
                    return true;
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al guardar contacto: {ex.Message}";
                return false;
            }
        }
    }
}


