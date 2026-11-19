namespace Proyecto_1
{
    public class Paciente
    {
        public int Expediente { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public int Prioridad { get; set; }

        public Paciente(int exp, string nom, int ed, int pri)
        {
            Expediente = exp;
            Nombre = nom;
            Edad = ed;
            Prioridad = pri;
        }

        public override string ToString()
        {
            return $"Expediente: {Expediente} | Nombre: {Nombre} | Edad: {Edad} | Prioridad: {Prioridad}";
        }
    }
}