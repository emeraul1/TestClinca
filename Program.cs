
namespace ClinicaMedicaApp
{
    using ClinicaMedicaApp.Entidades.Usuarios;
    using ClinicaMedicaApp.Entidades.Pacientes;
    using ClinicaMedicaApp.Entidades.Medicos;
    using ClinicaMedicaApp.Entidades.Citas;
    using ClinicaMedicaApp.Entidades.Pagos;
    using ClinicaMedicaApp.Entidades.Enumeraciones;
    using ClinicaMedicaApp.Entidades.Reportes;
    using ClinicaMedicaApp.Helpers;

    /// <summary>
    /// Punto de entrada de la aplicación. Contiene el menú principal y las subrutinas.
    /// </summary>
    public class Program
    {
        // “Base de datos” en memoria
        static List<Usuario> usuarios = new();
        static List<Paciente> pacientes = new();
        static List<HistorialMedico> historiales = new();
        static List<Medico> medicos = new();
        static List<Horario> horarios = new();
        static List<Cita> citas = new();
        static List<Pago> pagos = new();

       

        #region Menú Principal

        static void MenuPrincipal()
        {
             InicializarDatosDePrueba();

            ConsoleHelper.ImprimirHeader("Sistema de Gestión de Clínica Médica");

             // Autenticación con reintento
            while (!Auth.Login(usuarios))
            {
                ConsoleHelper.ImprimirError("Credenciales incorrectas. Intente nuevamente.\n");
            }

            // Ejecutamos el menu principal
            MenuPrincipal();
            
            while (true)
            {
                Console.WriteLine("MENÚ PRINCIPAL:");
                Console.WriteLine("1. Gestión de Pacientes");
                Console.WriteLine("2. Gestión de Médicos");
                Console.WriteLine("3. Gestión de Horarios");
                Console.WriteLine("4. Gestión de Citas");
                Console.WriteLine("5. Gestión de Pagos");
                Console.WriteLine("6. Reporte Financiero");
                Console.WriteLine("0. Salir");
                int opcion = ConsoleHelper.LeerEntero("\nSeleccione opción: ");

                switch (opcion)
                {
                    case 1:
                        GestionarPacientes();
                        break;
                    case 2:
                        GestionarMedicos();
                        break;
                    case 3:
                        GestionarHorarios();
                        break;
                    case 4:
                        GestionarCitas();
                        break;
                    case 5:
                        GestionarPagos();
                        break;
                    case 6:
                        MostrarReporteFinanciero();
                        break;
                    case 0:
                        Console.WriteLine("Gracias por utilizar el sistema. ¡Hasta luego!");
                        return;
                    default:
                        ConsoleHelper.ImprimirError("Opción inválida. Intente de nuevo.");
                        break;
                }
            }
        }

        #endregion

/*
 * En esta seción se inicializan los datos de prueba para el sistema.
 * Estos datos son utilizados para simular un entorno de trabajo y facilitar las pruebas del sistema.
  */
        #region Datos de Prueba

        static void InicializarDatosDePrueba()
        {
            // Usuarios iniciales
            usuarios.Add(new Usuario(1, "admin", "admin123", Rol.Administrador));
            usuarios.Add(new Usuario(2, "recep", "recep123", Rol.Recepcionista));
            usuarios.Add(new Usuario(3, "medico1", "med123", Rol.Medico));

            // Pacientes de Ejemplos
            pacientes.Add(new Paciente(1, "Carlos Lopez", new DateTime(1990, 5, 12), "2254-8996", "Usulutan San Martin 2"));
            pacientes.Add(new Paciente(2, "Ana Martínez", new DateTime(1985, 10, 3), "7777-2222", "San salvador, Colonia La Paz"));

            // Meditcos 
            medicos.Add(new Medico(1, "Dr. Juan Pérez", "Cardiología", "5555-3333"));
            medicos.Add(new Medico(2, "Dra. Laura Gómez", "Pediatría", "4444-4444"));
        }

        #endregion

        #region Gestión de Pacientes

