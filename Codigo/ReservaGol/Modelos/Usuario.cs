using ReservaGol.Modelos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("IdRoles")] // Clave foranea
        public int IdRoles { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public int Telefono { get; set; }

        public string Contraseña { get; set; }

        public DateTime FechaRegistro { get; set; }

        // relacion invera
        public Roles Roles { get; set; }

        public ICollection<Reserva> Reservas { get; set; }
    }
}
