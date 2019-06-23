using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiFake.Interface
{
    public interface ILoginService
    {
        Usuario obtenerUsuarioRegistrado(Usuario usuario);
    }
}
