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

        List<ListaReproduccion> agregarListaReproduccion(ListaReproduccion listaReproduccion, int idUsuario);

        IQueryable<ListaReproduccion> obtenerListaReproduccionPorUsuario(int idUsuario);

        List<ListaReproduccion> eliminarListaReproduccionYMostrarNuevaLista(int idListaReproduccion, int idUsuario);

        void agregarCancionAListaReproduccion(int idCancion, int idListaReproduccion);

        List<ListaReproduccion_Cancion>obtenerCancionesDeUnaListaReproduccion(int idListaReproduccion);
    }
}
