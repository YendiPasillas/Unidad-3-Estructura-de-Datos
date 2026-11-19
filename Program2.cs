using System;

namespace proyecto2
{
    class program
    {
        static void Main(string[] args)
        {
            SistemaRestaurante sistema = new SistemaRestaurante();
            int opcion = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("    SISTEMA DE GESTIÓN DE RESTAURANTE   ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Registrar cliente y número de personas");
                Console.WriteLine("2. Mostrar lista de espera");
                Console.WriteLine("3. Asignar mesa (Atender siguiente)");
                Console.WriteLine("4. Mostrar mesas disponibles");
                Console.WriteLine("5. Mostrar mesas ocupadas");
                Console.WriteLine("6. Buscar cliente");
                Console.WriteLine("7. Cancelar reservación / Eliminar cliente");
                Console.WriteLine("8. Liberar mesa");
                Console.WriteLine("9. Salir");
                Console.Write("\nSeleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            Console.Write("\nIngrese el nombre del cliente o familia: ");
                            string nombre = Console.ReadLine();
                            Console.Write("Ingrese el número de personas: ");
                            if (int.TryParse(Console.ReadLine(), out int numPersonas))
                            {
                                sistema.AgregarCliente(nombre, numPersonas);
                            }
                            else
                            {
                                Console.WriteLine("Número de personas inválido.");
                            }
                            break;
                        case 2:
                            sistema.MostrarListaEspera();
                            break;
                        case 3:
                            sistema.AsignarMesa();
                            break;
                        case 4:
                            sistema.MostrarMesasDisponibles();
                            break;
                        case 5:
                            sistema.MostrarMesasOcupadas();
                            break;
                        case 6:
                            Console.Write("\nIngrese el nombre del cliente a buscar: ");
                            string nombreBusqueda = Console.ReadLine();
                            sistema.BuscarCliente(nombreBusqueda);
                            break;
                        case 7:
                            Console.Write("\nIngrese el nombre del cliente cuya reservación desea cancelar: ");
                            string nombreCancelar = Console.ReadLine();
                            sistema.CancelarReservacion(nombreCancelar);
                            break;
                        case 8:
                            Console.Write("\nIngrese el número de la mesa a liberar: ");
                            if (int.TryParse(Console.ReadLine(), out int numMesa))
                            {
                                sistema.LiberarMesa(numMesa);
                            }
                            else
                            {
                                Console.WriteLine("Número de mesa inválido.");
                            }
                            break;
                        case 9:
                            Console.WriteLine("\nSaliendo del sistema...");
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

                if (opcion != 9)
                {
                    Console.WriteLine("\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 9);
        }
    }
}