

namespace proyecto2
{
    public class SistemaRestaurante
    {
        private Queue<Cliente> listaEspera = new Queue<Cliente>();
        private List<Mesa> mesas = new List<Mesa>();

        public SistemaRestaurante()
        {
            // Inicializamos algunas mesas por defecto en el restaurante
            mesas.Add(new Mesa(1, 2));
            mesas.Add(new Mesa(2, 4));
            mesas.Add(new Mesa(3, 4));
            mesas.Add(new Mesa(4, 6));
            mesas.Add(new Mesa(5, 8));
        }

        public void AgregarCliente(string nombre, int numPersonas)
        {
            Cliente nuevoCliente = new Cliente(nombre, numPersonas);
            listaEspera.Enqueue(nuevoCliente);
            Console.WriteLine($"\nCliente '{nombre}' agregado exitosamente a la lista de espera.");
        }

        public void MostrarListaEspera()
        {
            Console.WriteLine("\n--- LISTA DE ESPERA ---");
            if (listaEspera.Count == 0)
            {
                Console.WriteLine("La lista de espera está vacía.");
                return;
            }

            int i = 1;
            foreach (var cliente in listaEspera)
            {
                Console.WriteLine($"{i}.- {cliente}");
                i++;
            }
        }

        public void AsignarMesa()
        {
            if (listaEspera.Count == 0)
            {
                Console.WriteLine("\nNo hay clientes en la lista de espera para asignar mesa.");
                return;
            }

            // Buscar la primera mesa disponible
            Mesa mesaDisponible = mesas.Find(m => !m.Ocupada);
            if (mesaDisponible == null)
            {
                Console.WriteLine("\nNo hay mesas disponibles en este momento.");
                return;
            }

            Cliente clienteAtendido = listaEspera.Dequeue();
            mesaDisponible.Ocupada = true;
            mesaDisponible.ClienteActual = clienteAtendido;

            Console.WriteLine($"\nAtendiendo: {clienteAtendido} asignado a Mesa {mesaDisponible.NumeroMesa}");
        }

        public void MostrarMesasDisponibles()
        {
            Console.WriteLine("\n--- MESAS DISPONIBLES ---");
            var disponibles = mesas.FindAll(m => !m.Ocupada);
            if (disponibles.Count == 0)
            {
                Console.WriteLine("No hay mesas disponibles.");
                return;
            }

            foreach (var mesa in disponibles)
            {
                Console.WriteLine($"Mesa {mesa.NumeroMesa} disponible (Capacidad: {mesa.Capacidad})");
            }
        }

        public void MostrarMesasOcupadas()
        {
            Console.WriteLine("\n--- MESAS OCUPADAS ---");
            var ocupadas = mesas.FindAll(m => m.Ocupada);
            if (ocupadas.Count == 0)
            {
                Console.WriteLine("No hay mesas ocupadas.");
                return;
            }

            foreach (var mesa in ocupadas)
            {
                Console.WriteLine($"Mesa {mesa.NumeroMesa} ocupada por {mesa.ClienteActual.Nombre} ({mesa.ClienteActual.NumeroPersonas} personas)");
            }
        }

        public void BuscarCliente(string nombre)
        {
            // Buscar en lista de espera
            var tempLista = new List<Cliente>(listaEspera);
            var clienteEnEspera = tempLista.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (clienteEnEspera != null)
            {
                Console.WriteLine($"\nCliente encontrado en la Lista de Espera: {clienteEnEspera}");
                return;
            }

            // Buscar en mesas ocupadas
            var mesaConCliente = mesas.Find(m => m.Ocupada && m.ClienteActual.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (mesaConCliente != null)
            {
                Console.WriteLine($"\nCliente encontrado sentado en la Mesa {mesaConCliente.NumeroMesa}: {mesaConCliente.ClienteActual}");
                return;
            }

            Console.WriteLine($"\nCliente '{nombre}' no encontrado ni en espera ni en mesas.");
        }

        public void CancelarReservacion(string nombre)
        {
            // Intentar remover de la lista de espera
            var tempLista = new List<Cliente>(listaEspera);
            var clienteAEliminar = tempLista.Find(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (clienteAEliminar != null)
            {
                tempLista.Remove(clienteAEliminar);
                listaEspera = new Queue<Cliente>(tempLista);
                Console.WriteLine($"\nReservación de '{nombre}' cancelada (removido de la lista de espera).");
                return;
            }

            // Intentar liberar si ya estaba sentado en una mesa
            var mesaCliente = mesas.Find(m => m.Ocupada && m.ClienteActual.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (mesaCliente != null)
            {
                mesaCliente.Ocupada = false;
                mesaCliente.ClienteActual = null;
                Console.WriteLine($"\nReservación de '{nombre}' cancelada. Mesa {mesaCliente.NumeroMesa} disponible.");
                return;
            }

            Console.WriteLine($"\nNo se encontró ninguna reservación o registro activo para '{nombre}'.");
        }

        public void LiberarMesa(int numeroMesa)
        {
            var mesa = mesas.Find(m => m.NumeroMesa == numeroMesa);
            if (mesa != null && mesa.Ocupada)
            {
                mesa.Ocupada = false;
                mesa.ClienteActual = null;
                Console.WriteLine($"\nMesa {numeroMesa} disponible");
            }
            else
            {
                Console.WriteLine($"\nLa mesa {numeroMesa} ya se encuentra libre o no existe.");
            }
        }
    }
}