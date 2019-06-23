using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpotiFake.Interface.Managers
{
    public interface ISessionManager
    {
        void SetNombreUsuario(String nombreUsuario);
        void SetIdUsuario(int idUsuario);
    }
}