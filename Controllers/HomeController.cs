using Case_estudio1_Grupo1.Models;
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
            var token = HttpContext.Request.Cookies["token"];
            if (token==null)
            {
                return Redirect("~/login/login");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            var token = HttpContext.Request.Cookies["token"];
            if (token == null)
            {
                return Redirect("~/login/login");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
