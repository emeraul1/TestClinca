using System;
using System.Collections.Generic;

namespace ClinicaMedicaApp.Entidades.Pacientes
{
    /// Representa a un paciente, sus datos básicos y la referencia a su historial médico.
    public class Paciente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DatosContacto { get; set; }
        public string Direccion { get; set; }

        /// Referencia a su historial médico (hay relación uno a uno).
        public HistorialMedico? Historial { get; set; }

        //Constructor se deja el Historial en null podrá inicializarse más tarde.
        public Paciente(int id, string nombre, DateTime fechaNac, string contacto, string direccion)
        {
            Id = id;
            Nombre = nombre;
            FechaNacimiento = fechaNac;
            DatosContacto = contacto;
            Direccion = direccion;
            Historial = null; // Se crea o asigna cuando se quiera agregar la primera entrada.
        }

        public override string ToString()
        {
            return $"Paciente: {Nombre}, Nacimiento: {FechaNacimiento:dd/MM/yyyy}, Contacto: {DatosContacto}, Dirección: {Direccion}";
        }
    }
}