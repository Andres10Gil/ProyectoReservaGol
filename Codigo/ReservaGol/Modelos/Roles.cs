using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservaGol.Modelos
{
    public class Roles
    {
        [Key]// Clave primaria
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NombreRol { get; set; }
        public string Descripcion { get; set; }
        public int NivelAcceso { get; set; }
        public bool Activo { get; set; }
        public DateTime CreandoEm { get; set; }
        //           TipoDeDato  N.Atributo  (leer ; enviar)
        // relacion inversa

        public ICollection<Usuario> Usuarios { get; set; }
    }
}
