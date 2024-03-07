namespace Caso_estudio1_Grupo1.Statics
{
	public static class GatoService
	{
		public static string GenerarRespuesta(string[][] valores)
		{
			string respuesta =
					valores[0][0] + "=" + valores[0][1] + "&" +
					valores[1][0] + "=" + valores[1][1] + "&" +
					valores[2][0] + "=" + valores[2][1] + "&" +
					valores[3][0] + "=" + valores[3][1] + "&" +
					valores[4][0] + "=" + valores[4][1] + "&" +
					valores[5][0] + "=" + valores[5][1] + "&" +
					valores[6][0] + "=" + valores[6][1] + "&" +
					valores[7][0] + "=" + valores[7][1] + "&" +
					valores[8][0] + "=" + valores[8][1] + "&" +
					valores[9][0] + "=" + valores[9][1];
			return respuesta;
		}

		public static int JugadaComputadora(string[][] valores)
		{
			//valor random de la computadora
			Random rnd = new Random();
			//Se busca un espacio vacio. Es vacio si el valor no es ni X ni O

			int jugada = rnd.Next(0, 9);
			while (valores[jugada][1] == "X" || valores[jugada][1] == "O")
			{
				jugada = rnd.Next(0, 9);
			}
			return jugada;
		}
	}
}