        static void GestionarPacientes()
        {
            ConsoleHelper.ImprimirHeader("Gestión de Pacientes");
            Console.WriteLine("1. Agregar Paciente");
            Console.WriteLine("2. Listar Pacientes");
            Console.WriteLine("3. Agregar/Actualizar Historial Médico");
            Console.WriteLine("4. Ver Historial de un Paciente");
            Console.WriteLine("0. Volver al Menú Principal");
            int op = ConsoleHelper.LeerEntero("Opción: ");

            switch (op)
            {
                case 1:
                    AgregarPaciente();
                    break;
                case 2:
                    ListarPacientes();
                    break;
                case 3:
                    AgregarOActualizarHistorial();
                    break;
                case 4:
                    VerHistorialPaciente();
                    break;
                case 0:
                    return;
                default:
                    ConsoleHelper.ImprimirError("Opción inválida.");
                    break;
            }
        }

        static void AgregarPaciente()
        {
            ConsoleHelper.ImprimirHeader("Agregar Nuevo Paciente");

            int nuevoId = pacientes.Count + 1;
            string nombre = ConsoleHelper.LeerTextoNoVacio("Nombre completo: ");
            DateTime fechaNac = ConsoleHelper.LeerFecha("Fecha de nacimiento (dd/mm/yyyy): ");
            string contacto = ConsoleHelper.LeerTextoNoVacio("Datos de contacto (teléfono o correo): ");
            string direccion = ConsoleHelper.LeerTextoNoVacio("Dirección: ");

            var nuevo = new Paciente(nuevoId, nombre, fechaNac, contacto, direccion);
            pacientes.Add(nuevo);

            Console.WriteLine($"Paciente agregado con ID: {nuevoId}\n");
        }

        static void ListarPacientes()
        {
            ConsoleHelper.ImprimirHeader("Listado de Pacientes");
            if (pacientes.Count == 0)
            {
                Console.WriteLine("No hay pacientes registrados.\n");
                return;
            }

            foreach (var p in pacientes)
            {
                Console.WriteLine($"ID: {p.Id} | Nombre: {p.Nombre} | Nac: {p.FechaNacimiento:dd/MM/yyyy} | Contacto: {p.DatosContacto} | Dirección: {p.Direccion}");
            }
            Console.WriteLine();
        }

        static void AgregarOActualizarHistorial()
        {
            ConsoleHelper.ImprimirHeader("Agregar/Actualizar Historial Médico");

            if (pacientes.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay pacientes registrados.");
                return;
            }

            int idPac = ConsoleHelper.LeerEntero("Ingrese ID de Paciente: ");
            var paciente = pacientes.Find(p => p.Id == idPac);
            if (paciente == null)
            {
                ConsoleHelper.ImprimirError("Paciente no encontrado.");
                return;
            }

            string descripcion = ConsoleHelper.LeerTextoNoVacio("Breve descripción (motivo/observaciones): ");
            string notas = ConsoleHelper.LeerTextoNoVacio("Notas adicionales: ");
            DateTime fechaHist = DateTime.Now;

            if (paciente.Historial == null)
            {
                int nuevoHistId = historiales.Count + 1;
                var h = new HistorialMedico(nuevoHistId, idPac, fechaHist, descripcion, notas);
                historiales.Add(h);
                paciente.Historial = h;
                Console.WriteLine("Historial médico agregado al paciente.\n");
            }
            else
            {
                paciente.Historial.AgregarEntrada(fechaHist, descripcion, notas);
                Console.WriteLine("Historial médico actualizado.\n");
            }
        }

        static void VerHistorialPaciente()
        {
            ConsoleHelper.ImprimirHeader("Ver Historial Médico");

            if (pacientes.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay pacientes registrados.");
                return;
            }

            int idPac = ConsoleHelper.LeerEntero("ID de Paciente: ");
            var paciente = pacientes.Find(p => p.Id == idPac);
            if (paciente == null)
            {
                ConsoleHelper.ImprimirError("Paciente no encontrado.");
                return;
            }

            if (paciente.Historial == null)
            {
                Console.WriteLine("Este paciente no tiene historial médico registrado.\n");
            }
            else
            {
                Console.WriteLine($"Paciente: {paciente.Nombre}");
                Console.WriteLine(paciente.Historial.ToString() + "\n");
            }
        }

        #endregion

        #region Gestión de Médicos

