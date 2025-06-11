using NUnit.Framework;

namespace ClinicaMedicaApp.Test
{
    [TestFixture] // Esta es la etiqueta correcta para la clase
    public class UnitTest1
    {
        [SetUp] // Este método se ejecuta antes de cada prueba
        public void Setup()
        {
            // Inicialización si la necesitas
        }

        [Test]
        public void SumarDosMasDosDebeSerCuatro()
        {
            Assert.That(2 + 2, Is.EqualTo(4), "La suma de 2 + 2 debe ser 4.");
        }
    }
}