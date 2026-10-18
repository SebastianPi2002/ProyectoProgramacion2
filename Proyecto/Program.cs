using System;
using System.Collections.Generic;
using Dominio;

namespace Proyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Sistema sistema = new Sistema();

            // Se realiza una sola vez, antes de comenzar el menú.
            sistema.PrecargarDatos();

            string? opcion = "";

            while (opcion != "0")
            {
                Console.WriteLine();
                Console.WriteLine("MENÚ");
                Console.WriteLine("1 - Listar casos con sus evidencias");
                Console.WriteLine("2 - Buscar casos por email del investigador");
                Console.WriteLine("3 - Hacer alta de un sospechoso");
                Console.WriteLine("4 - Obtener sospechosos con antecedentes");
                Console.WriteLine("0 - Salir");
                Console.Write("Ingrese una opción: ");

                opcion = Console.ReadLine();

                Console.WriteLine();

                switch (opcion)
                {
                    case "1":
                        ListarCasosConEvidencias(sistema);
                        break;

                    case "2":
                        ListarCasosPorInvestigador(sistema);
                        break;

                    case "3":
                        AltaSospechoso(sistema);
                        break;
                    case "4":
                        ObtenerSospechososConAntecedentes(sistema);
                        break;
                    case "0":
                        Console.WriteLine("Programa finalizado.");
                        break;

                    default:
                        Console.WriteLine("La opción ingresada no es válida.");
                        break;
                }
            }
        }

        static void ObtenerSospechososConAntecedentes(Sistema sistema)
        {
            List<Sospechoso> sospechosos = sistema.ObtenerSospechososConAntecedentes();

            foreach (Sospechoso sospechoso in sospechosos)
            {
                Console.WriteLine(sospechoso);
            }
        }

        static void AltaSospechoso(Sistema sistema)
        {
            try
            {
                Console.WriteLine("Ingrese el nombre:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Ingrese la cédula:");
                string cedula = Console.ReadLine();

                Console.WriteLine("Ingrese la fecha de nacimiento (dd/MM/yyyy):");
                DateTime fechaNacimiento = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("¿Tiene antecedentes? (S/N):");
                string respuesta = Console.ReadLine();

                bool antecedentes = respuesta.ToUpper() == "S";

                Sospechoso sospechoso = new Sospechoso(
                    nombre,
                    cedula,
                    antecedentes,
                    fechaNacimiento
                );

                sistema.AltaSospechoso(sospechoso);

                Console.WriteLine("Sospechoso ingresado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Punto a: mostrar todos los casos y sus evidencias.
        static void ListarCasosConEvidencias(Sistema sistema)
        {
            List<Caso> casos = sistema.ObtenerCasos();

            if (casos.Count == 0)
            {
                Console.WriteLine("No hay casos registrados.");
            }
            else
            {
                foreach (Caso caso in casos)
                {
                    Console.WriteLine(
                        $"Id: {caso.Id} - Nombre: {caso.Nombre}"
                    );

                    // Cada evidencia se muestra en un renglón aparte.
                    foreach (Evidencia evidencia in caso.Evidencias)
                    {
                        Console.WriteLine(
                            $"    Id: {evidencia.Id} - " +
                            $"Descripción: {evidencia.Descripcion}"
                        );
                    }

                    Console.WriteLine();
                }
            }
        }

        // Punto b: mostrar los casos de un investigador por su email.
        static void ListarCasosPorInvestigador(Sistema sistema)
        {
            Console.Write("Ingrese el email del investigador: ");
            string? email = Console.ReadLine();

            if (email == null || email.Trim() == "")
            {
                Console.WriteLine("Debe ingresar un email.");
            }
            else
            {
                // Quita espacios al principio y al final.
                email = email.Trim();

                List<Caso> casos = sistema.ObtenerCasosPorEmail(email);

                if (casos.Count == 0)
                {
                    Console.WriteLine(
                        "No se encontraron casos para ese email."
                    );
                }
                else
                {
                    foreach (Caso caso in casos)
                    {
                        Console.WriteLine(
                            $"Id: {caso.Id} - " +
                            $"Nombre: {caso.Nombre} - " +
                            $"Investigador: {caso.Investigador.Nombre}"
                        );
                    }
                }
            }
        }
    }
}