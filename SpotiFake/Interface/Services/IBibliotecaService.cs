using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiFake.Interface
{
    public interface IBibliotecaService
    {
        List<ListaReproduccion> obtenerListaReproduccionUsuario(int idUsuario);

        ListaReproduccion verificarListaReproduccionRepetida(ListaReproduccion listaReproduccion, int idUsuario);

        void agregarIdUsuarioAListaReproduccion(ListaReproduccion listaReproduccion, int idUsuario);

        List<ListaReproduccion> obtenerListaReproduccionPorUsuario(int idUsuario);

        IQueryable<ListaReproduccion> obtenerListaReproduccionPorUsuarioIQueriable(int idUsuario);

        List<ListaReproduccion> eliminarListaReproduccionYMostrarNuevaLista(int idListaReproduccion, int idUsuario);

        ListaReproduccion_Cancion obtenerCancionRepetidaEnListaReproduccion_Cancion(int idCancion, int idListaReproduccion);

        void agregarCancionAListaReproduccion(int idCancion, int idListaReproduccion);

        List<ListaReproduccion_Cancion>obtenerCancionesDeUnaListaReproduccion(int idListaReproduccion);

        void eliminarCancionPlaylist(int idListaReproduccion_Cancion);
    }
}
