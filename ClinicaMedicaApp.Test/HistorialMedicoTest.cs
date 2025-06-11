using NUnit.Framework;
using System;
using ClinicaMedicaApp.Entidades.Pacientes;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class HistorialMedicoTests
    {
        [Test]
        public void HistorialMedico_SeCreaCorrectamente()
        {
            var historial = new HistorialMedico(1, 101, new DateTime(2025, 6, 1), "Chequeo general", "Todo normal");

            Assert.Multiple(() =>
            {
                Assert.That(historial.Id, Is.EqualTo(1));
                Assert.That(historial.IdPaciente, Is.EqualTo(101));
                Assert.That(historial.Descripcion, Is.EqualTo("Chequeo general"));
                Assert.That(historial.Notas, Is.EqualTo("Todo normal"));
            });
        }

        [Test]
        public void HistorialMedico_AgregarEntrada_ActualizaDatos()
        {
            var historial = new HistorialMedico(1, 101, DateTime.Today, "Inicial", "N/A");

            historial.AgregarEntrada(new DateTime(2025, 6, 2), "Control de presión", "Presión alta");

            Assert.Multiple(() =>
            {
                Assert.That(historial.Fecha, Is.EqualTo(new DateTime(2025, 6, 2)));
                Assert.That(historial.Descripcion, Is.EqualTo("Control de presión"));
                Assert.That(historial.Notas, Is.EqualTo("Presión alta"));
            });
        }

         [Test, Category("Regresion_Resumen")]
        public void ToString_HistorialMedico_DevuelveFormatoEsperado()
        {
            var historial = new HistorialMedico(1, 1, new DateTime(2025, 6, 10), "Dolor de cabeza", "Paciente en reposo.");

            string resultado = historial.ToString();
            string esperado = "Fecha: 10/06/2025 - Descripción: Dolor de cabeza - Notas: Paciente en reposo.";

            Assert.That(resultado, Is.EqualTo(esperado));
        }
    }
}