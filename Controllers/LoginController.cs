using Caso_estudio1_Grupo1.Models;
using Caso_estudio1_Grupo1.Statics;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace Caso_estudio1_Grupo1.Controllers
{
    public class LoginController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public LoginController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAttempt()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];
            var Usuario = CRUD.GetUsuarioByUsername(username);
            password = Usuario.encriptar(password);
            if (Usuario == null)
            {
                ViewData["Error"] = "El usuario no existe";
                ViewData["Username"] = username;
                ViewData["Password"] = password;
                return View("Login");
            }
            else if (Usuario.Contrasena != password)
            {
                ViewData["Error"] = "La contraseña es incorrecta";
                ViewData["Username"] = username;
                ViewData["Password"] = password;
                return View("Login");
            }
            else
            {
                //hacer el login
                CookieOptions cookieOptions = LoginService.GetCookieOptions();
                string token = LoginService.CrearSesion(Usuario.IdUsuario);
                HttpContext.Response.Cookies.Append("token", token, cookieOptions);
                var sesion = CRUD.ReadSesion(token);
                var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
                ViewData["username"] = usuario.Username;
                ViewData["foto"] = usuario.Foto;
                return View("~/Views/Home/Index.cshtml");
            }
        }
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAttempt(Usuario usuario)
        {
            var username = Request.Form["username"];
            var nombre = Request.Form["nombre"];
            var password = Request.Form["password"];
            var confirm_password = Request.Form["confirm_password"];
            //if (ModelState.IsValid)
            //{
            //    if (usuario.Archivo != null && usuario.Archivo.Length > 0)
            //    {
            //        using (var memoryStream = new MemoryStream())
            //        {
            //            await usuario.Archivo.CopyToAsync(memoryStream);
            //            usuario.Foto = Convert.ToBase64String(memoryStream.ToArray());
            //            var test = "test";
            //        }
            //    }
            //}
            if (password != confirm_password)
            {
                ViewData["Error"] = "Las contraseñas no coinciden";
                ViewData["Username"] = username;
                ViewData["Nombre"] = nombre;
                ViewData["Password"] = password;
                return View("Registro");
            }
            else if (username == "" || nombre == "" || password == "" || confirm_password == "")
            {
                ViewData["Error"] = "Todos los campos son requeridos";
                return View("Registro");
            }
            else if (CRUD.GetUsuarioByUsername(username) != null)
            {
                ViewData["Error"] = "El nombre de usuario ya existe";
                ViewData["Username"] = username;
                ViewData["Nombre"] = nombre;
                ViewData["Password"] = password;
                return View("Registro");
            }
            else if (usuario.Archivo == null)
            {
                ViewData["Error"] = "La foto es requerida";
                ViewData["Username"] = username;
                ViewData["Nombre"] = nombre;
                ViewData["Password"] = password;
				return View("Registro");
			}
            else
            {
                Byte[] bytes;
                using (var memoryStream = new MemoryStream())
                {
                    usuario.Archivo.CopyTo(memoryStream);
                    bytes = memoryStream.ToArray();
                }
                //Byte[] bytes = System.IO.File.ReadAllBytes(usuario.Archivo);
                String FotoFinal = Convert.ToBase64String(bytes);
                password = Usuario.encriptar(password);
                var User = new Usuario(nombre, username, password);
                User.Foto = FotoFinal;
                CRUD.CreateUsuario(User);
                return View("Login");
            }
        }

        public IActionResult Logout()
        {
            LoginService.CerrarSesion(HttpContext.Request.Cookies["token"]);
			HttpContext.Response.Cookies.Delete("token");
			return View("Login");
		}

    }
}
