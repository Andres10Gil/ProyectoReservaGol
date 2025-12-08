using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Pagos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("IdFacturacion")]
        public Guid IdFacturacion { get; set; }

        public DateTime FechaPago {  get; set; }

        public decimal Monto { get; set; }

        public string Metodo { get; set; }

        public string Estado { get; set; }

        public string Referencia { get; set; }

        public Facturacion Facturacion { get; set; }

        


    }
}