        static void GestionarMedicos()
        {
            ConsoleHelper.ImprimirHeader("Gestión de Médicos");
            Console.WriteLine("1. Agregar Médico");
            Console.WriteLine("2. Listar Médicos");
            Console.WriteLine("0. Volver al Menú Principal");
            int op = ConsoleHelper.LeerEntero("Opción: ");

            switch (op)
            {
                case 1:
                    AgregarMedico();
                    break;
                case 2:
                    ListarMedicos();
                    break;
                case 0:
                    return;
                default:
                    ConsoleHelper.ImprimirError("Opción inválida.");
                    break;
            }
        }

        static void AgregarMedico()
        {
            ConsoleHelper.ImprimirHeader("Agregar Nuevo Médico");

            int nuevoId = medicos.Count + 1;
            string nombre = ConsoleHelper.LeerTextoNoVacio("Nombre completo: ");
            string especialidad = ConsoleHelper.LeerTextoNoVacio("Especialización: ");
            string contacto = ConsoleHelper.LeerTextoNoVacio("Datos de contacto (teléfono o correo): ");

            var nuevo = new Medico(nuevoId, nombre, especialidad, contacto);
            medicos.Add(nuevo);

            Console.WriteLine($"Médico agregado con ID: {nuevoId}\n");
        }

        static void ListarMedicos()
        {
            ConsoleHelper.ImprimirHeader("Listado de Médicos");
            if (medicos.Count == 0)
            {
                Console.WriteLine("No hay médicos registrados.\n");
                return;
            }

            foreach (var m in medicos)
            {
                Console.WriteLine($"ID: {m.Id} | Nombre: {m.Nombre} | Especialidad: {m.Especializacion} | Contacto: {m.DatosContacto}");
            }
            Console.WriteLine();
        }

        #endregion

        #region Gestión de Horarios

        static void GestionarHorarios()
        {
            ConsoleHelper.ImprimirHeader("Gestión de Horarios");
            Console.WriteLine("1. Agregar Horario a un Médico");
            Console.WriteLine("2. Listar Horarios por Médico");
            Console.WriteLine("0. Volver al Menú Principal");
            int op = ConsoleHelper.LeerEntero("Opción: ");

            switch (op)
            {
                case 1:
                    AgregarHorarioAMedico();
                    break;
                case 2:
                    ListarHorariosPorMedico();
                    break;
                case 0:
                    return;
                default:
                    ConsoleHelper.ImprimirError("Opción inválida.");
                    break;
            }
        }

        static void AgregarHorarioAMedico()
        {
            ConsoleHelper.ImprimirHeader("Agregar Horario");

            if (medicos.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay médicos registrados.");
                return;
            }

            int idMed = ConsoleHelper.LeerEntero("ID de Médico: ");
            var medico = medicos.Find(m => m.Id == idMed);
            if (medico == null)
            {
                ConsoleHelper.ImprimirError("Médico no encontrado.");
                return;
            }

            DateTime fecha = ConsoleHelper.LeerFecha("Fecha (dd/mm/yyyy): ");
            Console.Write("Hora inicio (HH:mm): ");
            Console.Write("Hora inicio (HH:mm): ");
            TimeSpan hi, hf;
            Console.Write("Hora inicio (HH:mm): ");
            while (!TimeSpan.TryParse(Console.ReadLine(), out hi))
            {
                ConsoleHelper.ImprimirError("Formato inválido. Intente de nuevo (ej. 08:30): ");
            }

            Console.Write("Hora fin (HH:mm): ");
            while (!TimeSpan.TryParse(Console.ReadLine(), out hf))
            {
                ConsoleHelper.ImprimirError("Formato inválido. Intente de nuevo (ej. 09:30): ");
            }
            string ubicacion = ConsoleHelper.LeerTextoNoVacio("Ubicación/Consultorio: ");

            int nuevoId = horarios.Count + 1;
            var h = new Horario(nuevoId, fecha, hi, hf, ubicacion);
            horarios.Add(h);

            medico.Horarios.Add(h);

            Console.WriteLine($"Horario agregado. ID Horario: {nuevoId}\n");
        }

        static void ListarHorariosPorMedico()
        {
            ConsoleHelper.ImprimirHeader("Horarios de un Médico");

            if (medicos.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay médicos registrados.");
                return;
            }

            int idMed = ConsoleHelper.LeerEntero("ID de Médico: ");
            var medico = medicos.Find(m => m.Id == idMed);
            if (medico == null)
            {
                ConsoleHelper.ImprimirError("Médico no encontrado.");
                return;
            }

            if (medico.Horarios.Count == 0)
            {
                Console.WriteLine("Este médico no tiene horarios definidos.\n");
            }
            else
            {
                Console.WriteLine($"Horarios del Dr(a). {medico.Nombre}:");
                foreach (var h in medico.Horarios)
                    Console.WriteLine($"  [{h.Id}] {h.ToString()}");
                Console.WriteLine();
            }
        }

