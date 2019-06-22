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

        //Pruebas que deberían pasar

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
            var usuario = new Usuario()
            {
                nombre = "Juan Pérez",
                correoElectronico = "juan_perez@hotmail.com",
                rol = "Admin",
                contraseña = "1234",
                fechaCreación = DateTime.Now
            };

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.agregarAdministrador(usuario));

            var controller = new AdminController(mock.Object);
            var result = controller.agregar(usuario);

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.agregarAdministrador(usuario), Times.AtMostOnce);
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
            var usuario = new Usuario()
            {
                nombre = "Pedro Rodriguez",
                correoElectronico = "pedro_rodriguez@hotmail.com",
                rol = "Admin",
                contraseña = "123456",
                fechaCreación = DateTime.Now
            };

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.actualizarYGuardarDatosUsuario(usuario));

            var controller = new AdminController(mock.Object);
            var result = controller.Actualizar(usuario) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.actualizarYGuardarDatosUsuario(usuario), Times.AtLeastOnce);
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



        //Pruebas que no deberian pasar

        [Test]
        public void probarIndexRetornaListaAdministradoresNoPasa()
        {
            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.retornarListaAdministradores());

            var controller = new AdminController(mock.Object);
            var result = controller.Index() as ViewResult;

            Assert.IsNotInstanceOf<ViewResult>(result);
            mock.Verify(o => o.retornarListaAdministradores(), Times.Never);
        }

        [Test]
        public void probarAgregarGuardaDatosAdministradorNoPasa()
        {
            var usuario = new Usuario();

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.agregarAdministrador(usuario));

            var controller = new AdminController(mock.Object);
            var result = controller.agregar(usuario) as RedirectToRouteResult;

            Assert.IsNotInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.agregarAdministrador(usuario), Times.AtLeastOnce);
        }

        [Test]
        public void formularioModificarObtieneObjetoUsuarioNoPasa()
        {
            var idUsuario = 2;

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.obtenerIdUsuarioParaModificar(idUsuario));

            var controller = new AdminController(mock.Object);
            var result = controller.FormularioModificar(idUsuario) as ViewResult;

            Assert.IsNotInstanceOf<ViewResult>(result);
            mock.Verify(o => o.obtenerIdUsuarioParaModificar(idUsuario), Times.Never);
        }

        [Test]
        public void actualizarGuardarDatosModificadosNoPasa()
        {
            var usuario = new Usuario()
            {
                nombre = "Pedro Rodriguez",
                correoElectronico = "pedro_rodriguez@hotmail.com",
                rol = "Admin",
                contraseña = "123456",
                fechaCreación = DateTime.Now
            };

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.actualizarYGuardarDatosUsuario(usuario));

            var controller = new AdminController(mock.Object);
            var result = controller.Actualizar(usuario) as RedirectToRouteResult;

            Assert.IsNotInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.actualizarYGuardarDatosUsuario(usuario), Times.Never);
        }

        [Test]
        public void eliminarEliminaUsuarioPorIdNoPasa()
        {
            int idUsuario = 2;

            var mock = new Mock<IAdministradorService>();
            mock.Setup(o => o.eliminarUsuario(idUsuario));

            var controller = new AdminController(mock.Object);
            var result = controller.eliminar(idUsuario) as RedirectToRouteResult;

            Assert.IsNotInstanceOf<RedirectToRouteResult>(result);
            mock.Verify(o => o.eliminarUsuario(idUsuario), Times.Never);
        }
    }
}
