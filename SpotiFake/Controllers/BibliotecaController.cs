using SpotiFake.DataBase;
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
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();
        [Authorize]
        public ActionResult Index(int idUsuario)
        {
            var listaReproduccion = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();
            return View(listaReproduccion);
        }
        public ViewResult RegistrarListaReproduccion()
        {
            return View( new ListaReproduccion());
        }
        public ActionResult AgregarListaDeReproduccion(ListaReproduccion LS, int idUsuario)
        {
            
            var listReproducRepetida = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario&&o.nombre==LS.nombre).FirstOrDefault();
            if (listReproducRepetida==null)
            {
                LS.idUsuario = idUsuario;
                spotiFakeContext.ListaReproduccions.Add(LS);
                spotiFakeContext.SaveChanges();
            }
            else
            {
                //nostrar mensaje que la lista agregada ya existe
            }
            var ListaReproduciones = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();
            return View("Index", ListaReproduciones);
        }
        [Authorize]
        public ViewResult SeleccionarPlaylist(int idC, int idU)
        {
            ViewBag.cancion = idC;
            var Playlist = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idU);
            return View(Playlist);
        }
        [Authorize]
        public ViewResult EliminarListRe(int idListaReproduccion, int idUsuario)
        {
            var LS = spotiFakeContext.ListaReproduccions.Where(o => o.idListaReproduccion == idListaReproduccion).First();
            spotiFakeContext.ListaReproduccions.Remove(LS);
            spotiFakeContext.SaveChanges();
            var ListaReproduciones = spotiFakeContext.ListaReproduccions.Where(o => o.idUsuario == idUsuario).ToList();
            return View("Index", ListaReproduciones);
        }

        public ActionResult AgregarCancion(int idCancion, int idListaReproduccion)
        //una vez agregada la cancion a la playlist lo regrese al playList que a estado escuchando(opcional)
        {
            var cancionRepetida = spotiFakeContext.listaReproduccion_Cancion.Where(o => o.idCancion == idCancion && o.idListaReproduccion == idListaReproduccion).FirstOrDefault();
            if (cancionRepetida==null)
            {
                var tabladetalle = new ListaReproduccion_Cancion();
                tabladetalle.idListaReproduccion = idListaReproduccion;
                tabladetalle.idCancion = idCancion;
                spotiFakeContext.listaReproduccion_Cancion.Add(tabladetalle);
                spotiFakeContext.SaveChanges();
            }
            else
            {
                //mostrar mensaje que la cancion ya se encuentra en la lista de reproduccion
            }
            return RedirectToAction("UsuarioIndex", "Usuario");
        }
        public ActionResult Detalle(int idListaReproduccion)
        {
            var ListCanciones = spotiFakeContext.listaReproduccion_Cancion.Where(o=>o.idListaReproduccion==idListaReproduccion).Include(o => o.cancion).ToList();
            return View(ListCanciones);
        }
    }
}