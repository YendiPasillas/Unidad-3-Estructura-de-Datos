

namespace proyecto2
{
        public class Mesa
        {
            public int NumeroMesa { get; set; }
            public int Capacidad { get; set; }
            public bool Ocupada { get; set; }
            public Cliente ClienteActual { get; set; }

            public Mesa(int numeroMesa, int capacidad)
            {
                NumeroMesa = numeroMesa;
                Capacidad = capacidad;
                Ocupada = false;
                ClienteActual = null;
            }

            public override string ToString()
            {
                string estado = Ocupada 
                    ? $"Ocupada por {ClienteActual.Nombre} ({ClienteActual.NumeroPersonas} pers.)"
                    : "Disponible";
                return $"Mesa {NumeroMesa} (Capacidad: {Capacidad}) - {estado}";
            }
        }
    
}