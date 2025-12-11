using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Pqrs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get ; set; }
        [ForeignKey("IdUsuario")]
        public Guid IdUsuario  { get; set; }
        
        public string Tipo { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaEnvio { get; set; }

        public  bool Estado { get; set; }

        public string Respuesta { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }

    }
}
