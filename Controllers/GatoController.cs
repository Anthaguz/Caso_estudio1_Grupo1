using Caso_estudio1_Grupo1.Models;
using Caso_estudio1_Grupo1.Statics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Caso_estudio1_Grupo1.Controllers
{
	public class GatoController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult Imposible()
		{
			if (!LoginService.ValidateToken(HttpContext.Request.Cookies["token"])) { return Redirect("~/login/login"); }
			var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
			var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
			ViewData["username"] = usuario.Username;
			ViewData["foto"] = usuario.Foto;
			//Movimiento inicial de la computadora
			ViewData["9"] = "X";

			return View();
		}

		public IActionResult PlayerStarts()
		{
			if (!LoginService.ValidateToken(HttpContext.Request.Cookies["token"])) { return Redirect("~/login/login"); }
			var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
			var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
			ViewData["username"] = usuario.Username;
			ViewData["foto"] = usuario.Foto;
			return View();
		}

		[HttpPost]
		public string Jugada(string dataString)
		{
			string[] entradas = dataString.Split('&');
			string[][] valores = new string[entradas.Length][];

			for (int i = 0; i < entradas.Length; i++)
			{
				valores[i] = entradas[i].Split('=');
			}
			int jugada = int.Parse(valores[9][1]) - 1;
			valores[jugada][1] = "O";
			int jugadaComputadora = GatoService.JugadaComputadora(valores);
			valores[jugadaComputadora][1] = "X";
			string estadoJuego = GatoService.VerificarEstadoJuego(valores);
			if (estadoJuego == "O")
			{
				valores[jugadaComputadora][1] = jugadaComputadora.ToString();
			}
			string respuesta = GatoService.GenerarRespuesta(valores);
			respuesta = respuesta + "&EstadoJuego=" + estadoJuego;
			if (estadoJuego != "EnCurso")
			{
				string resultado = "";
				switch (estadoJuego)
				{
					case "Empate":
						resultado = "Empate";
						break;
					case "X":
						resultado = "Derrota";
						break;
					case "O":
						resultado = "Victoria";
						break;
				}
				var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
				var duracion = int.Parse(valores[10][1]);
				var tableroFinal= GatoService.GenerarTableroFinal(valores);
				CRUD.CreateHistorial(new Historial(sesion.IdUsuario, resultado, duracion, tableroFinal));
			}
			return respuesta;
		}

		//Controller para mostrar el historial de partidas de gato
		public IActionResult Historial()
		{
			if (!LoginService.ValidateToken(HttpContext.Request.Cookies["token"])) { return Redirect("~/login/login"); }
			var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
			var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
			ViewData["username"] = usuario.Username;
			ViewData["foto"] = usuario.Foto;
			var historial = CRUD.FindHistorialForUser(sesion.IdUsuario);
			ViewBag.listaHistorial = historial;
			return View(historial);
		}
		public IActionResult Historial1()
		{
			if (!LoginService.ValidateToken(HttpContext.Request.Cookies["token"])) { return Redirect("~/login/login"); }
			var sesion = CRUD.ReadSesion(HttpContext.Request.Cookies["token"]);
			var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
			ViewData["username"] = usuario.Username;
			ViewData["foto"] = usuario.Foto;
			var historial = CRUD.FindHistorialForUser(sesion.IdUsuario);
			ViewBag.listaHistorial = historial;
			return View(historial);
		}
	}
}
