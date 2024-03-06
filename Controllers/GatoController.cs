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
			//Initial move by the computer
			ViewData["9"] = "X";

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
			string[,] tablero = new string[3, 3];

			//La logica del gato iria aqui, deberiamos implementar otra clase 
			//helper que se encargue de todo, para no cargar tanto este metodo
			return "funciona!";
		}
		

	}
}
