using NUnit.Framework;
using System;
using ClinicaMedicaApp.Entidades.Pacientes;
using ClinicaMedicaApp.Entidades.Medicos;
using ClinicaMedicaApp.Entidades.Citas;
using ClinicaMedicaApp.Entidades.Enumeraciones;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class CitaTests
    {
        [Test]
        public void Cita_SeCompletaCorrectamente()
        {

            var paciente = new Paciente(1, "Ana", DateTime.Now.AddYears(-30), "2222-2222", "San Salvador");
            var medico = new Medico(1, "Dr. Luis", "Dermatología", "7777-7777");
            var horario = new Horario(1, DateTime.Today, new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0), "Consultorio 1");
            var cita = new Cita(1, paciente, medico, horario);


            cita.Completar();

            Assert.That(cita.Estado, Is.EqualTo(EstadoCita.Completada), "El estado debe cambiar a Completada");
        }

        [Test, Category("Cancelar_Cita")]
        public void Cancelar_CitaProgramada_CambiaEstadoACancelada()
        {
            var paciente = new Paciente(1, "Juan", DateTime.Today, "7777-8888", "San Salvador");
            var medico = new Medico(1, "Dra. Ana", "Cardiología", "ana@correo.com");
            var horario = new Horario(1, DateTime.Today, new TimeSpan(9, 0, 0), new TimeSpan(10, 0, 0), "Sala 1");

            var cita = new Cita(1, paciente, medico, horario);

            bool resultado = cita.Cancelar();

            Assert.That(resultado, Is.True);
            Assert.That(cita.Estado.ToString(), Is.EqualTo("Cancelada"));
        } 
        
        [Test, Category("Regresion_Confirmacion")]
        public void Completar_CitaProgramada_CambiaEstadoACompletada()
        {
            var paciente = new Paciente(2, "Ana", DateTime.Today, "8888-7777", "Santa Ana");
            var medico = new Medico(2, "Dr. Pérez", "Neurología", "perez@correo.com");
            var horario = new Horario(2, DateTime.Today, new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), "Consultorio 3");

            var cita = new Cita(2, paciente, medico, horario);

            cita.Completar();

            Assert.That(cita.Estado.ToString(), Is.EqualTo("Completada"));
        }
    }
}