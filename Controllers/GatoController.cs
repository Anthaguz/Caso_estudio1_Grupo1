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
		public IActionResult Jugada(string botonPresionado, 
			string c1,
			string c2,
			string c3,
			string c4,
			string c5,
			string c6,
			string c7,
			string c8,
			string c9)
		{
			string[] entradas = { c1, c2, c3, c4, c5, c6, c7, c8, c9 };
			for (int i = 0; i < entradas.Length; i++)
			{
				if (entradas[i] != null)
				{
					botonPresionado = (i+1).ToString();
					break;
				}
			}
			string[,] tablero = new string[3, 3];
			var cell1 = Request.Form["c1"];
			var cell2 = Request.Form["c2"];
			var cell3 = Request.Form["c3"];
			var cell4 = Request.Form["c4"];
			var cell5 = Request.Form["c5"];
			var cell6 = Request.Form["c6"];
			var cell7 = Request.Form["c7"];
			var cell8 = Request.Form["c8"];
			var cell9 = Request.Form["c9"];

			tablero[0, 0] = Request.Form["c1"];
			tablero[0, 1] = Request.Form["c2"];
			tablero[0, 2] = Request.Form["c3"];
			tablero[1, 0] = Request.Form["c4"];
			tablero[1, 1] = Request.Form["c5"];
			tablero[1, 2] = Request.Form["c6"];
			tablero[2, 0] = Request.Form["c7"];
			tablero[2, 1] = Request.Form["c8"];
			tablero[2, 2] = Request.Form["c9"];
			ViewData[botonPresionado] = "X";
			return View("~/Views/Gato/Imposible.cshtml");
		}
		

	}
}
