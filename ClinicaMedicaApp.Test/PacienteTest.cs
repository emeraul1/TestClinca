using NUnit.Framework;
using System;
using ClinicaMedicaApp.Entidades.Pacientes;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class PacienteTests
    {
        [Test]
        public void Paciente_SeInstanciaCorrectamente()
        {
            var paciente = new Paciente(1, "Luis", new DateTime(1985, 3, 10), "2345-6789", "Chalatenango");

            Assert.Multiple(() =>
            {
                Assert.That(paciente.Nombre, Is.EqualTo("Luis"));
                Assert.That(paciente.Direccion, Is.EqualTo("Chalatenango"));
            });
        }

            [Test, Category("Regresion_Resumen")]
        public void ToString_DePaciente_DevuelveFormatoCorrecto()
        {
        
            var paciente = new Paciente(
                id: 10,
                nombre: "Carlos Martínez",
                fechaNac: new DateTime(1990, 4, 15),
                contacto: "7744-3322",
                direccion: "Colonia Escalón"
            );


            var resultado = paciente.ToString();

            var esperado = "Paciente: Carlos Martínez, Nacimiento: 15/04/1990, Contacto: 7744-3322, Dirección: Colonia Escalón";
            Assert.That(resultado, Is.EqualTo(esperado));
        }

    }
}