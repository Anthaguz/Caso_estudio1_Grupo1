using Microsoft.EntityFrameworkCore;

namespace Caso_estudio1_Grupo1.Models
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=Anthaguz-pc\\sqlexpress;Database=GatoImposibleGrupo1;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer("Server=DESKTOP-TKK1GA0;Database=GatoImposibleGrupo1;Trusted_Connection=True;TrustServerCertificate=True;"); //Cinseros
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Sesiones> Sesiones { get; set; }
        public DbSet<Historial> Historial { get; set; }

    }

    public static class CRUD 
    {
        //Operaciones CRUD para las clases Usuario, Sesiones y Historial, donde se realizan las operaciones de crear, leer, actualizar y eliminar para todas las clases
        public static void CreateUsuario(Usuario usuario)
        {
            using (var db = new DatabaseContext())
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }

        public static Usuario GetUsuarioById(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Usuarios.Find(id);
            }
        }

        public static Usuario GetUsuarioByUsername(string username)
        {
            using (var db = new DatabaseContext())
            {
                return db.Usuarios.Where(u => u.Username == username).FirstOrDefault();
            }
        }

        public static List<Usuario> ReadUsuarios()
        {
            using (var db = new DatabaseContext())
            {
                return db.Usuarios.ToList();
            }
        }

        public static void UpdateUsuario(Usuario usuario)
        {
            using (var db = new DatabaseContext())
            {
                db.Usuarios.Update(usuario);
                db.SaveChanges();
            }
        }

        public static void DeleteUsuario(Usuario usuario)
        {
            using (var db = new DatabaseContext())
            {
                db.Usuarios.Remove(usuario);
                db.SaveChanges();
            }
        }

        public static void CreateSesiones(Sesiones sesiones)
        {
            using (var db = new DatabaseContext())
            {
                db.Sesiones.Add(sesiones);
                db.SaveChanges();
            }
        }

        public static Sesiones ReadSesion(String id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Sesiones.Find(id);
            }
        }

        public static void UpdateSesiones(Sesiones sesiones)
        {
            using (var db = new DatabaseContext())
            {
                db.Sesiones.Update(sesiones);
                db.SaveChanges();
            }
        }

        public static void DeleteSesion(Sesiones sesion)
        {
            using (var db = new DatabaseContext())
            {
                db.Sesiones.Remove(sesion);
                db.SaveChanges();
            }
        }

        public static void CreateHistorial(Historial historial)
        {
            using (var db = new DatabaseContext())
            {
                db.Historial.Add(historial);
                db.SaveChanges();
            }
        }

        public static Historial ReadHistorial(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Historial.Find(id);
            }
        }

        public static void UpdateHistorial(Historial historial)
        {
            using (var db = new DatabaseContext())
            {
                db.Historial.Update(historial);
                db.SaveChanges();
            }
        }

        public static void DeleteHistorial(Historial historial)
        {
            using (var db = new DatabaseContext())
            {
                db.Historial.Remove(historial);
                db.SaveChanges();
            }
        }

        public static Sesiones FindSesionByUserId(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Sesiones.Where(s => s.IdUsuario == id).FirstOrDefault();
            }
        }

        public static List<Sesiones> FindSesionesByUserId(int id)
        {
            using (var db = new DatabaseContext())
            {
                return db.Sesiones.Where(s => s.IdUsuario == id).ToList();
            }
        }


        
    }
}
