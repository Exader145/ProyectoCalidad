using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiFake.Interface
{
    public interface IUsuarioService
    {
        List<Cancion> obtenerListaCancionesRegistradas();

        void logOff();

        void agregarCancionACancionesEscuchadas(int idCancion, int idUsuario);

        List<CancionesEscuchadas> obtenerListaCancionesEscuchadas(int idUsuario);
    }
}
