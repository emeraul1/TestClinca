using System;

namespace ClinicaMedicaApp.Helpers
{
    /// <summary>
    /// Métodos estáticos de utilidad para imprimir encabezados, errores, 
    /// y leer datos validados desde consola.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Imprime un encabezado en color cian.
        /// </summary>
        public static void ImprimirHeader(string texto)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n=== {texto} ===\n");
            Console.ResetColor();
        }

        /// <summary>
        /// Imprime un mensaje de error en color rojo.
        /// </summary>
        public static void ImprimirError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensaje);
            Console.ResetColor();
        }

        /// <summary>
        /// Lee un número entero de forma validada.
        /// </summary>
        public static int LeerEntero(string prompt)
        {
            int valor;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                ImprimirError("Entrada inválida. Ingrese un número entero válido:");
                Console.Write(prompt);
            }
            return valor;
        }

        /// <summary>
        /// Lee una fecha de forma validada (formato dd/mm/yyyy).
        /// </summary>
        public static DateTime LeerFecha(string prompt)
        {
            DateTime fecha;
            Console.Write(prompt);
            while (!DateTime.TryParse(Console.ReadLine(), out fecha))
            {
                ImprimirError("Fecha inválida. Use formato dd/mm/yyyy:");
                Console.Write(prompt);
            }
            return fecha;
        }

        /// <summary>
        /// Lee un nombre o texto no vacío.
        /// </summary>
       public static string LeerTextoNoVacio(string prompt)
        {
             string? texto;
            do
            {
            Console.Write(prompt);
            texto = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(texto))
            ImprimirError("El valor no puede estar vacío. Intente de nuevo.");
            }
            while (string.IsNullOrWhiteSpace(texto));
    
            return texto!;
        }
    }
}
