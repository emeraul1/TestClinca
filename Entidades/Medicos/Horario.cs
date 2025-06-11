using System;

namespace ClinicaMedicaApp.Entidades.Medicos
{
    /// Representa una franja de tiempo que un médico puede reservar para citas.
    public class Horario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public string Ubicacion { get; set; }

        public Horario(int id, DateTime fecha, TimeSpan horaInicio, TimeSpan horaFin, string ubicacion)
        {
            Id = id;
            Fecha = fecha;
            HoraInicio = horaInicio;
            HoraFin = horaFin;
            Ubicacion = ubicacion;
        }

        // Indicar si el horario se considera libre para reservar
        // siempre devolverá true
        public bool EstaDisponible() => true;

        public override string ToString()
        {
            return $"{Fecha:d} [{HoraInicio:hh\\:mm} – {HoraFin:hh\\:mm}] en {Ubicacion}";
        }
    }
}
