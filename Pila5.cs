using System;

namespace Proyecto5_Navegador
{
    public class Pila
    {
        private Nodo tope;

        public Pila()
        {
            tope = null;
        }

        private class Nodo
        {
            public string Pagina;
            public Nodo Siguiente;

            public Nodo(string pagina)
            {
                Pagina = pagina;
                Siguiente = null;
            }
        }

        public bool Vacia()
        {
            return tope == null;
        }

        public void Push(string pagina)
        {
            Nodo nuevo = new Nodo(pagina);
            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public string Pop()
        {
            if (Vacia())
            {
                return "";
            }
            string pagina = tope.Pagina;
            tope = tope.Siguiente;
            return pagina;
        }

        public string Peek()
        {
            if (Vacia())
            {
                return "";
            }
            return tope.Pagina;
        }

        // Método auxiliar para mostrar los elementos de la pila
        public void Mostrar()
        {
            Nodo actual = tope;
            int i = 1;
            while (actual != null)
            {
                Console.WriteLine($"{i}.- {actual.Pagina}");
                actual = actual.Siguiente;
                i++;
            }
        }
    }
}