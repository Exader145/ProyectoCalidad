using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class BibliotecaController : Controller
    {

        //SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        private IBibliotecaService service;

        public BibliotecaController(IBibliotecaService service)
        {
            this.service = service;
        }

        [Authorize]
        public ActionResult Index(int idUsuario)
        {
            //var listaReproduccion = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();

            var listaReproduccionUsuario = service.obtenerListaReproduccionUsuario(idUsuario);

            return View(listaReproduccionUsuario);
        }

        public ViewResult RegistrarListaReproduccion()
        {
            return View( new ListaReproduccion());
        }

        public ActionResult AgregarListaDeReproduccion(ListaReproduccion listaReproduccion, int idUsuario)
        {

            //var listReproducRepetida = spotiFakeContext.ListaReproduccions.
            //    Where(o => o.idUsuario == idUsuario && o.nombre == listaReproduccion.nombre).FirstOrDefault();

            //if (listReproducRepetida == null)
            //{
            //    listaReproduccion.idUsuario = idUsuario;
            //    spotiFakeContext.ListaReproduccions.Add(listaReproduccion);
            //    spotiFakeContext.SaveChanges();
            //}
            //else
            //{
            //    //nostrar mensaje que la lista agregada ya existe
            //}

            //var ListaReproduciones = spotiFakeContext.ListaReproduccions.
            //    Where(o => o.idUsuario == idUsuario).ToList();

            var listaReproduccionRepetida = service.verificarListaReproduccionRepetida(listaReproduccion, idUsuario);

            if ( listaReproduccionRepetida == null)
            {
                service.agregarIdUsuarioAListaReproduccion(listaReproduccion, idUsuario);
            }

            var listaReproduccionUsuario = service.obtenerListaReproduccionPorUsuario(idUsuario);

            return View("Index", listaReproduccionUsuario);
        }

        [Authorize]
        public ViewResult SeleccionarPlaylist(int idCancion, int idUsuario)
        {
            ViewBag.cancion = idCancion;

            //var playlist = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario);

            var playlist = service.obtenerListaReproduccionPorUsuarioIQueriable(idUsuario);

            return View(playlist);
        }

        [Authorize]
        public ViewResult EliminarListRe(int idListaReproduccion, int idUsuario)
        {
            //var listaReproduccion = spotiFakeContext.ListaReproduccions.Where(o => o.idListaReproduccion == idListaReproduccion).First();
            //spotiFakeContext.ListaReproduccions.Remove(listaReproduccion);
            //spotiFakeContext.SaveChanges();
            //var ListaReproduciones = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();

            var ListaReproducciones = service.eliminarListaReproduccionYMostrarNuevaLista(idListaReproduccion, idUsuario);

            return View("Index", ListaReproducciones);
        }

        public ActionResult AgregarCancion(int idCancion, int idListaReproduccion)
        //una vez agregada la cancion a la playlist lo regrese al playList que a estado escuchando(opcional)
        {
            //var cancionRepetida = spotiFakeContext.listaReproduccion_Cancion.Where(o => o.idCancion == idCancion && o.idListaReproduccion == idListaReproduccion).FirstOrDefault();
            //if (cancionRepetida == null)
            //{
            //    var tabladetalle = new ListaReproduccion_Cancion();
            //    tabladetalle.idListaReproduccion = idListaReproduccion;
            //    tabladetalle.idCancion = idCancion;
            //    spotiFakeContext.listaReproduccion_Cancion.Add(tabladetalle);
            //    spotiFakeContext.SaveChanges();
            //}
            //else
            //{
            //    //mostrar mensaje que la cancion ya se encuentra en la lista de reproduccion
            //}

            var cancionRepetida = service.obtenerCancionRepetidaEnListaReproduccion_Cancion(idCancion, idListaReproduccion);

            if(cancionRepetida == null)
            {
                service.agregarCancionAListaReproduccion(idCancion, idListaReproduccion);
            }

            return RedirectToAction("UsuarioIndex", "Usuario");
        }

        public ActionResult Detalle(int idListaReproduccion)
        {
            //var ListCanciones = spotiFakeContext.listaReproduccion_Cancion.Where(o=>o.idListaReproduccion==idListaReproduccion).Include(o => o.cancion).ToList();

            var listaCanciones = service.obtenerCancionesDeUnaListaReproduccion(idListaReproduccion);

            return View(listaCanciones);
        }
    }
}