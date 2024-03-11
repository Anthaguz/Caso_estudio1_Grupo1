using Case_estudio1_Grupo1.Models;
using Caso_estudio1_Grupo1.Models;
using Caso_estudio1_Grupo1.Statics;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Case_estudio1_Grupo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			if (!LoginService.ValidateToken(HttpContext.Request.Cookies["token"])) { return Redirect("~/login/login"); }
            var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
            var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
            ViewData["username"] = usuario.Username;
            ViewData["foto"] = usuario.Foto;
			return View();
        }

        public IActionResult Privacy()
        {
            if (!LoginService.ValidateToken(HttpContext.Request.Cookies["token"])){return Redirect("~/login/login"); }
            var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
            var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
            ViewData["username"] = usuario.Username;
            ViewData["foto"] = usuario.Foto;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
            var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
            ViewData["username"] = usuario.Username;
            ViewData["foto"] = usuario.Foto;
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
