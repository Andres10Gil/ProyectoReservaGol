using System.ComponentModel.DataAnnotations;

namespace ReservaGol.Modelos
{
    public class Login
    {
        [Required]// esto no indica que es obligarotio 
        public string NombreUsuario { get; set; }  = string.Empty!;// no permitas datos vacios " =string.Empty!;"


        [Required]
        public string Contraseña { get; set; } = string.Empty!;



    }
}
