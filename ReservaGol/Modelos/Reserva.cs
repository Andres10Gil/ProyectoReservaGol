using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Reserva
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   

        public Guid Id { get; set; }
        [ForeignKey("IdUsuario ")]
        public Guid IdUsusario { get; set; }
        [ForeignKey("IdCancha")]
        public Guid IdCancha { get; set; }

        public DateTime FechaReserva { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin {  get; set; }

        public bool Estado {  get; set; }

       
        
        
        public Usuario Usuario { get; set; }

        public Cancha Cancha { get; set; }
        public ICollection<Facturacion> Facturacion { get; set; }











    }
}
