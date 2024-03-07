﻿using Caso_estudio1_Grupo1.Statics;
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
			//Movimiento inicial de la computadora
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

			int jugada = int.Parse(valores[9][1]) - 1;
			valores[jugada][1] = "O";
			int jugadaComputadora = GatoService.JugadaComputadora(valores);
			valores[jugadaComputadora][1] = "X";

			string respuesta = GatoService.GenerarRespuesta(valores);

			string estadoJuego = GatoService.VerificarEstadoJuego(valores);
			ViewData["EstadoJuego"] = estadoJuego;
			return respuesta;


		}



	}
}
