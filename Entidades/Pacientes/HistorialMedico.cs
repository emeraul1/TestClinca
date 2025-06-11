using System;

namespace ClinicaMedicaApp.Entidades.Pacientes
{
    // Cada paciente tiene un único historial médico en este modelo, como una sola nota; si hiciera falta más, se podría convertir en una lista.
    public class HistorialMedico
    {
        public int Id { get; set; }
        public int IdPaciente { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public string Notas { get; set; }

        // Constructor para inicializar una entrada de historial.
        public HistorialMedico(int id, int idPaciente, DateTime fecha, string descripcion, string notas)
        {
            Id = id;
            IdPaciente = idPaciente;
            Fecha = fecha;
            Descripcion = descripcion;
            Notas = notas;
        }

        //Permite actualizar la información de esta entrada.
        public void AgregarEntrada(DateTime fecha, string descripcion, string notas)
        {
            Fecha = fecha;
            Descripcion = descripcion;
            Notas = notas;
        }

        // Devuelve una cadena con los datos del historial 
        public override string ToString()
        {
            return $"Fecha: {Fecha:dd/MM/yyyy} - Descripción: {Descripcion} - Notas: {Notas}";
        }
    }
}