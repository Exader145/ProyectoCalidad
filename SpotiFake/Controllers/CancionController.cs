using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SpotiFake.Controllers
{
    [Authorize]
    public class CancionController : Controller
    {
        //SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        private ICancionService service;

        public CancionController(ICancionService service)
        {
            this.service = service;
        }
        
        public ActionResult Index()
        {
            var cancion = service.obtenerListaCanciones();

            return View(cancion);
        }

        public ActionResult IndexSys()
        //el motivo de este metodo es para que a travez del layout no se colen los administradores a la interfaz del sys
        {
            //var cancion = spotiFakeContext.Cancions.ToList();

            var cancion = service.obtenerListaCanciones();

            return View(cancion);
        }

        public ViewResult registrarCancion()
        {
            return View("FormularioCancion",new Cancion());
        }

        public ViewResult registrarCancionSys()
        //el motivo de este metodo es para que a travez del layout no se colen los administradores a la interfaz del sys
        {
            return View(new Cancion());
        }

        public ActionResult agregar(Cancion cancion)
        {
            //spotiFakeContext.Cancions.Add(cancion);
            //cancion.fechaRegistro = DateTime.Now;
            //spotiFakeContext.SaveChanges();

            service.guardarCancion(cancion);

            return RedirectToAction("Index");
        }

        public ActionResult agregarSys(Cancion cancion)
        {
            //spotiFakeContext.Cancions.Add(cancion);
            //cancion.fechaRegistro = DateTime.Now;
            //spotiFakeContext.SaveChanges();

            service.guardarCancion(cancion);

            return RedirectToAction("IndexSys");
        }

        public ViewResult modificar(int id)
        {
            //var cancion = spotiFakeContext.Cancions.Where(o => o.idCancion == id).FirstOrDefault();

            var cancion = service.obtenerDatosCancionAModificar(id);
            
            return View("FormularioModificar", cancion);
        }

        public ViewResult modificarSys(int id)
        {
            //var cancion = spotiFakeContext.Cancions.Where(o => o.idCancion == id).FirstOrDefault();

            var cancion = service.obtenerDatosCancionAModificar(id);

            return View(cancion);
        }

        public RedirectToRouteResult actualizar(Cancion cancion)
        {
            //Cancion cancionBD = spotiFakeContext.Cancions.Where(y => y.idCancion == cancion.idCancion).FirstOrDefault();
            //cancionBD.nombre = cancion.nombre;
            //cancionBD.artista = cancion.artista;
            //cancionBD.album = cancion.album;
            //cancionBD.genero = cancion.genero;
            //cancionBD.duracionCancion = cancion.duracionCancion;
            //cancionBD.fechaLanzamiento = cancion.fechaLanzamiento;
            //cancionBD.imagen = cancion.imagen;
            //spotiFakeContext.SaveChanges();

            service.actualizarCancion(cancion);

            return RedirectToAction("Index");
        }
        public RedirectToRouteResult actualizarSys(Cancion cancion)
        {
            //Cancion cancionBD = spotiFakeContext.Cancions.Where(y => y.idCancion == cancion.idCancion).FirstOrDefault();
            //cancionBD.nombre = cancion.nombre;
            //cancionBD.artista = cancion.artista;
            //cancionBD.album = cancion.album;
            //cancionBD.genero = cancion.genero;
            //cancionBD.duracionCancion = cancion.duracionCancion;
            //cancionBD.fechaLanzamiento = cancion.fechaLanzamiento;
            //cancionBD.imagen = cancion.imagen;
            //spotiFakeContext.SaveChanges();

            service.actualizarCancion(cancion);

            return RedirectToAction("IndexSys");
        }

        public RedirectToRouteResult eliminar(int idCancion)
        {
            //var cancion = spotiFakeContext.Cancions.Where(d => d.idCancion == id).FirstOrDefault();
            //spotiFakeContext.Cancions.Remove(cancion);
            //spotiFakeContext.SaveChanges();

            service.eliminarCancion(idCancion);

            return RedirectToAction("Index");
        }

        public RedirectToRouteResult eliminarSys(int idCancion)
        {
            //var cancion = spotiFakeContext.Cancions.Where(d => d.idCancion == id).FirstOrDefault();
            //spotiFakeContext.Cancions.Remove(cancion);
            //spotiFakeContext.SaveChanges();

            service.eliminarCancion(idCancion);

            return RedirectToAction("IndexSys");
        }

        public ActionResult logOff()
        {
            //FormsAuthentication.SignOut();

            service.logOff();

            return RedirectToAction("Index", "Login");
        }
    }
}