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

        public List<ListaReproduccion> agregarListaReproduccion(ListaReproduccion listaReproduccion, int idUsuario)
        {
            var listReproducRepetida = context.ListaReproduccions.
                Where(o => o.idUsuario == idUsuario && o.nombre == listaReproduccion.nombre).FirstOrDefault();

            if (listReproducRepetida == null)
            {
                listaReproduccion.idUsuario = idUsuario;
                context.ListaReproduccions.Add(listaReproduccion);
                context.SaveChanges();
            }
            else
            {
                //mostrar mensaje que la lista agregada ya existe
            }

            var ListaReproducciones = context.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();

            return ListaReproducciones;
        }

        public IQueryable<ListaReproduccion> obtenerListaReproduccionPorUsuario(int idUsuario)
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

        public void agregarCancionAListaReproduccion(int idCancion, int idListaReproduccion)
        {
            var cancionRepetida = context.listaReproduccion_Cancion.
                Where(o => o.idCancion == idCancion && o.idListaReproduccion == idListaReproduccion).FirstOrDefault();

            if (cancionRepetida == null)
            {
                var tabladetalle = new ListaReproduccion_Cancion();
                tabladetalle.idListaReproduccion = idListaReproduccion;
                tabladetalle.idCancion = idCancion;
                context.listaReproduccion_Cancion.Add(tabladetalle);
                context.SaveChanges();
            }
            else
            {
                //mostrar mensaje que la cancion ya se encuentra en la lista de reproduccion
            }
        }

        public List<ListaReproduccion_Cancion> obtenerCancionesDeUnaListaReproduccion(int idListaReproduccion)
        {
            var listaCanciones = context.listaReproduccion_Cancion.
                Where(o => o.idListaReproduccion == idListaReproduccion).Include(o => o.cancion).ToList();

            return listaCanciones;
        }
    }
}