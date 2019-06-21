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
    public class ContactoController : Controller
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        public ActionResult Index()
        {
            var usuario = spotiFakeContext.Usuarios.Where(o => o.rol == "Usuario").ToList();
            return View(usuario);
        }

        public ActionResult AgregarAmigo(int idUsuario, int idContacto)
        {
            var detalleUsuario = new DetalleUsuario();
            detalleUsuario.idUsuario = idUsuario;
            detalleUsuario.idContacto = idContacto;

            spotiFakeContext.DetalleUsuarios.Add(detalleUsuario);
            spotiFakeContext.SaveChanges();

            detalleUsuario.idUsuario = idContacto;
            detalleUsuario.idContacto = idUsuario;

            spotiFakeContext.DetalleUsuarios.Add(detalleUsuario);
            spotiFakeContext.SaveChanges();

            var usuario = spotiFakeContext.Usuarios.Where(o => o.rol == "Usuario").ToList();
            return View("Index", usuario);
        }

        public ActionResult Amigos(int idUsuario)
        {
            //var amigo = spotiFakeContext.Usuarios.Where(o => o.rol == "Usuario").ToList();
            var amigos = spotiFakeContext.DetalleUsuarios.Where(o => o.idUsuario == idUsuario).
                Include(o => o.idContacto).ToList();

            return View(amigos);
        }
    }
}