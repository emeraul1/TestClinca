using System;
using System.Linq;
using System.Collections.Generic;
using ClinicaMedicaApp.Entidades.Citas;

namespace ClinicaMedicaApp.Entidades.Reportes
{
    //Genera un reporte financiero que incluye los pagos asociados a citas completadas en fechas espeficicas 

    public class ReporteFinanciero
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public double IngresosTotales { get; private set; }

        // Constructor que recibe inicio y fin de rango.

        public ReporteFinanciero(DateTime inicio, DateTime fin)
        {
            FechaInicio = inicio;
            FechaFin = fin;
            IngresosTotales = 0;
        }

        // Recorre la lista de citas, filtra sólo las completadas y con pago, en la fecha de pago y suma esos montos.

        public void GenerarReporte(List<Cita> todasLasCitas)
        {
        IngresosTotales = todasLasCitas
        .Where(c => c.Estado == Entidades.Enumeraciones.EstadoCita.Completada)
        .Where(c => c.PagoRef != null && c.PagoRef.FechaPago >= FechaInicio && c.PagoRef.FechaPago <= FechaFin)
        .Sum(c => c.PagoRef!.Monto);
        }

        public override string ToString()
        {
            return $"REPORTE FINANCIERO\n" + $"Desde: {FechaInicio:d}  Hasta: {FechaFin:d}\n" + $"Ingresos Totales: {IngresosTotales:C}\n";
        }
    }
}