namespace ReservaGol.Modelos
{
    public class Cancha
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }
        
        public string Ubicacion { get; set; }

        public  string Dimenciones { get; set; }

        public DateTime PrecioHora { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
