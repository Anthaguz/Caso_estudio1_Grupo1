using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caso_estudio1_Grupo1.Models
{
    public class Sesiones
    {
        [Key]
        public string IdSesion { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
        //Constructor vacio
        public Sesiones()
        {
        }
        //Constructor con todas las propiedades
        public Sesiones(string idSesion, int idUsuario, Usuario usuario)
        {
            IdSesion = idSesion;
            IdUsuario = idUsuario;
            Usuario = usuario;
        }
        //Constructor con todas las propiedades menos el id
        public Sesiones(int idUsuario, Usuario usuario)
        {
            IdUsuario = idUsuario;
            Usuario = usuario;
        }
        //Constructor con todas las propiedades menos el usuario
        public Sesiones(string idSesion, int idUsuario)
        {
            IdSesion = idSesion;
            IdUsuario = idUsuario;
        }
    }
}
