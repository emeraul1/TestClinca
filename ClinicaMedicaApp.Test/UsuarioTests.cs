using NUnit.Framework;
using ClinicaMedicaApp.Entidades.Usuarios;
using ClinicaMedicaApp.Entidades.Enumeraciones;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class UsuarioTests
    {
        [Test]
        public void Usuario_SeCreaCorrectamente()
        {
            var usuario = new Usuario(1, "usuario1", "clave123", Rol.Medico);

            Assert.That(usuario.NombreUsuario, Is.EqualTo("usuario1"));
            Assert.That(usuario.Rol, Is.EqualTo(Rol.Medico));
        }
    }
}
