using System;
using ClinicaMedicaApp.Entidades.Enumeraciones;

namespace ClinicaMedicaApp.Entidades.Usuarios
{
    /// <summary>
    /// Representa un usuario del sistema con sus credenciales y rol.
    /// </summary>
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        private string _hashContrasena;
        public Rol Rol { get; set; }

        /// <summary>
        /// Constructor que recibe la contraseña en texto plano y guarda su hash.
        /// </summary>
        public Usuario(int id, string nombreUsuario, string contrasenaPlana, Rol rol)
        {
            Id = id;
            NombreUsuario = nombreUsuario;
            _hashContrasena = Hash(contrasenaPlana);
            Rol = rol;
        }

        /// <summary>
        /// Método privado que simula un hash muy básico (para propósitos de estudio).
        /// </summary>
        private string Hash(string texto)
        {
            // NOTA: en un proyecto real se usaría SHA256 o similar.
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(texto));
        }

        /// <summary>
        /// Verifica si la contraseña ingresada coincide con el hash almacenado.
        /// </summary>
        public bool IniciarSesion(string contrasenaPlana)
        {
            return Hash(contrasenaPlana) == _hashContrasena;
        }
    }
}