        #endregion

        #region Gestión de Citas

        static void GestionarCitas()
        {
            ConsoleHelper.ImprimirHeader("Gestión de Citas");
            Console.WriteLine("1. Agendar Cita");
            Console.WriteLine("2. Cancelar Cita");
            Console.WriteLine("3. Completar Cita");
            Console.WriteLine("4. Listar Citas");
            Console.WriteLine("0. Volver al Menú Principal");
            int op = ConsoleHelper.LeerEntero("Opción: ");

            switch (op)
            {
                case 1:
                    AgendarCita();
                    break;
                case 2:
                    CancelarCita();
                    break;
                case 3:
                    CompletarCita();
                    break;
                case 4:
                    ListarCitas();
                    break;
                case 0:
                    return;
                default:
                    ConsoleHelper.ImprimirError("Opción inválida.");
                    break;
            }
        }

        static void AgendarCita()
        {
            ConsoleHelper.ImprimirHeader("Agendar Nueva Cita");

            if (pacientes.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay pacientes registrados.");
                return;
            }
            if (medicos.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay médicos registrados.");
                return;
            }

            int idPac = ConsoleHelper.LeerEntero("ID Paciente: ");
            var paciente = pacientes.Find(p => p.Id == idPac);
            if (paciente == null)
            {
                ConsoleHelper.ImprimirError("Paciente no encontrado.");
                return;
            }

            int idMed = ConsoleHelper.LeerEntero("ID Médico: ");
            var medico = medicos.Find(m => m.Id == idMed);
            if (medico == null)
            {
                ConsoleHelper.ImprimirError("Médico no encontrado.");
                return;
            }

            // Mostrar horarios disponibles del médico
            if (medico.Horarios.Count == 0)
            {
                ConsoleHelper.ImprimirError("Este médico no tiene horarios definidos.");
                return;
            }

            Console.WriteLine($"Horarios de Dr(a). {medico.Nombre}:");
            foreach (var h in medico.Horarios)
            {
                Console.WriteLine($" [{h.Id}] {h.ToString()}");
            }

            int idHor = ConsoleHelper.LeerEntero("Seleccione ID del Horario: ");
            var horario = medico.Horarios.Find(h => h.Id == idHor);
            if (horario == null)
            {
                ConsoleHelper.ImprimirError("Horario inválido.");
                return;
            }

            // Crear nueva cita
            int nuevaCitaId = citas.Count + 1;
            var nueva = new Cita(nuevaCitaId, paciente, medico, horario);
            citas.Add(nueva);

            Console.WriteLine($"Cita programada. ID: {nuevaCitaId} – Fecha/Hora: {nueva.FechaHora:g}\n");
        }

        static void CancelarCita()
        {
            ConsoleHelper.ImprimirHeader("Cancelar Cita Existente");

            if (citas.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay citas registradas.");
                return;
            }

            int idCita = ConsoleHelper.LeerEntero("ID de la cita a cancelar: ");
            var cita = citas.Find(c => c.Id == idCita);
            if (cita == null)
            {
                ConsoleHelper.ImprimirError("Cita no encontrada.");
                return;
            }

            if (cita.Cancelar())
                Console.WriteLine("Cita cancelada exitosamente.\n");
            else
                ConsoleHelper.ImprimirError("No se pudo cancelar (ya estaba completada o cancelada).\n");
        }

        static void CompletarCita()
        {
            ConsoleHelper.ImprimirHeader("Completar Cita (Doctor la atiende)");

            if (citas.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay citas registradas.");
                return;
            }

            int idCita = ConsoleHelper.LeerEntero("ID de la cita a completar: ");
            var cita = citas.Find(c => c.Id == idCita);
            if (cita == null)
            {
                ConsoleHelper.ImprimirError("Cita no encontrada.");
                return;
            }

            cita.Completar();
            Console.WriteLine("Cita marcada como COMPLETADA.\n");
        }

