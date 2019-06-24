using SpotiFake.DataBase;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SpotiFake.Controllers
{
    public class ContactoController : Controller
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        public ActionResult Index(int idUsuario)
        {
            //var usuario = spotiFakeContext.Usuarios.Where(o => o.rol == "Usuario"&&o.idUsuario!=idUsuario).ToList();
            //return View(usuario);
            return View();
        }
        public ActionResult getUsers(int idUsuario)
        {
            List<DetalleUsuario> contactos = spotiFakeContext.DetalleUsuarios.Where(o => o.idUsuario == idUsuario).ToList();
            List<Usuario> listContactos = new List<Usuario>();
            foreach (var contacto in contactos)
            {
                var iterar=spotiFakeContext.Usuarios.Where(o => o.idUsuario == contacto.idContacto).FirstOrDefault();
                if (iterar!=null)
                {
                    listContactos.Add(iterar);
                }
                
            }
            IEnumerable<Usuario> listcontact = listContactos;
            var usuario = spotiFakeContext.Usuarios.Where(o => o.rol == "Usuario" && o.idUsuario != idUsuario).ToList().Except(listcontact);
            
            return View(usuario);
        }
        public ViewResult getUsersAmigos(int idUsuario)
        {
            var amigos = spotiFakeContext.DetalleUsuarios.Where(o => o.idUsuario == idUsuario).Include(o=>o.usuario).ToList();
            List<Usuario> listAmigos = new List<Usuario>();
            foreach (var contacto in amigos)
            {
                var iterar = spotiFakeContext.Usuarios.Where(o => o.idUsuario == contacto.idContacto).FirstOrDefault();
                if (iterar != null)
                {
                    listAmigos.Add(iterar);
                }

            }
            //var jsonSerialiser = new JavaScriptSerializer();
            //var json = jsonSerialiser.Serialize(listAmigos);
            return View (amigos);
        }
        public ActionResult AgregarAmigo(int idUsuario, int idContacto)
        {
            var amigoExisteBD = spotiFakeContext.DetalleUsuarios.Where(o=>o.idUsuario==idUsuario&&o.idContacto==idContacto).FirstOrDefault();
            if (amigoExisteBD==null)
            {
                var detalleUsuario = new DetalleUsuario();
                detalleUsuario.idUsuario = idUsuario;
                detalleUsuario.idContacto = idContacto;

                spotiFakeContext.DetalleUsuarios.Add(detalleUsuario);
                spotiFakeContext.SaveChanges();

            }
            

            var usuario = spotiFakeContext.Usuarios.Where(o => o.rol == "Usuario"&&o.idUsuario!=idUsuario).ToList();
            return View("Index", usuario);
        }
        public ActionResult dejarAmigo(int idUsuario,int idContacto)
        {
            var amigo = spotiFakeContext.DetalleUsuarios.Where(o => o.idUsuario == idUsuario && o.idContacto == idContacto).FirstOrDefault();
            spotiFakeContext.DetalleUsuarios.Remove(amigo);
            spotiFakeContext.SaveChanges();
            var amigos = spotiFakeContext.DetalleUsuarios.Where(o => o.idUsuario == idUsuario).Include(o => o.usuario).ToList();
            return View("Index", amigos);
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