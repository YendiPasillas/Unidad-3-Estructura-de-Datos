namespace proyecto2
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public int NumeroPersonas { get; set; }

        public Cliente(string nombre, int numeroPersonas)
        {
            Nombre = nombre;
            NumeroPersonas = numeroPersonas;
        }

        public override string ToString()
        {
            return $"{Nombre} .- {NumeroPersonas} personas";
        }
    }
}