using NUnit.Framework;
using System;
using System.Collections.Generic;
using ClinicaMedicaApp.Entidades.Reportes;
using ClinicaMedicaApp.Entidades.Citas;
using ClinicaMedicaApp.Entidades.Pacientes;
using ClinicaMedicaApp.Entidades.Medicos;
using ClinicaMedicaApp.Entidades.Enumeraciones;
using ClinicaMedicaApp.Entidades.Pagos;

namespace ClinicaMedicaApp.Test
{
    [TestFixture]
    public class ReporteFinancieroTests
    {
        [Test]
        public void GenerarReporte_SumaSoloCitasCompletadasConPagoEnRango()
        {
            
            var paciente = new Paciente(1, "Ana", new DateTime(1990, 1, 1), "1234-5678", "San Salvador");
            var medico = new Medico(1, "Dr. López", "Pediatría", "9999-8888");
            var horario = new Horario(1, DateTime.Today, new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), "Consulta 1");

            var cita1 = new Cita(1, paciente, medico, horario);
            cita1.Completar();
            cita1.PagoRef = new Pago(1, 50.0, new DateTime(2025, 6, 1));

            var cita2 = new Cita(2, paciente, medico, horario); // No completada
            cita2.PagoRef = new Pago(2, 100.0, new DateTime(2025, 6, 1));

            var cita3 = new Cita(3, paciente, medico, horario); // Completada pero fuera de rango
            cita3.Completar();
            cita3.PagoRef = new Pago(3, 200.0, new DateTime(2025, 7, 1));

            var lista = new List<Cita> { cita1, cita2, cita3 };

            var reporte = new ReporteFinanciero(new DateTime(2025, 5, 30), new DateTime(2025, 6, 30));

        
            reporte.GenerarReporte(lista);


            Assert.That(reporte.IngresosTotales, Is.EqualTo(50.0));
        }
    }
}