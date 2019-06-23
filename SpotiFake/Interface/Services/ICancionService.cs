using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiFake.Interface
{
    public interface ICancionService
    {
        List<Cancion> obtenerListaCanciones();

        void guardarCancion(Cancion cancion);

        Cancion obtenerDatosCancionAModificar(int id);

        void actualizarCancion(Cancion cancion);

        void eliminarCancion(int idCancion);

        void logOff();
    }
}
