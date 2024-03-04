using Caso_estudio1_Grupo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Caso_estudio1_Grupo1.Controllers
{
    public class LoginController : Controller
    {
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
                return View("LoginForm");
            }
            else if (Usuario.Contrasena != password)
            {
                ViewData["Error"] = "La contraseña es incorrecta";
                ViewData["Username"] = username;
                ViewData["Password"] = password;
                return View("LoginForm");
            }
            else
            {
                return View("~/Views/Home/Index.cshtml");
            }
        }
        public IActionResult Registro()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult RegisterAttempt()
        //{
        //    var username = Request.Form["username"];
        //    var nombre = Request.Form["nombre"];
        //    var password = Request.Form["password"];
        //    var confirm_password = Request.Form["confirm_password"];
        //    if (password != confirm_password)
        //    {
        //        ViewData["Error"] = "Las contraseñas no coinciden";
        //        ViewData["Username"] = username;
        //        ViewData["Nombre"] = nombre;
        //        ViewData["Password"] = password;
        //        return View("RegisterForm");
        //    }
        //    else if (username == "" || nombre == "" || password == "" || confirm_password == "")
        //    {
        //        ViewData["Error"] = "Todos los campos son requeridos";
        //        return View("RegisterForm");
        //    }
        //    else if (CRUD.GetUsuarioByUsername(username) != null)
        //    {
        //        ViewData["Error"] = "El nombre de usuario ya existe";
        //        ViewData["Username"] = username;
        //        ViewData["Nombre"] = nombre;
        //        ViewData["Password"] = password;
        //        return View("RegisterForm");
        //    }
        //    else
        //    {
        //        password = Usuario.encriptar(password);
        //        var User = new Usuario(nombre, username, password);
        //        CRUD.CreateUsuario(User);
        //        return View("LoginForm");
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> SubmitForm(Usuario usuario)
        {
            if (usuario != null)
            {
                Byte[] bytes = System.IO.File.ReadAllBytes(usuario.Foto);
                String file = Convert.ToBase64String(bytes);
                using (var context = new DatabaseContext())
                {
                    usuario.Foto = file;
                    context.Add(usuario);
                    await context.SaveChangesAsync();
                    return View("Index");
                }
            }
            return Content("<a>SALIO MAL</a>");
        }

        //POST method that will receive the uplaod of an image and store it in wwwroot/images
        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Content("<a>Imagen subida</a>");
            }
            return Content("<a>Imagen no subida</a>");
        }

        //POST method that will receive an Usuario. Part of the Usuario the user has to upload a profile picture. The image will be stored in wwwroot/images
        [HttpPost]
        public async Task<IActionResult> SubmitForm(Usuario usuario, IFormFile file)
        {
            if (usuario != null)
            {
                Byte[] bytes = System.IO.File.ReadAllBytes(usuario.Foto);
                String archivo = Convert.ToBase64String(bytes);
                using (var context = new DatabaseContext())
                {
                    usuario.Foto = archivo;
                    context.Add(usuario);
                    await context.SaveChangesAsync();
                    return View("Index");
                }
            }
            return Content("<a>SALIO MAL</a>");
        }   

    }
}
