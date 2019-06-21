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
    public class LoginController : Controller
    {
        SpotiFakeContext spotiFakeContext = new SpotiFakeContext();

        // GET: Login
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult messenge()
        {
            return View();
        }

        public ActionResult Ingreso(Usuario usuario)
        {
            Usuario usuarioRegistradoBD = spotiFakeContext.Usuarios.Where(o => o.correoElectronico == usuario.correoElectronico && o.contraseña == usuario.contraseña).FirstOrDefault();
            if (usuarioRegistradoBD!=null)
            {
                ViewBag.AccesoConfirmado = usuarioRegistradoBD;
                Session["NombreUsuario"] = usuarioRegistradoBD.nombre;
                Session["IdUsuario"] = usuarioRegistradoBD.idUsuario;

                if (usuarioRegistradoBD.rol == "Admin")
                {
                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return RedirectToAction("AdminIndex", "Usuario");
                }

                if (usuarioRegistradoBD.rol == "Sys")
                {
                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return RedirectToAction("SysIndex", "Usuario");
                }

                if (usuarioRegistradoBD.rol == "Usuario")
                {
                    FormsAuthentication.SetAuthCookie(usuario.correoElectronico, false);
                    return RedirectToAction("UsuarioIndex", "Usuario");
                }
            }

            return View("messenge");

        }
    }
}