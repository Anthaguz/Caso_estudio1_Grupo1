using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caso_estudio1_Grupo1.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Foto { get; set; }
        [Required]
        public string Contrasena { get; set; }
        [NotMapped]
        public IFormFile Archivo { get; set; }

        //Constructor vacio
        public Usuario()
        {
        }
        //Constructor con todas las propiedades
        public Usuario(int idUsuario, string nombre, string username, string foto, string contrasena)
        {
            IdUsuario = idUsuario;
            Nombre = nombre;
            Username = username;
            Foto = foto;
            Contrasena = contrasena;
        }
        //Constructor con todas las propiedades menos el id
        public Usuario(string nombre, string username, string foto, string contrasena)
        {
            Nombre = nombre;
            Username = username;
            Foto = foto;
            Contrasena = contrasena;
        }
        
        //Constructor con nombre , username y contraseña
        public Usuario(string nombre, string username, string contrasena)
        {
            Nombre = nombre;
            Username = username;
            Contrasena = contrasena;
        }

        public static String encriptar(String contraseña)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(contraseña);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
