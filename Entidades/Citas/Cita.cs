using System;
using ClinicaMedicaApp.Entidades.Pacientes;
using ClinicaMedicaApp.Entidades.Medicos;
using ClinicaMedicaApp.Entidades.Pagos;
using ClinicaMedicaApp.Entidades.Enumeraciones;

namespace ClinicaMedicaApp.Entidades.Citas
{

    /// cita médica: vincula paciente, médico, horario y, opcionalmente, un pago.
    /// Estados posibles:
/// - Programada: cita agendada, aún no atendida.
    
    public class Cita
    {
        public int Id { get; set; }
        public EstadoCita Estado { get; private set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdPago { get; set; }       // Si no se ha pagado, puede quedar en 0.
        public DateTime FechaHora { get; set; }

        public Paciente PacienteRef { get; set; }
        public Medico MedicoRef { get; set; }
        public Horario HorarioRef { get; set; }
        public Pago? PagoRef { get; set; }

        public Cita(int id, Paciente paciente, Medico medico, Horario horario)
        {
            Id = id;
            PacienteRef = paciente;
            MedicoRef = medico;
            HorarioRef = horario;
            IdPaciente = paciente.Id;
            IdMedico = medico.Id;
            Estado = EstadoCita.Programada;
            FechaHora = horario.Fecha + horario.HoraInicio;
            PagoRef = null;
            IdPago = 0;
        }


        /// Reagenda la cita a un nuevo horario (si está disponible).

        public bool Reagendar(Horario nuevoHorario)
        {
            if (!nuevoHorario.EstaDisponible()) return false;
            HorarioRef = nuevoHorario;
            FechaHora = nuevoHorario.Fecha + nuevoHorario.HoraInicio;
            Estado = EstadoCita.Programada;
            return true;
        }

        
        /// Cancela la cita sólo si aún está programada.
        
        public bool Cancelar()
        {
            if (Estado != EstadoCita.Programada) return false;
            Estado = EstadoCita.Cancelada;
            return true;
        }


        /// Marca la cita como completada (luego de que el médico la atienda).
        
        public void Completar()
        {
            Estado = EstadoCita.Completada;
        }

        public override string ToString()
        {
            string pagoInfo = (PagoRef != null) ? $"(Pagado: {PagoRef.Monto:C} el {PagoRef.FechaPago:d})" : "(Sin pago)";
            return $"Cita {Id}: {PacienteRef.Nombre} con Dr. {MedicoRef.Nombre} el {FechaHora:g} – Estado: {Estado} {pagoInfo}";
        }
    }
}