using proyecto4;

namespace proyecto4
{
    public class Pila
    {
        private Nodo tope;

        public Pila()
        {
            tope = null;
        }

        public bool Vacia()
        {
            return tope == null;
        }

        public void Apilar(char dato)
        {
            Nodo nuevo = new Nodo(dato);
            nuevo.Siguiente = tope;
            tope = nuevo;
        }

        public char Desapilar()
        {
            if (Vacia())
            {
                return '\0';
            }
            char dato = tope.Dato;
            tope = tope.Siguiente;
            return dato;
        }

        public char ObtenerTope()
        {
            if (Vacia()) return '\0';
            return tope.Dato;
        }
    }
}