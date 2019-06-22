using SpotiFake.DataBase;
using SpotiFake.Interface;
using SpotiFake.Models;
using SpotiFake.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpotiFake.Controllers
{
    public class AdminController : Controller
    {

        //SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        private IAdministradorService service;

        public AdminController(IAdministradorService service)
        {
            this.service = service;
        }

        [Authorize]
        public ActionResult Index()
        {
            //var cancion = spotiFakeContext.Usuarios.Where(o=>o.rol=="Admin").ToList();

            var administrador = service.retornarListaAdministradores();

            return View("Index", administrador);
        }

        [Authorize]
        public ViewResult FormularioAdmin()
        {
            return View("FormularioAdmin", new Usuario());
        }

        [Authorize]
        public ActionResult agregar(Usuario usuario)
        {
            //spotiFakeContext.Usuarios.Add(usuario);
            //usuario.rol = "Admin";
            //usuario.fechaCreación = DateTime.Now;
            //spotiFakeContext.SaveChanges();

            var validation = new AdministradorValidation();

            validation.Validate(usuario, ModelState);

            if (!ModelState.IsValid)
                return RedirectToAction("FormularioAdmin");

            service.agregarAdministrador(usuario);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ViewResult FormularioModificar(int id)
        {
            //Usuario admin = spotiFakeContext.Usuarios.Where(o => o.idUsuario == id).First();

            var administrador = service.obtenerIdUsuarioParaModificar(id);

            return View("FormularioModificar", administrador);
        }

        [Authorize]
        public RedirectToRouteResult Actualizar(Usuario usuario)
        {
            //Usuario adminBD = spotiFakeContext.Usuarios.Where(y => y.idUsuario == usuario.idUsuario).First();
            //adminBD.nombre = usuario.nombre;
            //adminBD.correoElectronico = usuario.correoElectronico;
            //adminBD.contraseña = usuario.contraseña;
            //spotiFakeContext.SaveChanges();

            service.actualizarYGuardarDatosUsuario(usuario);

            return RedirectToAction("Index");
        }

        [Authorize]
        public RedirectToRouteResult eliminar(int idUsuario)
        {
            //Usuario usuario = spotiFakeContext.Usuarios.Where(d => d.idUsuario == id).FirstOrDefault();
            //spotiFakeContext.Usuarios.Remove(usuario);
            //spotiFakeContext.SaveChanges();

            service.eliminarUsuario(idUsuario);

            return RedirectToAction("Index");
        }
    }
}