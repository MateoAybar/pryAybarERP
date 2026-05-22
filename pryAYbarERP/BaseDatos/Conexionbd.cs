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
            OleDbConnection cn = null;
            try
            {
                cn = GetConnection();
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
                    cmdRelacion.Parameters.AddWithValue("?", nuevoIdUsuario);
                    cmdRelacion.Parameters.AddWithValue("?", idPerfil);

                    cmdRelacion.ExecuteNonQuery();
                }

                transaction.Commit();
                mensaje = "Usuario registrado exitosamente.";
                return true;
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
            finally
            {
                if (cn != null)
                {
                    try { cn.Close(); cn.Dispose(); } catch { }
                }
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
                    string sql = "SELECT Id AS Id_Provincias, Provincias FROM Provincias ORDER BY Provincias ASC";
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
                    string sql = "SELECT Id AS Id_Localidades, Localidad AS Localidades FROM Localidades ORDER BY Localidad ASC";
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

        // Obtiene lista completa de usuarios con datos de contacto
        public static DataTable ObtenerUsuariosCompleto(out string mensaje)
        {
            mensaje = string.Empty;
            var dt = new DataTable();
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = @"SELECT u.Id_Usuario, u.Nombre, u.Apellido, u.Mail, c.Telefono, c.RedesSociales, c.Activo
                                 FROM Usuario u
                                 LEFT JOIN Contacto c ON u.Id_Usuario = c.Id_Usuario";
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
                mensaje = $"Error al obtener usuarios completos: {ex.Message}";
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
                    string sql = "SELECT d.Id_Domicilio, d.DNI_Personal, d.Direccion, d.Id_Provincias, p.Provincias AS Provincia, d.Id_Localidades, l.Localidades AS Localidad " +
                                 "FROM ((Domicilio d " +
                                 "LEFT JOIN Provincias p ON d.Id_Provincias = p.Id_Provincias) " +
                                 "LEFT JOIN Localidades l ON d.Id_Localidades = l.Id_Localidades) " +
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
            OleDbConnection cn = null;
            try
            {
                cn = GetConnection();
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
                if (dtDomicilios != null && dtDomicilios.Rows.Count > 0)
                {
                    string sqlInsertDom = "INSERT INTO Domicilio (DNI_Personal, Direccion, Id_Provincias, Id_Localidades) VALUES (?, ?, ?, ?)";
                    foreach (DataRow row in dtDomicilios.Rows)
                    {
                        using (var cmdInsertDom = new OleDbCommand(sqlInsertDom, cn, transaction))
                        {
                            cmdInsertDom.Parameters.AddWithValue("?", dni);
                            cmdInsertDom.Parameters.AddWithValue("?", row["Direccion"]?.ToString() ?? "");
                            cmdInsertDom.Parameters.AddWithValue("?", Convert.ToInt32(row["Id_Provincias"]));
                            cmdInsertDom.Parameters.AddWithValue("?", Convert.ToInt32(row["Id_Localidades"]));
                            cmdInsertDom.ExecuteNonQuery();
                        }
                    }
                }

                transaction.Commit();
                mensaje = "Datos de personal y domicilios guardados correctamente.";
                return true;
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
            finally
            {
                if (cn != null)
                {
                    try { cn.Close(); cn.Dispose(); } catch { }
                }
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

        // Registra un usuario completo con datos personales y domicilio
        public static bool RegistrarUsuarioCompleto(string dni, string nombre, string apellido,
            string mail, string contrasena, int idPerfil, string telefono,
            string redesSociales, DataTable domicilios, out string mensaje)
        {
            // Asume activo por defecto
            return RegistrarUsuarioCompletoConPersonal(dni, nombre, apellido,
                mail, contrasena, idPerfil, telefono,
                redesSociales, true, domicilios, out mensaje);
        }

        // Registro completo con datos personales, usuario, perfil, contacto y domicilios
        public static bool RegistrarUsuarioCompletoConPersonal(string dni, string nombre, string apellido,
            string mail, string contrasena, int idPerfil, string telefono,
            string redesSociales, bool activo, DataTable domicilios, out string mensaje)
        {
            mensaje = "";
            OleDbTransaction tx = null;
            OleDbConnection cn = null;
            try
            {
                cn = GetConnection();
                cn.Open();
                tx = cn.BeginTransaction();

                // 1. Insertar en Personal
                string sqlPers = "INSERT INTO Personal (DNI, Apellido, Nombre) VALUES (?, ?, ?)";
                using (var cmdPers = new OleDbCommand(sqlPers, cn, tx))
                {
                    cmdPers.Parameters.AddWithValue("@dni", dni);
                    cmdPers.Parameters.AddWithValue("@apellido", apellido);
                    cmdPers.Parameters.AddWithValue("@nombre", nombre);
                    cmdPers.ExecuteNonQuery();
                }

                // 2. Insertar en Usuario
                string sqlUsr = "INSERT INTO Usuario (Nombre, Apellido, Mail, Contraseña) VALUES (?, ?, ?, ?)";
                using (var cmdUsr = new OleDbCommand(sqlUsr, cn, tx))
                {
                    cmdUsr.Parameters.AddWithValue("@nombre", nombre);
                    cmdUsr.Parameters.AddWithValue("@apellido", apellido);
                    cmdUsr.Parameters.AddWithValue("@mail", mail);
                    cmdUsr.Parameters.AddWithValue("@contrasena", contrasena);
                    cmdUsr.ExecuteNonQuery();
                }

                // Obtener Id del nuevo usuario
                int idUsuario;
                using (var cmdId = new OleDbCommand("SELECT @@IDENTITY", cn, tx))
                {
                    object objId = cmdId.ExecuteScalar();
                    if (objId != null && objId != DBNull.Value)
                    {
                        idUsuario = Convert.ToInt32(objId);
                    }
                    else
                    {
                        throw new Exception("No se pudo obtener el ID del usuario insertado.");
                    }
                }

                // 3. Relación Usuario-Perfil
                string sqlRel = "INSERT INTO [Relacion Us-Pe] (Id_Usuario, Id_Perfil) VALUES (?, ?)";
                using (var cmdRel = new OleDbCommand(sqlRel, cn, tx))
                {
                    cmdRel.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdRel.Parameters.AddWithValue("@idPerfil", idPerfil);
                    cmdRel.ExecuteNonQuery();
                }

                // 4. Contacto
                string sqlCon = "INSERT INTO Contacto (Id_Usuario, Telefono, RedesSociales, Activo) VALUES (?, ?, ?, ?)";
                using (var cmdCon = new OleDbCommand(sqlCon, cn, tx))
                {
                    cmdCon.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmdCon.Parameters.AddWithValue("@telefono", telefono ?? "");
                    cmdCon.Parameters.AddWithValue("@redesSociales", redesSociales ?? "");
                    cmdCon.Parameters.AddWithValue("@activo", activo);
                    cmdCon.ExecuteNonQuery();
                }

                // 5. Domicilios asociados al DNI
                if (domicilios != null && domicilios.Rows.Count > 0)
                {
                    string sqlDom = "INSERT INTO Domicilio (DNI_Personal, Direccion, Id_Provincias, Id_Localidades) VALUES (?, ?, ?, ?)";
                    foreach (DataRow row in domicilios.Rows)
                    {
                        using (var cmdDom = new OleDbCommand(sqlDom, cn, tx))
                        {
                            cmdDom.Parameters.AddWithValue("@dni", dni);
                            cmdDom.Parameters.AddWithValue("@direccion", row["Direccion"]?.ToString() ?? "");
                            cmdDom.Parameters.AddWithValue("@idProvincias", Convert.ToInt32(row["Id_Provincias"]));
                            cmdDom.Parameters.AddWithValue("@idLocalidades", Convert.ToInt32(row["Id_Localidades"]));
                            cmdDom.ExecuteNonQuery();
                        }
                    }
                }

                tx.Commit();
                mensaje = "Usuario registrado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                if (tx != null)
                {
                    try { tx.Rollback(); } catch { }
                }
                mensaje = $"Error al registrar usuario: {ex.Message}";
                return false;
            }
            finally
            {
                if (cn != null)
                {
                    try { cn.Close(); cn.Dispose(); } catch { }
                }
            }
        }

        // Obtiene todos los datos de un usuario (Usuario + Contacto)
        public static DataRow ObtenerDatosUsuario(int idUsuario, out string mensaje)
        {
            mensaje = string.Empty;
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    string sql = @"SELECT u.Id_Usuario, u.Nombre, u.Apellido, u.Mail,
                                   c.Telefono, c.RedesSociales, c.Activo
                                   FROM Usuario u
                                   LEFT JOIN Contacto c ON u.Id_Usuario = c.Id_Usuario
                                   WHERE u.Id_Usuario = ?";
                    using (var cmd = new OleDbCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("?", idUsuario);
                        using (var adapter = new OleDbDataAdapter(cmd))
                        {
                            var dt = new DataTable();
                            adapter.Fill(dt);
                            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = $"Error al obtener datos de usuario: {ex.Message}";
                return null;
            }
        }

        // Edita los datos de un usuario y su contacto (opcional cambio de contraseña)
        public static bool EditarUsuario(int idUsuario, string nombre, string apellido,
            string mail, string nuevaContrasena, string telefono,
            string redesSociales, bool activo, out string mensaje)
        {
            mensaje = string.Empty;
            OleDbTransaction tx = null;
            OleDbConnection cn = null;
            try
            {
                cn = GetConnection();
                cn.Open();
                tx = cn.BeginTransaction();

                // 1. Actualizar tabla Usuario
                string sqlUpd = "UPDATE Usuario SET Nombre = ?, Apellido = ?, Mail = ?" +
                                (string.IsNullOrWhiteSpace(nuevaContrasena) ? "" : ", Contraseña = ?") +
                                " WHERE Id_Usuario = ?";
                using (var cmdActualizarUsuario = new OleDbCommand(sqlUpd, cn, tx))
                {
                    cmdActualizarUsuario.Parameters.AddWithValue("?", nombre);
                    cmdActualizarUsuario.Parameters.AddWithValue("?", apellido);
                    cmdActualizarUsuario.Parameters.AddWithValue("?", mail);
                    if (!string.IsNullOrWhiteSpace(nuevaContrasena))
                        cmdActualizarUsuario.Parameters.AddWithValue("?", nuevaContrasena);
                    cmdActualizarUsuario.Parameters.AddWithValue("?", idUsuario);
                    cmdActualizarUsuario.ExecuteNonQuery();
                }

                // 2. Guardar/actualizar contacto dentro de la misma transacción
                string sqlCheckContact = "SELECT COUNT(*) FROM Contacto WHERE Id_Usuario = ?";
                int existe = 0;
                using (var cmdCheck = new OleDbCommand(sqlCheckContact, cn, tx))
                {
                    cmdCheck.Parameters.AddWithValue("?", idUsuario);
                    existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                }

                if (existe > 0)
                {
                    string sqlUpdateContact = "UPDATE Contacto SET Telefono = ?, RedesSociales = ?, Activo = ? WHERE Id_Usuario = ?";
                    using (var cmdUpdateContact = new OleDbCommand(sqlUpdateContact, cn, tx))
                    {
                        cmdUpdateContact.Parameters.AddWithValue("?", telefono);
                        cmdUpdateContact.Parameters.AddWithValue("?", redesSociales);
                        cmdUpdateContact.Parameters.AddWithValue("?", activo);
                        cmdUpdateContact.Parameters.AddWithValue("?", idUsuario);
                        cmdUpdateContact.ExecuteNonQuery();
                    }
                }
                else
                {
                    string sqlInsertContact = "INSERT INTO Contacto (Id_Usuario, Telefono, RedesSociales, Activo) VALUES (?, ?, ?, ?)";
                    using (var cmdInsertContact = new OleDbCommand(sqlInsertContact, cn, tx))
                    {
                        cmdInsertContact.Parameters.AddWithValue("?", idUsuario);
                        cmdInsertContact.Parameters.AddWithValue("?", telefono);
                        cmdInsertContact.Parameters.AddWithValue("?", redesSociales);
                        cmdInsertContact.Parameters.AddWithValue("?", activo);
                        cmdInsertContact.ExecuteNonQuery();
                    }
                }

                tx.Commit();
                mensaje = "Usuario actualizado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                if (tx != null)
                {
                    try { tx.Rollback(); } catch { }
                }
                mensaje = $"Error al editar usuario: {ex.Message}";
                return false;
            }
            finally
            {
                if (cn != null)
                {
                    try { cn.Close(); cn.Dispose(); } catch { }
                }
            }
        }

        // Cambiar el estado del usuario (activar/desactivar)
        public static bool CambiarEstadoUsuario(int idUsuario, bool activar, out string mensaje)
        {
            mensaje = "";
            try
            {
                using (var cn = GetConnection())
                {
                    cn.Open();
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "UPDATE Contacto SET Activo = ? WHERE Id_Usuario = ?";
                        cmd.Parameters.AddWithValue("?", activar);
                        cmd.Parameters.AddWithValue("?", idUsuario);
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            mensaje = activar ? "Usuario activado correctamente." : "Usuario dado de baja correctamente.";
                            return true;
                        }
                        else
                        {
                            mensaje = "No se encontró el usuario especificado.";
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = "Error al cambiar el estado del usuario: " + ex.Message;
                return false;
            }
        }
    }
}
