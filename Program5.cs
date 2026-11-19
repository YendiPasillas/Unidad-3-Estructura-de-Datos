using System;

namespace Proyecto5_Navegador
{
    internal class Program
    {
        static Pila atras = new Pila();
        static Pila adelante = new Pila();
        static string actual = "Inicio";

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("=== NAVEGADOR WEB ===");
                Console.WriteLine($"Página actual: {actual}");
                Console.WriteLine("--------------------------------");
                Console.WriteLine("1. Visitar página");
                Console.WriteLine("2. Atrás");
                Console.WriteLine("3. Adelante");
                Console.WriteLine("4. Mostrar historial");
                Console.WriteLine("5. Mostrar última página visitada");
                Console.WriteLine("6. Salir");
                Console.Write("\nOpción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese la URL o nombre de la página: ");
                            string nuevaPagina = Console.ReadLine();
                            if (!string.IsNullOrWhiteSpace(nuevaPagina))
                            {
                                // Guardamos la página actual en la pila de atrás antes de avanzar
                                atras.Push(actual);
                                actual = nuevaPagina;
                                // Al visitar una nueva página, se limpia la pila de adelante
                                adelante = new Pila();
                                Console.WriteLine($"\nNavegando a {actual}...");
                            }
                            break;

                        case 2:
                            if (atras.Vacia())
                            {
                                Console.WriteLine("\nNo hay páginas anteriores en el historial.");
                            }
                            else
                            {
                                // Pasamos la actual a adelante, y sacamos la última de atrás
                                adelante.Push(actual);
                                actual = atras.Pop();
                                Console.WriteLine($"\nRegresando a: {actual}");
                            }
                            break;

                        case 3:
                            if (adelante.Vacia())
                            {
                                Console.WriteLine("\nNo hay páginas adelante.");
                            }
                            else
                            {
                                // Pasamos la actual a atrás, y sacamos la de adelante
                                atras.Push(actual);
                                actual = adelante.Pop();
                                Console.WriteLine($"\nAvanzando a: {actual}");
                            }
                            break;

                        case 4:
                            Console.WriteLine("\n--- HISTORIAL DE PÁGINAS ANTERIORES ---");
                            if (atras.Vacia())
                            {
                                Console.WriteLine("El historial de atrás está vacío.");
                            }
                            else
                            {
                                atras.Mostrar();
                            }
                            break;

                        case 5:
                            if (atras.Vacia())
                            {
                                Console.WriteLine("\nNo hay páginas anteriores registradas.");
                            }
                            else
                            {
                                Console.WriteLine($"\nÚltima página visitada (Tope de atrás): {atras.Peek()}");
                            }
                            break;

                        case 6:
                            Console.WriteLine("\nSaliendo del navegador...");
                            break;

                        default:
                            Console.WriteLine("\nOpción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nPor favor ingrese un número válido.");
                }

                if (opcion != 6)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 6);
        }
    }
}