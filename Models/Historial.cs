using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caso_estudio1_Grupo1.Models
{
    public class Historial
    {
        [Key]
        public int IdJuego { get; set; }
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string Resultado { get; set; }
        [Required]
        public int Duracion { get; set; }
        [Required]
        public string Tablero { get; set; }
        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }

        //Constructor vacio
        public Historial()
        {
        }
        //Constructor con todas las propiedades
        public Historial(int idJuego, int idUsuario, string resultado, int duracion, string tablero, Usuario usuario)
        {
            IdJuego = idJuego;
            IdUsuario = idUsuario;
            Resultado = resultado;
            Duracion = duracion;
            Tablero = tablero;
            Usuario = usuario;
        }
        //Constructor con todas las propiedades menos el id
        public Historial(int idUsuario, string resultado, int duracion, string tablero, Usuario usuario)
        {
            IdUsuario = idUsuario;
            Resultado = resultado;
            Duracion = duracion;
            Tablero = tablero;
            Usuario = usuario;
        }
		public Historial(int idUsuario, string resultado, int duracion, string tablero)
		{
			IdUsuario = idUsuario;
			Resultado = resultado;
			Duracion = duracion;
			Tablero = tablero;
		}
	}
}
