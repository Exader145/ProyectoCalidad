using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiFake.Services
{
    public class LoginService : ILoginService
    {

        private SpotiFakeContext context;

        public LoginService()
        {
            context = new SpotiFakeContext();
        }

        public Usuario obtenerUsuarioRegistrado(Usuario usuario)
        {
            return context.Usuarios.
                Where(o => o.correoElectronico == usuario.correoElectronico 
                && o.contraseña == usuario.contraseña).FirstOrDefault();
        }
    }
}
