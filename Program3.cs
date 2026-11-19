using System;

namespace proyecto2
{
    class Program
    {
        static void Main(string[] args)
        {
            SimuladorLlamadas simulador = new SimuladorLlamadas();
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("    SIMULADOR DE LLAMADAS TELEFÓNICAS   ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar llamada");
                Console.WriteLine("2. Atender llamada");
                Console.WriteLine("3. Finalizar llamada (Pop)");
                Console.WriteLine("4. Mostrar llamadas activas (Pila)");
                Console.WriteLine("5. Recuperar última llamada (Peek)");
                Console.WriteLine("6. Buscar llamada");
                Console.WriteLine("7. Eliminar llamada");
                Console.WriteLine("8. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese el ID de la llamada (ej. 1, 2, Main): ");
                            string id = Console.ReadLine();
                            Console.Write("Ingrese el nombre del contacto o método: ");
                            string contacto = Console.ReadLine();
                            simulador.RegistrarLlamada(id, contacto);
                            break;
                        case 2:
                            simulador.AtenderLlamada();
                            break;
                        case 3:
                            simulador.FinalizarLlamada();
                            break;
                        case 4:
                            simulador.MostrarLlamadasActivas();
                            break;
                        case 5:
                            simulador.RecuperarUltimaLlamada();
                            break;
                        case 6:
                            Console.Write("\nIngrese el ID de la llamada a buscar: ");
                            string idBusqueda = Console.ReadLine();
                            simulador.BuscarLlamada(idBusqueda);
                            break;
                        case 7:
                            Console.Write("\nIngrese el ID de la llamada a eliminar: ");
                            string idEliminar = Console.ReadLine();
                            simulador.EliminarLlamada(idEliminar);
                            break;
                        case 8:
                            Console.WriteLine("\nSaliendo del simulador...");
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

                if (opcion != 8)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 8);
        }
    }
}