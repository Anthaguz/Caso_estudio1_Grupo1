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
			Random rnd = new Random();
			int jugada = rnd.Next(0, 9);

			while (valores[jugada][1] == "X" || valores[jugada][1] == "O")
			{
				jugada = rnd.Next(0, 9);
			}

			return jugada;
		}

        public static string VerificarEstadoJuego(string[][] valores)
        {
            string[,] tablero = ConvertirAArrayBidimensional(valores);

            if (HayGanador(tablero, "X"))
            {
                return "X"; // La computadora (X) ha ganado
            }
            else if (HayGanador(tablero, "O"))
            {
                return "O"; // El jugador (O) ha ganado
            }
            else if (EsEmpate(tablero))
            {
                return "Empate"; // El juego ha terminado en empate
            }
            else
            {
                return "EnCurso"; // El juego está en curso
            }
        }

        private static bool HayGanador(string[,] tablero, string jugador)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tablero[i, 0] == jugador && tablero[i, 1] == jugador && tablero[i, 2] == jugador)
                    return true; // Ganador en una fila

                if (tablero[0, i] == jugador && tablero[1, i] == jugador && tablero[2, i] == jugador)
                    return true; // Ganador en una columna
            }

            if (tablero[0, 0] == jugador && tablero[1, 1] == jugador && tablero[2, 2] == jugador)
                return true; // Ganador en la diagonal principal

            if (tablero[0, 2] == jugador && tablero[1, 1] == jugador && tablero[2, 0] == jugador)
                return true; // Ganador en la diagonal secundaria

            return false;
        }

        private static bool EsEmpate(string[,] tablero)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tablero[i, j] == null)
                        return false; // Todavía hay al menos una casilla vacía
                }
            }

            return true; // Todas las casillas están ocupadas y no hay ganador
        }

		private static string[,] ConvertirAArrayBidimensional(string[][] valores)
		{
			string[,] tablero = new string[3, 3];

			for (int i = 0; i < valores.Length; i++)
			{
				if (int.TryParse(valores[i][0].Substring(1), out int casilla))
				{
					casilla--; // Restar 1 si la conversión fue exitosa
					int fila = casilla / 3;
					int columna = casilla % 3;
					tablero[fila, columna] = valores[i][1];
				}
			}

			return tablero;
		}
	}
}
