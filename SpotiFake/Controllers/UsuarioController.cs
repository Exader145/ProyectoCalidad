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
        [HttpPost]
        public ActionResult AdminIndex(Usuario usuario)
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult AdminIndex()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult UsuarioIndex(int idUsuario)//metodo para navegar
        {
            //var cancion = spotiFakeContext.Cancions.ToList();

            var cancion = service.obtenerListaCancionesPorUsuario();

            return View(cancion);
        }

        [Authorize]
        [HttpGet]
        public ActionResult UsuarioIndex()//metodo para ingresar
        {
            //var cancion = spotiFakeContext.Cancions.ToList();

            var cancion = service.obtenerListaCancionesPorUsuario();

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
        
        public ActionResult ReproducirCancion(int idCancion,int idUsuario)
        {
            //instamcia
            //var cancionesEscuchadas = new CancionesEscuchadas();
            //cancionesEscuchadas.fecha = DateTime.Now;
            //cancionesEscuchadas.idUsuario = idUsuario;
            //cancionesEscuchadas.idCancion = idCancion;
            //spotiFakeContext.CancionesEscuchadass.Add(cancionesEscuchadas);
            //spotiFakeContext.SaveChanges();
            //var cancion = spotiFakeContext.Cancions.ToList();

            var cancion = service.agregarCancionACancionesEscuchadas(idCancion, idUsuario);

            return View("UsuarioIndex", cancion);
        }
        //public ActionResult AgregarPlaylist(int idCancion)
        //{
        //    var cancion = spotiFakeContext.Cancions.ToList();
        //    return View("UsuarioIndex", cancion);
        //}
        [Authorize]
        public ActionResult Historial(int idUsuario)
        {
            //var historial = spotiFakeContext.CancionesEscuchadass.Where(o=>o.idUsuario== idUsuario).Include(o=>o.cancion).ToList();

            var cancionesEscuchadas = service.obtenerListaCancionesEscuchadas(idUsuario);

            return View(cancionesEscuchadas);
        }
    }
}