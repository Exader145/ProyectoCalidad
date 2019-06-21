using SpotiFake.DataBase;
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
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();
        
        public ActionResult Index()
        {
            var cancion = spotiFakeContext.Cancions.ToList();
            return View(cancion);
        }

        public ActionResult IndexSys()
        //el motivo de este metodo es para que a travez del layout no se colen los administradores a la interfaz del sys
        {
            var cancion = spotiFakeContext.Cancions.ToList();
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
            spotiFakeContext.Cancions.Add(cancion);
            cancion.fechaRegistro = DateTime.Now;
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult agregarSys(Cancion cancion)
        {
            spotiFakeContext.Cancions.Add(cancion);
            cancion.fechaRegistro = DateTime.Now;
            spotiFakeContext.SaveChanges();
            return RedirectToAction("IndexSys");
        }

        public ViewResult modificar(int id)
        {
            var cancion = spotiFakeContext.Cancions.Where(o => o.idCancion == id).FirstOrDefault();
            return View("FormularioModificar", cancion);
        }

        public ViewResult modificarSys(int id)
        {
            var cancion = spotiFakeContext.Cancions.Where(o => o.idCancion == id).FirstOrDefault();
            return View(cancion);
        }

        public RedirectToRouteResult actualizar(Cancion cancion)
        {
            Cancion cancionBD = spotiFakeContext.Cancions.Where(y => y.idCancion == cancion.idCancion).FirstOrDefault();
            cancionBD.nombre = cancion.nombre;
            cancionBD.artista = cancion.artista;
            cancionBD.album = cancion.album;
            cancionBD.genero = cancion.genero;
            cancionBD.duracionCancion = cancion.duracionCancion;
            cancionBD.fechaLanzamiento = cancion.fechaLanzamiento;
            cancionBD.imagen = cancion.imagen;
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public RedirectToRouteResult actualizarSys(Cancion cancion)
        {
            Cancion cancionBD = spotiFakeContext.Cancions.Where(y => y.idCancion == cancion.idCancion).FirstOrDefault();
            cancionBD.nombre = cancion.nombre;
            cancionBD.artista = cancion.artista;
            cancionBD.album = cancion.album;
            cancionBD.genero = cancion.genero;
            cancionBD.duracionCancion = cancion.duracionCancion;
            cancionBD.fechaLanzamiento = cancion.fechaLanzamiento;
            cancionBD.imagen = cancion.imagen;
            spotiFakeContext.SaveChanges();
            return RedirectToAction("IndexSys");
        }

        public RedirectToRouteResult eliminar(int id)
        {
            var cancion = spotiFakeContext.Cancions.Where(d => d.idCancion == id).FirstOrDefault();
            spotiFakeContext.Cancions.Remove(cancion);
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public RedirectToRouteResult eliminarSys(int id)
        {
            var cancion = spotiFakeContext.Cancions.Where(d => d.idCancion == id).FirstOrDefault();
            spotiFakeContext.Cancions.Remove(cancion);
            spotiFakeContext.SaveChanges();
            return RedirectToAction("IndexSys");
        }

        public ActionResult logOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }
    }
}