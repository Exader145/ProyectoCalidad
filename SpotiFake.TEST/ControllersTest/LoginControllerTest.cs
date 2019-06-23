using Moq;
using NUnit.Framework;
using SpotiFake.Controllers;
using SpotiFake.Interface;
using SpotiFake.Interface.Managers;
using SpotiFake.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SpotiFake.TEST.ControllersTest
{
    [TestFixture]
    public class LoginControllerTest
    {
        [Test]
        public void ProbarSessionIngresoLoginUsuario()
        {
            var usuario = new Usuario()
            {
                idUsuario = 1,
                nombre = "Fernando Carrasco",
                correoElectronico = "fernando@hotmail.com",
                rol = "Usuario",
                contraseña = "1234",
                fechaCreación = DateTime.Now
            };

            var mockService = new Mock<ILoginService>();
            mockService.Setup(o => o.obtenerUsuarioRegistrado(usuario)).Returns(usuario);

            var mockManager = new Mock<ISessionManager>();
            mockManager.Setup(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Setup(o => o.SetNombreUsuario(usuario.nombre));

            var controller = new LoginController(mockService.Object, mockManager.Object);
            var result = controller.Ingreso(usuario) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockService.Verify(o => o.obtenerUsuarioRegistrado(usuario), Times.AtLeastOnce);
            mockManager.Verify(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Verify(o => o.SetNombreUsuario(usuario.nombre));
        }

        [Test]
        public void ProbarSessionIngresoLoginAdmin()
        {
            var usuario = new Usuario()
            {
                idUsuario = 1,
                nombre = "Juan Pérez",
                correoElectronico = "juan@hotmail.com",
                rol = "Admin",
                contraseña = "1234",
                fechaCreación = DateTime.Now
            };

            var mockService = new Mock<ILoginService>();
            mockService.Setup(o => o.obtenerUsuarioRegistrado(usuario)).Returns(usuario);

            var mockManager = new Mock<ISessionManager>();
            mockManager.Setup(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Setup(o => o.SetNombreUsuario(usuario.nombre));

            var controller = new LoginController(mockService.Object, mockManager.Object);
            var result = controller.Ingreso(usuario) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockService.Verify(o => o.obtenerUsuarioRegistrado(usuario), Times.AtLeastOnce);
            mockManager.Verify(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Verify(o => o.SetNombreUsuario(usuario.nombre));
        }

        [Test]
        public void ProbarSessionIngresoLoginSys()
        {
            var usuario = new Usuario()
            {
                idUsuario = 1,
                nombre = "Pedro Rodriguez",
                correoElectronico = "pedro@hotmail.com",
                rol = "Sys",
                contraseña = "1234",
                fechaCreación = DateTime.Now
            };

            var mockService = new Mock<ILoginService>();
            mockService.Setup(o => o.obtenerUsuarioRegistrado(usuario)).Returns(usuario);

            var mockManager = new Mock<ISessionManager>();
            mockManager.Setup(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Setup(o => o.SetNombreUsuario(usuario.nombre));

            var controller = new LoginController(mockService.Object, mockManager.Object);
            var result = controller.Ingreso(usuario) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockService.Verify(o => o.obtenerUsuarioRegistrado(usuario), Times.AtLeastOnce);
            mockManager.Verify(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Verify(o => o.SetNombreUsuario(usuario.nombre));
        }

        [Test]
        public void ProbarSessionIngresoLoginNull()
        {
            var usuario = new Usuario();

            var mockService = new Mock<ILoginService>();
            mockService.Setup(o => o.obtenerUsuarioRegistrado(usuario)).Returns(usuario);

            var mockManager = new Mock<ISessionManager>();
            mockManager.Setup(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Setup(o => o.SetNombreUsuario(usuario.nombre));

            var controller = new LoginController(mockService.Object, mockManager.Object);
            var result = controller.Ingreso(usuario) as RedirectToRouteResult;

            Assert.IsInstanceOf<RedirectToRouteResult>(result);
            mockService.Verify(o => o.obtenerUsuarioRegistrado(usuario), Times.AtLeastOnce);
            mockManager.Verify(o => o.SetIdUsuario(usuario.idUsuario));
            mockManager.Verify(o => o.SetNombreUsuario(usuario.nombre));
        }
    }
}
