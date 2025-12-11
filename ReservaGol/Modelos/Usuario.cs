using ReservaGol.Modelos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("IdRoles")] // Clave foranea
        public Guid IdRoles { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public int Telefono { get; set; }

        public string Contraseña { get; set; }

        public DateTime FechaRegistro { get; set; }

        // relacion invera
        public Roles Roles { get; set; }


        // se usa para el mapeo 
        public ICollection<Reserva> Reservas { get; set; }

        public ICollection<Facturacion> Facturacion { get; set; }

        public ICollection<Empresas> Empresas { get; set; }
    }
}
