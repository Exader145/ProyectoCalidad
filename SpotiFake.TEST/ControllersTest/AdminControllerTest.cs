using Moq;
using NUnit.Framework;
using SpotiFake.Controllers;
using SpotiFake.Interface;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpotiFake.TEST.Controllers
{
    [TestFixture]
    public class AdminControllerTest
    {
        [Test]
        public void probarIndexRetornaListaAdministradores()
        {
            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.retornarListaAdministradores());

            var controller = new AdminController(mock.Object);
            var result = controller.Index() as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.retornarListaAdministradores(), Times.AtMostOnce);
        }

        [Test]
        public void probarAgregarGuardaDatosAdministrador()
        {
            //var usuario = new Usuario()
            //{
            //    nombre = "Fernando Carrasco",
            //    correoElectronico = "fher_17@hotmail.com",
            //    rol = "Admin",
            //    contraseña = "1234",
            //    fechaCreación = DateTime.Now
            //};

            var usuarioFalso = new Mock<Usuario>();

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.agregarAdministrador(usuarioFalso.Object));

            var controller = new AdminController(mock.Object);
            var result = controller.agregar(usuarioFalso.Object) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.agregarAdministrador(usuarioFalso.Object), Times.AtMostOnce);
        }

        [Test]
        public void formularioModificarObtieneObjetoUsuario()
        {
            var idUsuario = 2;

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.obtenerIdUsuarioParaModificar(idUsuario));

            var controller = new AdminController(mock.Object);
            var result = controller.FormularioModificar(idUsuario) as ViewResult;

            Assert.IsInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerIdUsuarioParaModificar(idUsuario), Times.AtLeastOnce);
        }

        [Test]
        public void actualizarGuardarDatosModificados()
        {
            var usuarioFalso = new Mock<Usuario>();

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.actualizarYGuardarDatosUsuario(usuarioFalso.Object));

            var controller = new AdminController(mock.Object);
            var result = controller.Actualizar(usuarioFalso.Object) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.actualizarYGuardarDatosUsuario(usuarioFalso.Object));
        }

        [Test]
        public void eliminarEliminaUsuarioPorId()
        {
            int idUsuario = 2;

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.eliminarUsuario(idUsuario));

            var controller = new AdminController(mock.Object);
            var result = controller.eliminar(idUsuario) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.eliminarUsuario(idUsuario), Times.AtLeastOnce);
        }
    }
}
