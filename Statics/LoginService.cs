using Caso_estudio1_Grupo1.Models;

namespace Caso_estudio1_Grupo1.Statics
{
    public static class LoginService
    {
        public static string CrearSesion(int IdUsuario)
        {
            var existeSesion = CRUD.FindSesionesByUserId(IdUsuario);
            if (existeSesion.Count!=0)
            {
                Sesiones tempSesion = existeSesion[0];
                foreach (var session in existeSesion)
                {
                    if (session.IdSesion != tempSesion.IdSesion)
                    {
                        CRUD.DeleteSesion(session);
                    }
                }
                return tempSesion.IdSesion;
            }
            var token = Guid.NewGuid().ToString();
            var sesion = new Sesiones(token, IdUsuario);
            CRUD.CreateSesiones(sesion);
            return token;
        }

        internal static CookieOptions GetCookieOptions()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(20);
            return cookieOptions;
        }

        public static bool ValidateToken(string token)
        {
			if (token == null)
            {
				return false;
			}
			var sesion = CRUD.ReadSesion(token);
			if (sesion==null)
            {
				return false;
			}
			var usuario = CRUD.GetUsuarioById(sesion.IdUsuario);
            if (usuario == null)
            {
				return false;
			}
			return true;
		}

        public static void CerrarSesion(string token)
        {
			var sesion = CRUD.ReadSesion(token);
			CRUD.DeleteSesion(sesion);
		}
    }
}
