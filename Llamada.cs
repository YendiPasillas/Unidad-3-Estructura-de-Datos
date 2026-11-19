namespace proyecto2
{
    public class Llamada
    {
        public string IdLlamada { get; set; }
        public string Contacto { get; set; }
        public string Estado { get; set; } // "Activa", "Atendida", "Finalizada"

        public Llamada(string idLlamada, string contacto)
        {
            IdLlamada = idLlamada;
            Contacto = contacto;
            Estado = "Activa";
        }

        public override string ToString()
        {
            return $"Llamada ID: {IdLlamada} - Contacto: {Contacto} [{Estado}]";
        }
    }
}