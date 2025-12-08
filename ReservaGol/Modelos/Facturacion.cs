using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Facturacion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// se usa para asiganar valores incrementales en la llave primaria 
        public Guid id { get; set; }
        [ForeignKey("IdReserva")]
        public Guid IdReserva { get; set; }
        [ForeignKey("IdUsuarios")]
        public Guid IdUsuarios { get; set; }

        public DateTime FechaFactura { get; set; }

        public string MetodoPago { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Impuestos { get; set; }

        public decimal Total { get; set; }

        public string EstadoPago { get; set; }

        public string ReferenciaTransanccion { get; set; }

        public Reserva Reserva { get; set; }    

        public Usuario Usuario {  get; set; }

        



    }
}
