using System.Collections.Generic;
using ClinicaMedicaApp.Entidades.Usuarios;

namespace ClinicaMedicaApp.Helpers
{
    //Contiene la lógica simple de autenticación de usurio.
    public static class Auth
    {
        //
        // Pide usuario/contraseña, valida contra la lista y devuelve true o false.
        public static bool Login(List<Usuario> usuarios)
        {
            System.Console.Write("Usuario: ");
            string? user = System.Console.ReadLine();
            System.Console.Write("Contraseña: ");
            string? pass = System.Console.ReadLine();

            if (user == null || pass == null)
            {
                ConsoleHelper.ImprimirError("Entrada no válida.");
                return false;
            }

            var encontrado = usuarios.Find(u => u.NombreUsuario == user);
            if (encontrado != null && encontrado.IniciarSesion(pass))
            {
                ConsoleHelper.ImprimirHeader($"Bienvenido(a) {user} (Rol: {encontrado.Rol})");
                return true;
            }

            ConsoleHelper.ImprimirError("Credenciales incorrectas.");
            return false;
        }
    }
}