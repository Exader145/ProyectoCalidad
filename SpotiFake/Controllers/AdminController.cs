using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class AdminController : Controller
    {

        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        [Authorize]
        public ActionResult Index()
        {
            var cancion = spotiFakeContext.Usuarios.Where(o=>o.rol=="Admin").ToList();
            return View("Index", cancion);
        }

        [Authorize]
        public ViewResult FormularioAdmin()
        {
            return View("FormularioAdmin", new Usuario());
        }

        [Authorize]
        public ActionResult agregar(Usuario usuario)
        {
            spotiFakeContext.Usuarios.Add(usuario);
            usuario.rol = "Admin";
            usuario.fechaCreación = DateTime.Now;
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ViewResult FormularioModificar(int id)
        {
            Usuario admin = spotiFakeContext.Usuarios.Where(o => o.idUsuario == id).First();
            return View("FormularioModificar", admin);
        }

        [Authorize]
        public RedirectToRouteResult Actualizar(Usuario usuario)
        {
            Usuario adminBD = spotiFakeContext.Usuarios.Where(y => y.idUsuario == usuario.idUsuario).First();
            adminBD.nombre = usuario.nombre;
            adminBD.correoElectronico = usuario.correoElectronico;
            adminBD.contraseña = usuario.contraseña;
            
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToRouteResult eliminar(int id)
        {
            Usuario usuario = spotiFakeContext.Usuarios.Where(d => d.idUsuario == id).FirstOrDefault();
            spotiFakeContext.Usuarios.Remove(usuario);
            spotiFakeContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}