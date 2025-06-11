using NUnit.Framework;
using System;
using ClinicaMedicaApp.Entidades.Medicos;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class HorarioTests
    {
        [Test]
        public void Horario_SeCreaCorrectamente()
        {
            var horario = new Horario(1, DateTime.Today, new TimeSpan(8, 0, 0), new TimeSpan(9, 0, 0), "Consultorio 2");

            Assert.That(horario.Ubicacion, Is.EqualTo("Consultorio 2"));
        }
        
          [Test, Category("Regresion_HorarioDisponible")]
        public void EstaDisponible_SiempreDevuelveTrue()
        {
            var horario = new Horario(4, DateTime.Today, new TimeSpan(16, 0, 0), new TimeSpan(17, 0, 0), "Sala B");

            bool disponible = horario.EstaDisponible();

            Assert.That(disponible, Is.True);
        }
    }
}