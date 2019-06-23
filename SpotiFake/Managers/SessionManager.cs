using SpotiFake.Interface.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SpotiFake.Managers
{
    public class SessionManager : ISessionManager
    {
        HttpSessionState session;

        public void SetNombreUsuario(String nombreUsuario)
        {
            session = HttpContext.Current.Session;
            session["NombreUsuario"] = nombreUsuario;
        }

        public void SetIdUsuario(int idUsuario)
        {
            session = HttpContext.Current.Session;
            session["IdUsuario"] = idUsuario;
        }

        public void AutenticacionCorreoElectronico(String correoElectronico, bool valor)
        {
            FormsAuthentication.SetAuthCookie(correoElectronico, valor);
        }
    }
}