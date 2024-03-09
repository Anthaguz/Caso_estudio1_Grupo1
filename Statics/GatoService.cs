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
        private static string[][] ClonarTablero(string[][] tablero)
        {
            string[][] nuevoTablero = new string[tablero.Length][];
            for (int i = 0; i < tablero.Length; i++)
            {
                nuevoTablero[i] = new string[2];
                nuevoTablero[i][0] = tablero[i][0];
                nuevoTablero[i][1] = tablero[i][1];
            }
            return nuevoTablero;
        }
        public static int JugadaComputadora(string[][] valores)
        {
            int mejorValor = int.MinValue;
            int mejorJugada = -1;

            for (int i = 0; i < valores.Length; i++)
            {
                if (valores[i][1] != "X" && valores[i][1] != "O")
                {
                    string[][] nuevoTablero = ClonarTablero(valores);
                    nuevoTablero[i][1] = "X"; // La computadora juega como "X"
                    int valor = Minimax(nuevoTablero, false);
                    if (valor > mejorValor)
                    {
                        mejorValor = valor;
                        mejorJugada = i;
                    }
                }
            }

            return mejorJugada;
        }

        private static int Minimax(string[][] tablero, bool esMaximizando)
        {
            string estadoJuego = VerificarEstadoJuego(tablero);

            if (estadoJuego == "X")
                return 10; // La computadora gana
            else if (estadoJuego == "O")
                return -10; // El jugador gana
            else if (estadoJuego == "Empate")
                return 0; // Empate

            if (esMaximizando)
            {
                int mejorValor = int.MinValue;
                for (int i = 0; i < tablero.Length; i++)
                {
                    if (tablero[i][1] != "X" && tablero[i][1] != "O")
                    {
                        string[][] nuevoTablero = ClonarTablero(tablero);
                        nuevoTablero[i][1] = "X"; // La computadora juega como "X"
                        mejorValor = Math.Max(mejorValor, Minimax(nuevoTablero, false));
                    }
                }
                return mejorValor;
            }
            else
            {
                int mejorValor = int.MaxValue;
                for (int i = 0; i < tablero.Length; i++)
                {
                    if (tablero[i][1] != "X" && tablero[i][1] != "O")
                    {
                        string[][] nuevoTablero = ClonarTablero(tablero);
                        nuevoTablero[i][1] = "O"; // El jugador juega como "O"
                        mejorValor = Math.Min(mejorValor, Minimax(nuevoTablero, true));
                    }
                }
                return mejorValor;
            }
        }
        public static string VerificarEstadoJuego(string[][] valores)
        {
            string[,] tablero = ConvertirAArrayBidimensional(valores);

            if (HayGanador(tablero, "O"))
            {
                return "O"; // El jugador (O) ha ganado
            }
            else if (HayGanador(tablero, "X"))
            {
                return "X"; // La computadora (X) ha ganado
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
                    if (tablero[i, j] != "O" && tablero[i, j] != "X")
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
