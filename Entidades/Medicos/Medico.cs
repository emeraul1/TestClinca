using System.Collections.Generic;

namespace ClinicaMedicaApp.Entidades.Medicos
{
    /// Representa a un médico con su información y la lista de horarios disponibles.
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especializacion { get; set; }
        public string DatosContacto { get; set; }

        /// Lista de franjas horarias que el médico define y luego usarán las citas.
        public List<Horario> Horarios { get; } = new();

        public Medico(int id, string nombre, string especializacion, string datosContacto)
        {
            Id = id;
            Nombre = nombre;
            Especializacion = especializacion;
            DatosContacto = datosContacto;
        }
    }
}
