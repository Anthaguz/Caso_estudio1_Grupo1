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
		public string Jugada( 
			string c1,
			string c2,
			string c3,
			string c4,
			string c5,
			string c6,
			string c7,
			string c8,
			string c9,
			string botonPresionado,
			string dataString)
		{
			//dataString is a variable with a syntax similar to this:
			//   'c1=1&c2=2&c3=3&c4=4&c5=5&c6=6&c7=7&c8=8&c9=X&botonPresionado=2'
			//We will split the string using the & sign, resulting in a string[]
			//Then each of the values in the string[] will be split using the = sign, resulting in a string[][]
			//We will then iterate through the string[][] and store the values in a 2D array
			string[] entradas = dataString.Split('&');
			string[][] valores = new string[entradas.Length][];
			for (int i = 0; i < entradas.Length; i++)
			{
				valores[i] = entradas[i].Split('=');
			}
			string[,] tablero = new string[3, 3];


			return "funciona!";
		}
		

	}
}