        static void ListarCitas()
        {
            ConsoleHelper.ImprimirHeader("Listado de Todas las Citas");

            if (citas.Count == 0)
            {
                Console.WriteLine("Aún no hay citas registradas.\n");
                return;
            }

            foreach (var c in citas)
            {
                Console.WriteLine(c.ToString());
            }
            Console.WriteLine();
        }

        #endregion

        #region Gestión de Pagos

        static void GestionarPagos()
        {
            ConsoleHelper.ImprimirHeader("Gestión de Pagos");
            Console.WriteLine("1. Realizar Pago de una Cita");
            Console.WriteLine("2. Ver Pagos Realizados");
            Console.WriteLine("0. Volver al Menú Principal");
            int op = ConsoleHelper.LeerEntero("Opción: ");

            switch (op)
            {
                case 1:
                    RealizarPago();
                    break;
                case 2:
                    ListarPagos();
                    break;
                case 0:
                    return;
                default:
                    ConsoleHelper.ImprimirError("Opción inválida.");
                    break;
            }
        }

        static void RealizarPago()
        {
            ConsoleHelper.ImprimirHeader("Realizar Pago para una Cita");

            // Verificar citas completadas sin pago
            var citasSinPago = citas.FindAll(c => c.Estado == EstadoCita.Completada && c.PagoRef == null);
            if (citasSinPago.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay citas completadas pendientes de pago.\n");
                return;
            }

            Console.WriteLine("Citas COMPLETADAS sin pago:");
            foreach (var c in citasSinPago)
            {
                Console.WriteLine($" ID: {c.Id} – Paciente: {c.PacienteRef.Nombre} – Fecha/Hora: {c.FechaHora:g}");
            }

            int idCita = ConsoleHelper.LeerEntero("Seleccione ID de la cita a pagar: ");
            var cita = citasSinPago.Find(c => c.Id == idCita);
            if (cita == null)
            {
                ConsoleHelper.ImprimirError("Cita inválida o ya pagada.\n");
                return;
            }

            double monto;
            Console.Write("Ingrese monto a cobrar: ");
            while (!double.TryParse(Console.ReadLine(), out monto))
            {
                ConsoleHelper.ImprimirError("Monto inválido. Intente de nuevo:");
                Console.Write("Ingrese monto a cobrar: ");
            }

            DateTime fechaPago = DateTime.Now;
            int nuevoPagoId = pagos.Count + 1;
            var pago = new Pago(nuevoPagoId, monto, fechaPago);

            // Procesa (aquí siempre es true)
            if (pago.ProcesarPago())
            {
                pagos.Add(pago);
                cita.PagoRef = pago;
                cita.IdPago = pago.Id;
                Console.WriteLine($"Pago registrado: ID Pago {pago.Id} – Monto: {pago.Monto:C} – Fecha: {pago.FechaPago:d}\n");
            }
            else
            {
                ConsoleHelper.ImprimirError("Falló el procesamiento del pago.\n");
            }
        }

        static void ListarPagos()
        {
            ConsoleHelper.ImprimirHeader("Listado de Pagos Realizados");

            if (pagos.Count == 0)
            {
                Console.WriteLine("Aún no hay pagos registrados.\n");
                return;
            }

            foreach (var p in pagos)
            {
                Console.WriteLine($"Pago {p.Id}: Monto {p.Monto:C}, Fecha {p.FechaPago:d}");
            }
            Console.WriteLine();
        }

        #endregion

        #region Reporte Financiero

        static void MostrarReporteFinanciero()
        {
            ConsoleHelper.ImprimirHeader("Generar Reporte Financiero");

            if (citas.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay citas registradas (no hay datos para reporte).\n");
                return;
            }
            if (pagos.Count == 0)
            {
                ConsoleHelper.ImprimirError("No hay pagos registrados (sin ingresos para reportar).\n");
                return;
            }

            DateTime fechaIni = ConsoleHelper.LeerFecha("Fecha inicio del reporte (dd/mm/yyyy): ");
            DateTime fechaFin = ConsoleHelper.LeerFecha("Fecha fin del reporte (dd/mm/yyyy): ");

            var reporte = new ReporteFinanciero(fechaIni, fechaFin);
            reporte.GenerarReporte(citas);

            ConsoleHelper.ImprimirHeader(reporte.ToString());
        }

        #endregion
    }
}