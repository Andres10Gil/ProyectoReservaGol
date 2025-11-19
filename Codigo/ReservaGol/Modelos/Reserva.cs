using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Reserva
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   

        public int Id { get; set; }
        [ForeignKey("IdUsuario ")]
        public int IdUsusario { get; set; }
        [ForeignKey("IdCancha")]
        public int IdCancha { get; set; }

        public DateTime FechaReserva { get; set; }

        public DateTime HoraInicio { get; set; }

        public DateTime HoraFin {  get; set; }

        public bool Estado {  get; set; }

       
        
        
        public Usuario Usuario { get; set; }

        public Cancha Cancha { get; set; }

        








        
    }
}
