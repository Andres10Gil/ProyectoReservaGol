using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Empresas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]// Llave primaria autogenerada

        public Guid IdEmpresa { get; set; }

        [ForeignKey("IdUsuarios")] // Llave foranea a la tabla Usuarios

        public Guid IdUsuarios { get; set; }

        public string NombreEmpresa { get; set; }

        public int Nit { get; set; }

        public string Direccion { get; set; }

        public string Ciudad { get; set; }

        public string Telefono { get; set; }

        public string CorreoElectronico { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool Activo { get; set; }


        public Usuario  usuario { get; set; }
    }
}
