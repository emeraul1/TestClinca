using NUnit.Framework;
using ClinicaMedicaApp.Entidades.Enumeraciones;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class EstadoCitaTests
    {
        [Test, Category("Regresion_Enumeracion")]
        public void EstadoCita_ContieneValoresEsperados()
        {
            // Validar que la enumeración contiene los estados correctos
            Assert.That((int)EstadoCita.Programada, Is.EqualTo(0), "Programada debe ser 0");
            Assert.That((int)EstadoCita.Completada, Is.EqualTo(1), "Completada debe ser 1");
            Assert.That((int)EstadoCita.Cancelada, Is.EqualTo(2), "Cancelada debe ser 2");
        }

        [Test, Category("Conversión")]
        public void EstadoCita_PuedeConvertirseDesdeTexto()
        {
            EstadoCita estado = (EstadoCita)System.Enum.Parse(typeof(EstadoCita), "Completada");
            Assert.That(estado, Is.EqualTo(EstadoCita.Completada));
        }

        [Test, Category("Conversión")]
        public void EstadoCita_PuedeConvertirseAString()
        {
            string estadoTexto = EstadoCita.Cancelada.ToString();
            Assert.That(estadoTexto, Is.EqualTo("Cancelada"));
        }
    }
}