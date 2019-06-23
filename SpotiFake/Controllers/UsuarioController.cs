using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SpotiFake.Controllers
{
    public class UsuarioController : Controller
    {

        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        private IUsuarioService service;

        public UsuarioController(IUsuarioService service)
        {
            this.service = service;
        }

        [Authorize]
        public ActionResult SysIndex()
        {
            return View();
        }

        [Authorize]
        public ActionResult AdminIndex()
        {
            return View();
        }

        [Authorize]
        public ActionResult UsuarioIndex()//metodo para ingresar
        {
            //var cancion = spotiFakeContext.Cancions.ToList();

            var cancion = service.obtenerListaCanciones();
            ViewBag.viewName = "UsuarioIndex";
            return View(cancion);
        }

        public ActionResult logOff()
        {
            //FormsAuthentication.SignOut();

            service.logOff();

            return RedirectToAction("Index", "Login");
        }

        public ActionResult GuardarUsuario(Usuario usuario)
        {
            if (spotiFakeContext.Usuarios.Any(o => o.correoElectronico == usuario.correoElectronico))
                ModelState.AddModelError("Correo", "el correo ya existe!");
            if (!ModelState.IsValid) return View("NuevoUsuario", usuario);
            usuario.fechaCreación = DateTime.Now;
            usuario.rol = "Usuario";
            spotiFakeContext.Usuarios.Add(usuario);
            spotiFakeContext.SaveChanges();
            Session["NombreUsuario"] = usuario.nombre;
            Session["IdUsuario"] = usuario.idUsuario;
            FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
            return RedirectToAction("UsuarioIndex");
        }

        public ViewResult NuevoUsuario()
        {
            return View("NuevoUsuario", new Usuario());
        }
        
        public ActionResult ReproducirCancion(int idCancion,int idUsuario, string viewName)
        {
            //AGREGAR UN PARAMETRO STRING QUE CONTENGA EL NOMBRE DE LA VISTA

            service.agregarCancionACancionesEscuchadas(idCancion, idUsuario);
            if (viewName == "Historial")
            {
                return View("Historial", service.obtenerListaCancionesEscuchadas(idUsuario));
            }
            return View("UsuarioIndex", service.obtenerListaCanciones());
        }
        [Authorize]
        public ActionResult Historial(int idUsuario)
        {
            //var historial = spotiFakeContext.CancionesEscuchadass.Where(o=>o.idUsuario== idUsuario).Include(o=>o.cancion).ToList();
            ViewBag.viewName = "Historial";
            var cancionesEscuchadas = service.obtenerListaCancionesEscuchadas(idUsuario);
            return View(cancionesEscuchadas);
        }
    }
}