using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SpotiFake.Services
{
    public class BibliotecaService : IBibliotecaService
    {

        private SpotiFakeContext context;

        public BibliotecaService()
        {
            context = new SpotiFakeContext();
        }

        public List<ListaReproduccion> obtenerListaReproduccionUsuario(int idUsuario)
        {
            var listaReproduccionUsuario = context.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();
            return listaReproduccionUsuario;
        }

        public ListaReproduccion verificarListaReproduccionRepetida(ListaReproduccion listaReproduccion, int idUsuario)
        {
            return context.ListaReproduccions.Where(o => o.idUsuario == idUsuario && o.nombre == listaReproduccion.nombre).
                FirstOrDefault();
        }

        public void agregarIdUsuarioAListaReproduccion(ListaReproduccion listaReproduccion, int idUsuario)
        {
                listaReproduccion.idUsuario = idUsuario;
                context.ListaReproduccions.Add(listaReproduccion);
                context.SaveChanges();
        }

        public List<ListaReproduccion> obtenerListaReproduccionPorUsuario(int idUsuario)
        {
            return context.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();
        }

        public IQueryable<ListaReproduccion> obtenerListaReproduccionPorUsuarioIQueriable(int idUsuario)
        {
            var playlist = context.ListaReproduccions.Where(o => o.idUsuario == idUsuario);
            return playlist;
        }

        public List<ListaReproduccion> eliminarListaReproduccionYMostrarNuevaLista(int idListaReproduccion, int idUsuario)
        {
            var listaReproduccion = context.ListaReproduccions.Where(o => o.idListaReproduccion == idListaReproduccion).First();
            context.ListaReproduccions.Remove(listaReproduccion);
            context.SaveChanges();
            var ListaReproduciones = context.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();

            return ListaReproduciones;
        }

        public ListaReproduccion_Cancion obtenerCancionRepetidaEnListaReproduccion_Cancion(int idCancion, int idListaReproduccion)
        {
            return context.listaReproduccion_Cancion.
                Where(o => o.idCancion == idCancion &&
                o.idListaReproduccion == idListaReproduccion).FirstOrDefault();
        }

        public void agregarCancionAListaReproduccion(int idCancion, int idListaReproduccion)
        {
                var tabladetalle = new ListaReproduccion_Cancion();
                tabladetalle.idListaReproduccion = idListaReproduccion;
                tabladetalle.idCancion = idCancion;
                context.listaReproduccion_Cancion.Add(tabladetalle);
                context.SaveChanges();
        }

        public List<ListaReproduccion_Cancion> obtenerCancionesDeUnaListaReproduccion(int idListaReproduccion)
        {
            var listaCanciones = context.listaReproduccion_Cancion.
                Where(o => o.idListaReproduccion == idListaReproduccion).Include(o => o.cancion).ToList();

            return listaCanciones;
        }
    }
}