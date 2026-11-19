using System;
using System.Collections.Generic;
using System.Linq; // Necesario para usar FirstOrDefault() en la Pila

namespace proyecto2
{
    public class SimuladorLlamadas
    {
        private Stack<Llamada> pilaLlamadas = new Stack<Llamada>();

        public void RegistrarLlamada(string id, string contacto)
        {
            Llamada nuevaLlamada = new Llamada(id, contacto);
            pilaLlamadas.Push(nuevaLlamada);
            Console.WriteLine($"\n[Registrar] Llamada '{id}' de {contacto} agregada a la pila.");
        }

        public void AtenderLlamada()
        {
            if (pilaLlamadas.Count == 0)
            {
                Console.WriteLine("\nNo hay llamadas en la pila para atender.");
                return;
            }

            Llamada llamadaActual = pilaLlamadas.Peek();
            llamadaActual.Estado = "Atendida";
            Console.WriteLine($"\n[Atender] Atendiendo llamada actual: {llamadaActual}");
        }

        public void FinalizarLlamada()
        {
            if (pilaLlamadas.Count == 0)
            {
                Console.WriteLine("\nNo hay llamadas activas para finalizar.");
                return;
            }

            Llamada llamadaFinalizada = pilaLlamadas.Pop();
            Console.WriteLine($"\n[Finalizar] Llamada finalizada y removida de la pila: {llamadaFinalizada.IdLlamada} - {llamadaFinalizada.Contacto}");
        }

        public void MostrarLlamadasActivas()
        {
            Console.WriteLine("\n--- PILA DE LLAMADAS ACTIVAS (LIFO) ---");
            if (pilaLlamadas.Count == 0)
            {
                Console.WriteLine("La pila de llamadas está vacía.");
                return;
            }

            int i = 1;
            foreach (var llamada in pilaLlamadas)
            {
                Console.WriteLine($"{i}.- {llamada}");
                i++;
            }
        }

        public void RecuperarUltimaLlamada()
        {
            if (pilaLlamadas.Count == 0)
            {
                Console.WriteLine("\nNo hay llamadas en la pila.");
                return;
            }

            Llamada ultima = pilaLlamadas.Peek();
            Console.WriteLine($"\n[Recuperar última] La llamada en la cima de la pila es: {ultima}");
        }

        public void BuscarLlamada(string id)
        {
            // FirstOrDefault busca dentro de la pila de manera segura gracias a System.Linq
            Llamada encontrada = pilaLlamadas.FirstOrDefault(l => l.IdLlamada.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (encontrada != null)
            {
                Console.WriteLine($"\n[Buscar] Llamada encontrada en la pila: {encontrada}");
            }
            else
            {
                Console.WriteLine($"\n[Buscar] No se encontró ninguna llamada con el ID '{id}' en la pila.");
            }
        }

        public void EliminarLlamada(string id)
        {
            // Pasamos temporalmente a lista para remover el elemento y reconstruir la pila
            List<Llamada> listaTemp = new List<Llamada>(pilaLlamadas);
            int countAntes = listaTemp.Count;

            listaTemp.RemoveAll(l => l.IdLlamada.Equals(id, StringComparison.OrdinalIgnoreCase));

            if (listaTemp.Count < countAntes)
            {
                listaTemp.Reverse(); // Invertimos para mantener el orden LIFO original de la pila
                pilaLlamadas = new Stack<Llamada>(listaTemp);
                Console.WriteLine($"\n[Eliminar] Llamada con ID '{id}' eliminada de la pila.");
            }
            else
            {
                Console.WriteLine($"\n[Eliminar] No se encontró la llamada con ID '{id}'.");
            }
        }
    }
}