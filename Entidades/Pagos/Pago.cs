using System;

namespace ClinicaMedicaApp.Entidades.Pagos
{
    // Representa el pago asociado a una cita.
    public class Pago
    {
        public int Id { get; set; }
        public double Monto { get; set; }
        public DateTime FechaPago { get; set; }

        public Pago(int id, double monto, DateTime fechaPago)
        {
            Id = id;
            Monto = monto;
            FechaPago = fechaPago;
        }

        //Simula el proceso de cobro. Aquí siempre devuelve true.
        public bool ProcesarPago()
        {
            return true;
        }
    }
}