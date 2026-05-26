using System.Text.RegularExpressions;

namespace pryAYbarERP.Clases
{
    internal static class ValidadorUsuarios
    {
        public static bool ValidarRegistro(string dni, string nombre, string apellido, string mail,
            string contrasena, bool perfilSeleccionado, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(dni))
                return Error("Ingrese el DNI.", out mensaje);

            if (!Regex.IsMatch(dni, @"^\d{7,8}$"))
                return Error("El DNI debe tener 7 u 8 digitos numericos.", out mensaje);

            if (string.IsNullOrWhiteSpace(nombre))
                return Error("Ingrese el Nombre.", out mensaje);

            if (string.IsNullOrWhiteSpace(apellido))
                return Error("Ingrese el Apellido.", out mensaje);

            if (!MailValido(mail))
                return Error("Ingrese un correo electronico valido.", out mensaje);

            if (string.IsNullOrWhiteSpace(contrasena))
                return Error("Ingrese la Contrasena.", out mensaje);

            if (!perfilSeleccionado)
                return Error("Seleccione el Perfil de acceso.", out mensaje);

            return true;
        }

        public static bool ValidarEdicion(string nombre, string apellido, string mail, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(nombre))
                return Error("Ingrese el Nombre.", out mensaje);

            if (string.IsNullOrWhiteSpace(apellido))
                return Error("Ingrese el Apellido.", out mensaje);

            if (!MailValido(mail))
                return Error("Ingrese un correo electronico valido.", out mensaje);

            return true;
        }

        public static string ArmarRedSocial(string tipoRed, string usuarioRed)
        {
            if (string.IsNullOrWhiteSpace(tipoRed))
                return usuarioRed ?? "";

            return tipoRed + "|" + (usuarioRed ?? "");
        }

        public static bool EstaActivo(object valor)
        {
            string texto = (valor ?? "").ToString().Trim().ToLower();
            return texto == "" || texto == "si" || texto == "sí" || texto == "true" || texto == "activo" || texto == "1";
        }

        private static bool MailValido(string mail)
        {
            return !string.IsNullOrWhiteSpace(mail) && Regex.IsMatch(mail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private static bool Error(string texto, out string mensaje)
        {
            mensaje = texto;
            return false;
        }
    }
}
