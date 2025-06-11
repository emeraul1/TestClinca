using NUnit.Framework;
using ClinicaMedicaApp.Entidades.Medicos;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class MedicoTests
    {
        [Test]
        public void Medico_SeCreaCorrectamente()
        {
            var medico = new Medico(1, "Dra. Sofía", "Cardiología", "5555-8888");

            Assert.That(medico.Nombre, Is.EqualTo("Dra. Sofía"));
            Assert.That(medico.Especializacion, Is.EqualTo("Cardiología"));
        }

        
    }
}