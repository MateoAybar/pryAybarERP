using System;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace pryAYbarERP.BaseDatos
{
    internal class Conexionbd
    {
        public static string ConnectionString { get; private set; }

        private static bool PrepararConexion(out string mensaje)
        {
            try
            {
                string carpeta = BuscarCarpetaBaseDatos();
                string[] archivos = carpeta == null ? new string[0] : Directory.GetFiles(carpeta, "*.accdb");
                if (archivos.Length == 0)
                {
                    mensaje = "No se encontro ningun archivo .accdb en BaseDatos.";
                    return false;
                }

                ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + archivos[0] + ";Persist Security Info=False;";
                mensaje = "Usando base de datos: " + Path.GetFileName(archivos[0]);
                return true;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }

        private static string BuscarCarpetaBaseDatos()
        {
            DirectoryInfo carpetaActual = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string carpetaEncontrada = null;

            while (carpetaActual != null)
            {
                string posibleCarpeta = Path.Combine(carpetaActual.FullName, "BaseDatos");
                if (Directory.Exists(posibleCarpeta))
                    carpetaEncontrada = posibleCarpeta;

                carpetaActual = carpetaActual.Parent;
            }

            return carpetaEncontrada;
        }

        public static bool ProbarConexion(out string mensaje)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString) && !PrepararConexion(out mensaje))
                return false;

            try
            {
                using (OleDbConnection cn = GetConnection())
                {
                    cn.Open();
                }

                mensaje = "Conexion exitosa a la base de datos.";
                return true;
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
                string mensaje;
                PrepararConexion(out mensaje);
            }

            return new OleDbConnection(ConnectionString);
        }

        private static DataTable Consultar(string sql, out string mensaje, params object[] parametros)
        {
            mensaje = "";
            DataTable tabla = new DataTable();

            try
            {
                using (OleDbConnection cn = GetConnection())
                using (OleDbCommand cmd = new OleDbCommand(sql, cn))
                {
                    AgregarParametros(cmd, parametros);
                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                    {
                        adapter.Fill(tabla);
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return null;
            }

            return tabla;
        }

        private static void AgregarParametros(OleDbCommand cmd, params object[] valores)
        {
            foreach (object valor in valores)
                cmd.Parameters.AddWithValue("?", valor ?? DBNull.Value);
        }

        private static bool ExisteTabla(OleDbConnection cn, string nombreTabla)
        {
            DataTable tablas = cn.GetSchema("Tables");
            foreach (DataRow fila in tablas.Rows)
            {
                if (fila["TABLE_NAME"].ToString().Equals(nombreTabla, StringComparison.OrdinalIgnoreCase))
                    return true;
            }

            return false;
        }

        private static bool TextoActivo(object valor)
        {
            string texto = (valor ?? "").ToString().Trim().ToLower();
            return texto == "" || texto == "si" || texto == "sí" || texto == "true" || texto == "activo" || texto == "1";
        }

        public static bool ValidarUsuario(string usuarioOMail, string contrasena, out string mensaje)
        {
            string sql = @"SELECT TOP 1 Id_Usuario, Nombre, Mail, [Contraseña], Activo
                           FROM Usuario
                           WHERE Nombre = ? OR Mail = ?";

            DataTable tabla = Consultar(sql, out mensaje, usuarioOMail, usuarioOMail);
            if (tabla == null)
            {
                mensaje = "Error al validar usuario: " + mensaje;
                return false;
            }

            if (tabla.Rows.Count == 0)
            {
                mensaje = "Usuario o correo no encontrado.";
                return false;
            }

            DataRow usuario = tabla.Rows[0];
            if (!TextoActivo(usuario["Activo"]))
            {
                mensaje = "El usuario esta dado de baja.";
                return false;
            }

            if (usuario["Contraseña"].ToString() != contrasena)
            {
                mensaje = "Contraseña incorrecta.";
                return false;
            }

            mensaje = "Ingreso correcto.";
            return true;
        }

        public static void GrabarAuditoriaSesion(string usuario, string detalle)
        {
            try
            {
                using (OleDbConnection cn = GetConnection())
                using (OleDbCommand cmd = new OleDbCommand(
                    "INSERT INTO AuditoriaSesion (Fecha, Hora, Usuario, Detalle) VALUES (?, ?, ?, ?)", cn))
                {
                    cn.Open();
                    AgregarParametros(cmd, DateTime.Today, DateTime.Now.ToString("HH:mm:ss"), usuario, detalle);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // La auditoria no debe cerrar la aplicacion si Access rechaza el registro.
            }
        }

        public static DataTable ObtenerPerfiles(out string mensaje)
        {
            return Consultar("SELECT Id_Perfil, Nombre FROM Perfil ORDER BY Nombre", out mensaje);
        }

        public static DataTable ObtenerProvincias(out string mensaje)
        {
            return Consultar("SELECT [Id-Provincias] AS Id_Provincias, Provincias FROM Provincias ORDER BY Provincias", out mensaje);
        }

        public static DataTable ObtenerLocalidades(int idProvincia, out string mensaje)
        {
            return Consultar("SELECT [Id-Localidad] AS Id_Localidades, Localidad FROM Localidades ORDER BY Localidad", out mensaje);
        }

        public static DataTable ObtenerUsuariosCompleto(out string mensaje)
        {
            string sql = @"SELECT Id_Usuario, Nombre, Apellido, Mail, Telefono, RedesSociales, Activo
                           FROM Usuario
                           ORDER BY Apellido, Nombre";

            DataTable tabla = Consultar(sql, out mensaje);
            AgregarNombreCompleto(tabla);
            return tabla;
        }

        public static DataRow ObtenerDatosUsuario(int idUsuario, out string mensaje)
        {
            string sql = @"SELECT Id_Usuario, Nombre, Apellido, Mail, Telefono, RedesSociales, Activo, Domicilio
                           FROM Usuario
                           WHERE Id_Usuario = ?";

            DataTable tabla = Consultar(sql, out mensaje, idUsuario);
            if (tabla == null || tabla.Rows.Count == 0)
                return null;

            return tabla.Rows[0];
        }

        public static int ObtenerPerfilUsuario(int idUsuario, out string mensaje)
        {
            mensaje = "";
            try
            {
                using (OleDbConnection cn = GetConnection())
                using (OleDbCommand cmd = new OleDbCommand(
                    @"SELECT TOP 1 r.Id_Perfil
                      FROM [Relacion Us-Pe] AS r
                      WHERE r.Id_Usuario = ?
                      ORDER BY r.Id DESC", cn))
                {
                    cn.Open();
                    AgregarParametros(cmd, idUsuario.ToString());
                    object valor = cmd.ExecuteScalar();
                    if (valor == null || valor == DBNull.Value)
                        return 0;

                    int perfilId;
                    return int.TryParse(valor.ToString(), out perfilId) ? perfilId : 0;
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return 0;
            }
        }

        private static void AgregarNombreCompleto(DataTable tabla)
        {
            if (tabla == null || tabla.Columns.Contains("NombreCompleto"))
                return;

            tabla.Columns.Add("NombreCompleto", typeof(string));
            foreach (DataRow fila in tabla.Rows)
            {
                string apellido = fila["Apellido"].ToString();
                string nombre = fila["Nombre"].ToString();
                fila["NombreCompleto"] = (apellido + ", " + nombre).Trim(' ', ',');
            }
        }

        public static bool RegistrarUsuarioCompleto(string dni, string nombre, string apellido,
            string mail, string contrasena, int idPerfil, string telefono,
            string redesSociales, DataTable domicilios, out string mensaje)
        {
            mensaje = "";
            OleDbTransaction tx = null;

            try
            {
                using (OleDbConnection cn = GetConnection())
                {
                    cn.Open();
                    tx = cn.BeginTransaction();

                    if (ExisteValor(cn, tx, "SELECT COUNT(*) FROM Usuario WHERE Mail = ?", mail))
                        throw new Exception("Ya existe un usuario con ese correo.");

                    if (ExisteValor(cn, tx, "SELECT COUNT(*) FROM Usuario WHERE DNI = ?", dni))
                        throw new Exception("Ya existe una persona con ese DNI.");

                    int idUsuario = InsertarUsuario(cn, tx, dni, nombre, apellido, mail, contrasena, telefono, redesSociales, true, domicilios);
                    InsertarRelacionPerfil(cn, tx, idUsuario, idPerfil);

                    tx.Commit();
                }

                mensaje = "Usuario registrado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                if (tx != null)
                {
                    try { tx.Rollback(); } catch { }
                }

                mensaje = "Error al registrar usuario: " + ex.Message;
                return false;
            }
        }

        private static bool ExisteValor(OleDbConnection cn, OleDbTransaction tx, string sql, object valor)
        {
            using (OleDbCommand cmd = new OleDbCommand(sql, cn, tx))
            {
                AgregarParametros(cmd, valor);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        private static int InsertarUsuario(OleDbConnection cn, OleDbTransaction tx,
            string dni, string nombre, string apellido, string mail, string contrasena,
            string telefono, string redesSociales, bool activo, DataTable domicilios)
        {
            using (OleDbCommand cmd = new OleDbCommand(
                @"INSERT INTO Usuario
                  (DNI, Nombre, Apellido, Mail, [Contraseña], Telefono, RedesSociales, Activo, Domicilio)
                  VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)", cn, tx))
            {
                AgregarParametros(cmd, dni, nombre, apellido, mail, contrasena, telefono,
                    redesSociales, activo ? "Si" : "No", PrepararTextoDomicilios(domicilios));
                cmd.ExecuteNonQuery();
            }

            using (OleDbCommand cmd = new OleDbCommand("SELECT @@IDENTITY", cn, tx))
                return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private static void InsertarRelacionPerfil(OleDbConnection cn, OleDbTransaction tx, int idUsuario, int idPerfil)
        {
            using (OleDbCommand cmd = new OleDbCommand(
                "INSERT INTO [Relacion Us-Pe] (Id_Usuario, Id_Perfil) VALUES (?, ?)", cn, tx))
            {
                AgregarParametros(cmd, idUsuario.ToString(), idPerfil.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        private static string PrepararTextoDomicilios(DataTable domicilios)
        {
            if (domicilios == null || domicilios.Rows.Count == 0)
                return "";

            string texto = "";
            foreach (DataRow fila in domicilios.Rows)
            {
                string linea = fila["Direccion"] + " - " + fila["Localidad"] + " - " + fila["Provincias"];
                texto += linea + Environment.NewLine;
            }

            return texto.Trim();
        }

        public static bool EditarUsuario(int idUsuario, string nombre, string apellido,
            string mail, string nuevaContrasena, string telefono,
            string redesSociales, string domicilio, bool activo, int idPerfil, out string mensaje)
        {
            mensaje = "";
            OleDbTransaction tx = null;

            try
            {
                using (OleDbConnection cn = GetConnection())
                {
                    cn.Open();
                    tx = cn.BeginTransaction();

                    ActualizarUsuario(cn, tx, idUsuario, nombre, apellido, mail,
                        nuevaContrasena, telefono, redesSociales, domicilio, activo);
                    ActualizarPerfilUsuario(cn, tx, idUsuario, idPerfil);
                    tx.Commit();
                }

                mensaje = "Usuario actualizado correctamente.";
                return true;
            }
            catch (Exception ex)
            {
                if (tx != null)
                {
                    try { tx.Rollback(); } catch { }
                }

                mensaje = "Error al editar usuario: " + ex.Message;
                return false;
            }
        }

        private static void ActualizarUsuario(OleDbConnection cn, OleDbTransaction tx, int idUsuario,
            string nombre, string apellido, string mail, string nuevaContrasena,
            string telefono, string redesSociales, string domicilio, bool activo)
        {
            string sql = "UPDATE Usuario SET Nombre = ?, Apellido = ?, Mail = ?, Telefono = ?, RedesSociales = ?, Domicilio = ?, Activo = ?";
            if (!string.IsNullOrWhiteSpace(nuevaContrasena))
                sql += ", [Contraseña] = ?";
            sql += " WHERE Id_Usuario = ?";

            using (OleDbCommand cmd = new OleDbCommand(sql, cn, tx))
            {
                AgregarParametros(cmd, nombre, apellido, mail, telefono, redesSociales, domicilio, activo ? "Si" : "No");
                if (!string.IsNullOrWhiteSpace(nuevaContrasena))
                    AgregarParametros(cmd, nuevaContrasena);
                AgregarParametros(cmd, idUsuario);
                cmd.ExecuteNonQuery();
            }
        }

        private static void ActualizarPerfilUsuario(OleDbConnection cn, OleDbTransaction tx, int idUsuario, int idPerfil)
        {
            using (OleDbCommand cmdDelete = new OleDbCommand("DELETE FROM [Relacion Us-Pe] WHERE Id_Usuario = ?", cn, tx))
            {
                AgregarParametros(cmdDelete, idUsuario.ToString());
                cmdDelete.ExecuteNonQuery();
            }

            using (OleDbCommand cmdInsert = new OleDbCommand(
                "INSERT INTO [Relacion Us-Pe] (Id_Usuario, Id_Perfil) VALUES (?, ?)", cn, tx))
            {
                AgregarParametros(cmdInsert, idUsuario.ToString(), idPerfil.ToString());
                cmdInsert.ExecuteNonQuery();
            }
        }
    }
}
